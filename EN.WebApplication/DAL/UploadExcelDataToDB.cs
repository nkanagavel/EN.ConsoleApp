using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ExcelDataReader;
using EN.WebApplication.Models;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using EN.WebApplication.Utility;

namespace EN.WebApplication.DAL
{
    public class UploadExcelDataToDB
    {
        SqlConnection _connetion;
        SqlCommand _command;
        SqlDataReader _dataReader;
        string conString = "Data Source=.;Initial Catalog=Monkey;Integrated Security=true";
        public void ReadExcelData(string filename = null)
        {

            IExcelDataReader reader = null;
            try
            {
                FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);

                Stream stream = fileStream;

                if (filename.Contains(".xlsx"))
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                else if (filename.Contains(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    ErrorLogger.WriteToFile("Input File is not correct format.");

                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                var _rawBioMetricData = new List<RawData>();
                if (result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in result.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            try
                            {
                                var bioMetricData = new RawData();
                                bioMetricData.Id = Convert.ToInt16(dr["ACNo"]);
                                bioMetricData.EmployeeName = dr["Name"].ToString();
                                bioMetricData.EntryDateTime = Convert.ToDateTime(dr["Time"]);
                                bioMetricData.Status = dr["Status"].ToString();
                                _rawBioMetricData.Add(bioMetricData);
                            }
                            catch (Exception ex)
                            {
                                ErrorLogger.WriteToFile(ex.Message.ToString());
                            }
                        }

                    }
                }

                var orderedData = _rawBioMetricData.OrderBy(i => i.EntryDateTime).OrderBy(i => i.Status).ToList();

                //Get the date range from the list.
                //var dates = orderedData.Select(i => i.EntryDateTime.Date).Distinct().ToList();
                var dates = this.GetDateList(orderedData);


                //Get the id from the list.
                //var ids = orderedData.OrderBy(i => i.Id).Select(i => i.Id).Distinct().ToList();
                var ids = this.GetEmployeesId(orderedData);

                //Get the formatted data to be inserted into DB.
                var dataToInsert = this.ExtractProperData(ids, dates, orderedData);

                foreach (var data in dataToInsert)
                {
                    if (!(data?.InTime == null && data?.OutTime == null))
                        this.UploadExtractedDataToDB(data);
                }

            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToFile(ex.Message.ToString());
            }
            finally
            {
                reader.Close();
            }
        }

        private List<Data> ExtractProperData(List<int> ids = null, List<DateTime> dates = null, List<RawData> rawData = null)
        {
            var formattedData = new List<Data>();
            if (rawData != null)
            {
                foreach (var id in ids)
                {
                    foreach (var date in dates)
                    {
                        var data = rawData.Where(i => i.EntryDateTime.Date == date && i.Id == id).ToList();
                        if (data != null && data.Count > 0)
                        {
                            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(data));
                            var _formattedData = new Data();
                            _formattedData.Id = data[0].Id;
                            _formattedData.EmployeeName = data[0].EmployeeName;
                            _formattedData.AttendanceDate = data[0].EntryDateTime.Date;

                            var CheckinTime = data.Where(i => i.Status == "C/In").Select(x => x.EntryDateTime).ToList();
                            if (CheckinTime.Count > 0)
                            {
                                if (CheckinTime[0].ToString("tt") == "AM")
                                {
                                    _formattedData.InTime = $"{CheckinTime[0].Hour.ToString("D2")}{CheckinTime[0].Minute.ToString("D2")}";
                                    var CheckOutObject = data.Where(i => i.Status == "C/O").Select(x => x.EntryDateTime).ToList();
                                    if (CheckOutObject.Count > 0)
                                    {
                                        var CheckOutTime = CheckOutObject.Count > 1 ? CheckOutObject[CheckOutObject.Count - 1] : CheckOutObject[0];
                                        _formattedData.OutTime = $"{CheckOutTime.Hour.ToString("D2")}{CheckOutTime.Minute.ToString("D2")}";
                                    }
                                }

                                if (CheckinTime[0].ToString("tt") == "PM")
                                {
                                    var lookupDate = date;
                                    _formattedData.InTime = $"{CheckinTime[0].Hour.ToString("D2")}{CheckinTime[0].Minute.ToString("D2")}";
                                    var CheckOutObject = rawData.Where(i => i.EntryDateTime.Date == lookupDate.AddDays(1) && i.Status == "C/O" && i.Id == id).Select(x => x.EntryDateTime).ToList();

                                    if (CheckOutObject.Count > 0)
                                    {
                                        var CheckOutTime = CheckOutObject.Count > 1 ? CheckOutObject[CheckOutObject.Count - 1] : CheckOutObject[0];
                                        _formattedData.OutTime = $"{CheckOutTime.Hour.ToString("D2")}{CheckOutTime.Minute.ToString("D2")}";
                                    }
                                    _formattedData.ShiftType = 1;
                                }
                            }
                            formattedData.Add(_formattedData);
                        }
                    }

                }
            }

            return formattedData;

        }

        private int UploadExtractedDataToDB(Data data = null)
        {

            int _result;
            try
            {
                _connetion = new SqlConnection(conString);
                _command = new SqlCommand();

                if (string.IsNullOrWhiteSpace(data.OutTime))
                {
                    _command.CommandText = "INSERT INTO dbo.StaffAttendance(EmployeeId,EmployeeName,AttendanceDate,InTime,Category)"
                       + " VALUES(@EmployeeId, @EmployeeName, @AttendanceDate, @InTime,@Category)";
                }
                else
                {
                    _command.CommandText = "INSERT INTO dbo.StaffAttendance(EmployeeId,EmployeeName,AttendanceDate,InTime,OutTime,Category)"
                                      + " VALUES(@EmployeeId, @EmployeeName, @AttendanceDate, @InTime, @OutTime,@Category)";
                    _command.Parameters.AddWithValue("@OutTime", data?.OutTime);
                }

                _command.CommandType = CommandType.Text;
                _command.Connection = _connetion;

                _command.Parameters.AddWithValue("@EmployeeId", data?.Id);
                _command.Parameters.AddWithValue("@EmployeeName", data?.EmployeeName);
                _command.Parameters.AddWithValue("@AttendanceDate", data?.AttendanceDate);
                _command.Parameters.AddWithValue("@InTime", data?.InTime);
                _command.Parameters.AddWithValue("@Category", data?.ShiftType);

                _connetion.Open();
                _result = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToFile(ex.Message.ToString());
                _result = -1;
            }
            finally
            {
                _connetion.Close();
            }
            return _result;
        }

        private List<DateTime> GetDateList(List<RawData> rawdata)

            => rawdata.Select(i => i.EntryDateTime.Date).Distinct().ToList();

        private List<int> GetEmployeesId(List<RawData> rawdata)

            => rawdata.OrderBy(i => i.Id).Select(i => i.Id).Distinct().ToList();

    }
}