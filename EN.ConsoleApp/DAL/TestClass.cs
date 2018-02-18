using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    public class TestClass
    {
        SqlConnection _connetion;
        SqlCommand _command;
        SqlDataReader _dataReader;
        public void GetExcelData()
        {
            //string filePath = @"D:\Kanagavel\sample.xlsx";
            //string filePath = @"D:\Kanagavel\SEPTEMBER SIN MING - FINAL.xlsx";
            //string filePath = @"C:\Users\itluser\Desktop\Sep 2017.xlsx";
            // string filePath = @"C:\Users\itluser\Desktop\Oct 2017.xlsx";
            //string filePath = @"C:\Users\itluser\Desktop\Nov1.xlsx";
            string filePath = @"C:\Users\itluser\Desktop\New folder\SIN MING AVE -FINAL1.xlsx";
            //string filePath = @"C:\Users\itluser\Desktop\New folder\SIN MING AVE -FINAL2.xlsx";
            try
            {

                FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

                Stream stream = fileStream;
                // We return the interface, so that
                IExcelDataReader reader = null;

                //filePath.Substring(filePath.IndexOf('.') + 1)
                if (filePath.Contains(".xlsx"))
                    reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                else if (filePath.Contains(".xls"))
                    reader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    Console.WriteLine("File Files found.");

                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });
                reader.Close();
                var _bioMetricData = new List<RawBioMetricData>();
                if (result.Tables[0].Rows.Count > 0)
                {
                    foreach (DataTable table in result.Tables)
                    {
                        foreach (DataRow dr in table.Rows)
                        {
                            try
                            {
                                var bioMetricData = new RawBioMetricData();
                                bioMetricData.Id = Convert.ToInt16(dr["ACNo"]);
                                bioMetricData.EmployeeName = dr["Name"].ToString();
                                bioMetricData.EntryDateTime = Convert.ToDateTime(dr["Time"]);
                                bioMetricData.Status = dr["Status"].ToString();
                                _bioMetricData.Add(bioMetricData);
                                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(bioMetricData));
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex.Message.ToString());
                            }
                        }

                    }
                }

                var rawData = _bioMetricData;
                var orderedData = rawData.OrderBy(i => i.EntryDateTime).OrderBy(i => i.Status).ToList();
                var dates = orderedData.Select(i => i.EntryDateTime.Date).Distinct().ToList();
                var ids = orderedData.OrderBy(i => i.Id).Select(i => i.Id).Distinct().ToList();

                var formattedBioData = new List<BioMetricData>();

                foreach (var id in ids)
                {
                    foreach (var date in dates)
                    {
                        var data = orderedData.Where(i => i.EntryDateTime.Date == date && i.Id == id).ToList();
                        if (data != null && data.Count > 0)
                        {
                            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(data));
                            var _formattedBioData = new BioMetricData();
                            _formattedBioData.Id = data[0].Id;
                            _formattedBioData.EmployeeName = data[0].EmployeeName;
                            _formattedBioData.AttendanceDate = data[0].EntryDateTime.Date;

                            var CheckinTime = data.Where(i => i.Status == "C/In").Select(x => x.EntryDateTime).ToList();
                            if (CheckinTime.Count > 0)
                            {
                                if (CheckinTime[0].ToString("tt") == "AM")
                                {
                                    _formattedBioData.InTime = $"{CheckinTime[0].Hour.ToString("D2")}{CheckinTime[0].Minute.ToString("D2")}";
                                    var CheckOutObject = data.Where(i => i.Status == "C/O").Select(x => x.EntryDateTime).ToList();
                                    if (CheckOutObject.Count > 0)
                                    {
                                        var CheckOutTime = CheckOutObject.Count > 1 ? CheckOutObject[CheckOutObject.Count - 1] : CheckOutObject[0];
                                        _formattedBioData.OutTime = $"{CheckOutTime.Hour.ToString("D2")}{CheckOutTime.Minute.ToString("D2")}";
                                    }
                                }

                                if (CheckinTime[0].ToString("tt") == "PM")
                                {
                                    var lookupDate = date;
                                    _formattedBioData.InTime = $"{CheckinTime[0].Hour.ToString("D2")}{CheckinTime[0].Minute.ToString("D2")}";
                                    var CheckOutObject = orderedData.Where(i => i.EntryDateTime.Date == lookupDate.AddDays(1) && i.Status == "C/O" && i.Id == id).Select(x => x.EntryDateTime).ToList();

                                    if (CheckOutObject.Count > 0)
                                    {
                                        var CheckOutTime = CheckOutObject.Count > 1 ? CheckOutObject[CheckOutObject.Count - 1] : CheckOutObject[0];
                                        _formattedBioData.OutTime = $"{CheckOutTime.Hour.ToString("D2")}{CheckOutTime.Minute.ToString("D2")}";
                                    }
                                    _formattedBioData.ShiftType = 1;
                                }
                            }






                            //var CheckOutTime = data.Where(i => i.Status == "C/O").ToList();

                            // Get AM or PM CheckinTime[0].EntryDateTime.ToString("tt");


                            //if (data.Count > 1)
                            //{
                            //    _formattedBioData.OutTime = $"{data[1].EntryDateTime.Hour.ToString("D2")}{data[1].EntryDateTime.Minute.ToString("D2")}";
                            //}

                            formattedBioData.Add(_formattedBioData);
                        }
                    }

                }
                foreach (var attendance in formattedBioData)
                {
                    if (!(attendance?.InTime == null && attendance?.OutTime == null))
                        this.InsertFormatedBioMetricData(attendance);
                }
                //var result1 = formattedBioData.Where(i => i.OutTime != null).ToList();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());

            }
        }

        private int InsertFormatedBioMetricData(BioMetricData bioMetricOutput = null)
        {
            string conString = "Data Source=.;Initial Catalog=Monkey;Integrated Security=true";
            int _result;
            try
            {
                _connetion = new SqlConnection(conString);
                _command = new SqlCommand();
                //if (string.IsNullOrWhiteSpace(bioMetricOutput.OutTime) && string.IsNullOrWhiteSpace(bioMetricOutput.InTime))
                //{
                //    _command.CommandText = "INSERT INTO dbo.StaffAttendance(EmployeeId,EmployeeName,AttendanceDate,Category)"
                //       + " VALUES(@EmployeeId, @EmployeeName, @AttendanceDate,@Category)";
                //    _command.Parameters.AddWithValue("@InTime", bioMetricOutput?.InTime);
                //}
                //else

                if (string.IsNullOrWhiteSpace(bioMetricOutput.OutTime))
                {
                    _command.CommandText = "INSERT INTO dbo.StaffAttendance(EmployeeId,EmployeeName,AttendanceDate,InTime,Category)"
                       + " VALUES(@EmployeeId, @EmployeeName, @AttendanceDate, @InTime,@Category)";
                }
                else
                {
                    _command.CommandText = "INSERT INTO dbo.StaffAttendance(EmployeeId,EmployeeName,AttendanceDate,InTime,OutTime,Category)"
                                      + " VALUES(@EmployeeId, @EmployeeName, @AttendanceDate, @InTime, @OutTime,@Category)";
                    _command.Parameters.AddWithValue("@OutTime", bioMetricOutput?.OutTime);
                }

                _command.CommandType = CommandType.Text;
                _command.Parameters.AddWithValue("@EmployeeId", bioMetricOutput?.Id);
                _command.Parameters.AddWithValue("@EmployeeName", bioMetricOutput?.EmployeeName);
                _command.Parameters.AddWithValue("@AttendanceDate", bioMetricOutput?.AttendanceDate);
                _command.Parameters.AddWithValue("@InTime", bioMetricOutput?.InTime);
                _command.Parameters.AddWithValue("@Category", bioMetricOutput?.ShiftType);

                _command.Connection = _connetion;
                _connetion.Open();
                _result = _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                _result = -1;
            }
            finally
            {
                _connetion.Close();
            }
            return _result;
        }
    }

    public class BioMetricData
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public DateTime AttendanceDate { get; set; }
        public string InTime { get; set; }
        public string OutTime { get; set; }

        public int ShiftType { get; set; }

    }
    public class RawBioMetricData
    {
        public string EmployeeName { get; set; }
        public int Id { get; set; }
        public DateTime EntryDateTime { get; set; }
        public string Status { get; set; }
    }
}
