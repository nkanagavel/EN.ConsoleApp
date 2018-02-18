using EN.WebApplication.Models;
using EN.WebApplication.Utility;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace EN.WebApplication.DAL
{
    public class PdfClass
    {
        SqlConnection _connetion;
        SqlCommand _command;
        SqlDataReader _dataReader;
        string conString = "Data Source=.;Initial Catalog=Monkey;Integrated Security=true";
        public MemoryStream GetAttendanceReportPdf(string attendancemonth, string attendanceyear)
        {
            MemoryStream workStream = new MemoryStream();
            try
            {

                

                // 0 - Day Shift
                // 1 - Night Shift


                int count = 0;
                DateTime startDate; DateTime endDate;
                string month = attendancemonth.Split('-')[0];
                count = DateTime.DaysInMonth(Convert.ToInt16(attendanceyear), Convert.ToInt16(month));
                startDate = new DateTime(Convert.ToInt16(attendanceyear), Convert.ToInt16(month), 1);
                //startDate = Convert.ToDateTime($"{month}/01/{attendanceyear}");
                endDate = new DateTime(Convert.ToInt16(attendanceyear), Convert.ToInt16(month), count);
                // endDate = Convert.ToDateTime($"{month}/30/{attendanceyear}");


                //var count = 30;
                //.ToString("d")

                var maxRetryAttempts = 3;
                var pauseBetweenFailures = TimeSpan.FromSeconds(2);
                var userList = string.Empty;
                //RetryHelper.RetryOnException(maxRetryAttempts, pauseBetweenFailures, () =>
                //{
                //    output = GetAttendance(_category, startDate, endDate);
                //});
                int _category = 0;
                var output = GetAttendance(_category, startDate, endDate);
                var empOutput = GetFormattedData(output, startDate, count);
                var result = empOutput.OrderBy(x => x.EmployeeName).ToList();

                _category = 1;
                var output2 = GetAttendance(_category, startDate, endDate);
                var empOutput2 = GetFormattedData(output2, startDate, count);
                var result2 = empOutput2.OrderBy(x => x.EmployeeName).ToList();

                _category = 0;
                var output3 = GetAttendance(_category, startDate, endDate, true);
                var empOutput3 = GetFormattedData(output3, startDate, count);
                var result3 = empOutput3.OrderBy(x => x.EmployeeName).ToList();

                _category = 1;
                var output4 = GetAttendance(_category, startDate, endDate, true);
                var empOutput4 = GetFormattedData(output4, startDate, count);
                var result4 = empOutput4.OrderBy(x => x.EmployeeName).ToList();
                /*
                _category = "5";
                var output5 = GetAttendance(_category, startDate, endDate);
                var empOutput5 = GetFormattedData(output5);
                var result5 = empOutput5.Where(x => x.ShiftName == _category).OrderBy(x => x.Id).ToList();


                // 6 - Day Shift Relief
                _category = "6";
                var output6 = GetAttendance(_category, startDate, endDate);
                var empOutput6 = GetFormattedData(output6);
                var result6 = empOutput6.Where(x => x.ShiftName == _category).OrderBy(x => x.Id).ToList();

                // 7-Night Shift Relief
                _category = "7";
                var output7 = GetAttendance(_category, startDate, endDate);
                var empOutput7 = GetFormattedData(output7);
                var result7 = empOutput7.Where(x => x.ShiftName == _category).OrderBy(x => x.Id).ToList();
                */


                Document document = new Document();
                document.SetMargins(0f, 0f, 18f, 36f);
                document.SetPageSize(iTextSharp.text.PageSize.A3.Rotate());

                PdfWriter.GetInstance(document, workStream).CloseStream = false;
                document.Open();
                //PdfPTable table = new PdfPTable(47);

                PdfPTable table, table2, table3, table4, table5, table6, table7;
                table = new PdfPTable(63);
                table2 = new PdfPTable(63);
                table3 = new PdfPTable(63);
                table4 = new PdfPTable(63);
                table5 = new PdfPTable(63);
                table6 = new PdfPTable(63);
                table7 = new PdfPTable(63);

                if (count == 30)
                {
                    table = new PdfPTable(61);
                    table2 = new PdfPTable(61);
                    table3 = new PdfPTable(61);
                    table4 = new PdfPTable(61);
                    table5 = new PdfPTable(61);
                    table6 = new PdfPTable(61);
                    table7 = new PdfPTable(61);
                }

                if (count == 30)
                    table.ResetColumnCount(61);
                table.SpacingBefore = 12.5f;
                table.HorizontalAlignment = 0;
                table.TotalWidth = 1190;
                table.LockedWidth = true;
                table.SpacingAfter = 12.5f;

                //PdfPTable table2 = new PdfPTable(47);

                if (count == 30)
                    table2.ResetColumnCount(61);
                table2.HorizontalAlignment = 0;
                table2.TotalWidth = 1190;
                table2.LockedWidth = true;
                table2.SpacingAfter = 12.5f;

                //PdfPTable table3 = new PdfPTable(47);
                if (count == 30)
                    table3.ResetColumnCount(61);
                table3.HorizontalAlignment = 0;
                table3.TotalWidth = 1190;
                table3.LockedWidth = true;
                table3.SpacingAfter = 12.5f;

                //PdfPTable table4 = new PdfPTable(47);
                if (count == 30)
                    table4.ResetColumnCount(61);
                table4.HorizontalAlignment = 0;
                table4.TotalWidth = 1190;
                table4.LockedWidth = true;
                table4.SpacingAfter = 12.5f;

                //PdfPTable table5 = new PdfPTable(47);
                if (count == 30)
                    table5.ResetColumnCount(61);
                table5.HorizontalAlignment = 0;
                table5.TotalWidth = 1190;
                table5.LockedWidth = true;
                table5.SpacingAfter = 12.5f;

                //PdfPTable table6 = new PdfPTable(47);
                if (count == 30)
                    table6.ResetColumnCount(61);
                table6.HorizontalAlignment = 0;
                table6.TotalWidth = 1190;
                table6.LockedWidth = true;
                table6.SpacingAfter = 12.5f;

                if (count == 30)
                    table7.ResetColumnCount(61);
                table7.HorizontalAlignment = 0;
                table7.TotalWidth = 1190;
                table7.LockedWidth = true;
                table7.SpacingAfter = 12.5f;

                //float[] widths = new float[] { 20f, 60f, 60f, 20f, 50f, 80f, 50f, 50f, 50f, 50f, 50f };
                //table.SetWidths(widths);

                Paragraph p1 = new Paragraph();
                p1.Add(new Chunk("Sin Ming Avenue", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 10, 1, new iTextSharp.text.BaseColor(0, 0, 0))));
                p1.Alignment = Element.ALIGN_CENTER;

                Paragraph p2 = new Paragraph();
                p2.Add(new Chunk($"Staff Attendace Report for {attendancemonth.Split('-')[1]} Month.", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 0, new iTextSharp.text.BaseColor(0, 0, 0))));
                p2.Alignment = Element.ALIGN_CENTER;

                //Paragraph p2 = new Paragraph();
                //p2.Add(new Chunk("THE MANAGEMENT CORPORATION STRATA TITLE PLAN NO. 3424", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 0, new iTextSharp.text.BaseColor(0, 0, 0))));
                //p2.Alignment = Element.ALIGN_CENTER;

                Paragraph p3 = new Paragraph();
                p3.Add(new Chunk("58 Woodlands Drive 16 #01-18 La casa Singapore 737897", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 0, new iTextSharp.text.BaseColor(0, 0, 0))));
                p3.Alignment = Element.ALIGN_CENTER;

                Paragraph p4 = new Paragraph();
                p4.Add(new Chunk("Tel: 6469 7405  Fax: 64697190", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 0, new iTextSharp.text.BaseColor(0, 0, 0))));
                p4.Alignment = Element.ALIGN_CENTER;

                Paragraph p5 = new Paragraph();
                p5.Add(new Chunk("SECURITY ATTENDANCE", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8, 0, new iTextSharp.text.BaseColor(0, 0, 0))));
                p5.Alignment = Element.ALIGN_CENTER;

                document.Add(p1);
                document.Add(p2);
                //document.Add(p3);
                //document.Add(p4);
                //document.Add(p5);

                document.Add(AddContent(table, result, "1", count));
                document.Add(AddContent(table2, result2, "2", count));
                document.Add(AddContent(table3, result3, "3", count));
                document.Add(AddContent(table4, result4, "4", count));

                //document.Add(AddContent(table6, result6, "6", count));
                //document.Add(AddContent(table7, result7, "7", count));
                //document.Add(AddContent(table5, result5, "5", count));


                document.Close();

                byte[] byteInfo = workStream.ToArray();
                workStream.Write(byteInfo, 0, byteInfo.Length);
                workStream.Position = 0;


                //string strPDFFileName = string.Format("StaffAttendance" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".pdf");
                //string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);
                //return File(workStream, "application/pdf", strPDFFileName);
            }
            catch (Exception ex)
            {
                ErrorLogger.WriteToFile(ex.Message.ToString());
                //return null;
            }

            return workStream;
        }

        private List<Data> GetAttendance(int _category, DateTime _startDate, DateTime _endDate, bool isrelief = false)
        {
            var _bioMetricData = new List<Data>();
            try
            {
                _connetion = new SqlConnection(conString);
                //_command = new SqlCommand("SELECT EmployeeId,st.StaffName,st.Category,AttendanceDate,InTime,OutTime FROM dbo.StaffAttendance sa Join dbo.StaffDetails st on st.Id = EmployeeId where st.Category= '" + _category + "' and AttendanceDate between '2017-09-01 00:00:00:000' AND '2017-09-30 00:00:00:000' order by EmployeeName,AttendanceDate asc");
                //_command = new SqlCommand($"SELECT EmployeeId,st.StaffName,st.Category,AttendanceDate,InTime,OutTime FROM dbo.StaffAttendance sa Join dbo.StaffDetails st on st.Id = EmployeeId where st.Category= '{_category }' and AttendanceDate between '{_startDate.ToString("MM/dd/yyyy")}' AND '{_endDate.ToString("MM/dd/yyyy")}' order by EmployeeName,AttendanceDate asc");
                if (isrelief)
                    _command = new SqlCommand($"SELECT EmployeeId,st.EmployeeName,st.Category,AttendanceDate,InTime,OutTime FROM dbo.StaffAttendance st where st.Category= {_category} and st.EmployeeId not in (3,4,6,7,8,9,10,11,16) and AttendanceDate between '{_startDate.ToString("MM/dd/yyyy")}' AND '{_endDate.ToString("MM/dd/yyyy")}' order by st.EmployeeName");
                if (!isrelief)
                    _command = new SqlCommand($"SELECT EmployeeId,st.EmployeeName,st.Category,AttendanceDate,InTime,OutTime FROM dbo.StaffAttendance st where st.Category= {_category} and st.EmployeeId in (3,4,6,7,8,9,10,11,16) and AttendanceDate between '{_startDate.ToString("MM/dd/yyyy")}' AND '{_endDate.ToString("MM/dd/yyyy")}' order by st.EmployeeName");
                _command.Connection = _connetion;
                _connetion.Open();
                _dataReader = _command.ExecuteReader();
                while (_dataReader.Read())
                {
                    _bioMetricData.Add(new Data()
                    {
                        Id = Convert.ToInt32(_dataReader.GetValue(0)),
                        EmployeeName = Convert.ToString(_dataReader.GetValue(1)),
                        ShiftType = Convert.ToInt16(_dataReader.GetValue(2)),
                        AttendanceDate = Convert.ToDateTime(_dataReader.GetValue(3)),
                        InTime = Convert.ToString(_dataReader.GetValue(4)),
                        OutTime = Convert.ToString(_dataReader.GetValue(5))
                    });
                }
            }
            catch (Exception ex)
            {
                object error = ex.Message ?? ex.InnerException.Message;
            }
            finally
            {
                _dataReader.Close();
                _connetion.Close();
            }
            return _bioMetricData;
        }

        private List<AttendaceModel> GetFormattedData(List<Data> _dbdata, DateTime sDate, int count)
        {
            var dlist = _dbdata.GroupBy(p => p.AttendanceDate.Date)
                            .Select(g => g.First())
                            .ToList();
            /* Get date list from the attendance table */

            //var fromToDate = new List<DateTime>();
            //foreach (var da in dlist)
            //{
            //    fromToDate.Add(da.AttendanceDate.Date);
            //}

            var fromToDate = this.GetDateList(_dbdata);

            var dlist1 = _dbdata.GroupBy(p => p.Id)
                        .Select(g => g.First())
                        .ToList();


            /* Get employee id list */
            //var empIdList = new List<int>();

            //foreach (var da in dlist1)
            //{
            //    empIdList.Add(da.Id);
            //}
            var empIdList = this.GetEmployeesId(_dbdata);

            var finalList = new List<AttendaceModel>();
            foreach (var eid in empIdList)
            {
                var employee = new AttendaceModel();
                employee.Id = eid;
                var n = _dbdata.Where(c => c.Id == eid).Select(g => new { g.EmployeeName, g.ShiftType }).ToList();
                if (n != null && n.Count > 0)
                {
                    employee.EmployeeName = n[0]?.EmployeeName;
                    employee.ShiftName = Convert.ToString(n[0]?.ShiftType);
                }

                var inoutList = new List<InOutTime>();
                //foreach (var bdate in fromToDate)
                //{
                for (int i = 0; i < count; i++)
                {
                    var inout = new InOutTime();
                    var bdate = sDate.AddDays(i);
                    inout.AttendanceDate = bdate.Day;
                    inout.InTime = string.Empty;
                    inout.OutTime = string.Empty;
                    var inoutbyDate = _dbdata.Where(c => c.Id == eid && c.AttendanceDate.Date == bdate.Date)
                                    .Select(g => new { g.InTime, g.OutTime }).ToList();

                    if (inoutbyDate != null && inoutbyDate.Count > 0)
                    {

                        inout.InTime = inoutbyDate[0]?.InTime;
                        inout.OutTime = inoutbyDate[0]?.OutTime;
                    }

                    inoutList.Add(inout);
                }



                //}
                employee.Attendance = inoutList;
                finalList.Add(employee);
            }
            return finalList;
        }

        private List<DateTime> GetDateList(List<Data> rawdata)

            => rawdata.Select(i => i.AttendanceDate.Date).Distinct().ToList();

        private List<int> GetEmployeesId(List<Data> rawdata)

            => rawdata.OrderBy(i => i.Id).Select(i => i.Id).Distinct().ToList();

        private PdfPTable AddContent(PdfPTable table, List<AttendaceModel> _employees, string _category, int count)
        {
            float[] widths;
            //float[] widths = new float[] { 50f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f };
            if (count == 31)
                widths = new float[] { 50f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f };
            else
                widths = new float[] { 50f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f, 17f };
            /*  float[] headers =  { 10, 45, 54, 30, 50, 15 }; */ //Header Widths
            table.SetWidths(widths);        //Set the pdf headers
            table.WidthPercentage = 100;       //Set the PDF File witdh percentage
            table.HeaderRows = 1;

            var attendanceLength = count;
            //var attendanceLength = 0;

            //if (_employees != null && _employees.Count > 0)
            //    attendanceLength = _employees[0].Attendance.Count;


            if (_category == "1")
                AddCellToHeader(table, "DAY SHIFT", 1);
            if (_category == "2")
                AddCellToHeader(table, "NIGHT SHIFT", 1);
            if (_category == "3")
                AddCellToHeader(table, "DAY RELIEF", 1);
            if (_category == "4")
                AddCellToHeader(table, "NIGHT RELIEF", 1);

            /*                          
            if (_category == "1" || _category == "3" || _category == "4" || _category == "5")
                AddCellToHeader(table, "DAY SHIFT", 1);
            if (_category == "6")
                AddCellToHeader(table, "DAY RELIEF", 1);
            if (_category == "7")
                AddCellToHeader(table, "NIGHT RELIEF", 1);
            if (_category == "2")
                AddCellToHeader(table, "NIGHT SHIFT", 1);

            AddCellToHeader(table, "Sin Ming Ave", 2 * attendanceLength);

            if (_category == "1" || _category == "2")
                AddCellToHeader(table, "PERMANANT STAFF", 1);
            if (_category == "3")
                AddCellToHeader(table, "MANAGEMENT STAFF", 1);
            if (_category == "4")
                AddCellToHeader(table, "IT STAFF", 1);
            if (_category == "6" || _category == "7")
                AddCellToHeader(table, "RELIEF STAFF", 1);
            if (_category == "5")
                AddCellToHeader(table, "FACILITY STAFF", 1);
            */

            for (int i = 0; i < attendanceLength; i++)
            {
                AddCellToHeader(table, $"{(i + 1)}", 2);
            }

            if (_category == "1" || _category == "3")
                AddCellToHeader(table, "8.00AM-8.00PM", 1);

            if (_category == "2" || _category == "4")
                AddCellToHeader(table, "8.00PM-8.00AM", 1);
            /*
            if (_category == "1" || _category == "3" || _category == "4" || _category == "5" || _category == "6")
                AddCellToHeader(table, "8.00AM-8.00PM", 1);

            if (_category == "2" || _category == "7")
                AddCellToHeader(table, "8.00PM-8.00AM", 1);
             */

            for (int i = 0; i < attendanceLength; i++)
            {
                AddCellToHeader(table, "IN", 1);
                AddCellToHeader(table, "OUT", 1);
            }

            for (var i = 0; i < _employees.Count; i++)
            {
                AddCellToBody(table, _employees[i].EmployeeName, 1, 0);
                //for (var j = 0; j < _employees[i].Attendance.Count; j++)
                for (var j = 0; j < count; j++)
                {
                    if (j > _employees[i].Attendance.Count - 1)
                    {
                        AddCellToBody(table, "NA", 1);
                        AddCellToBody(table, "NA", 1);
                    }
                    else
                    {
                        if (_employees[i]?.Attendance[j]?.InTime == "" && _employees[i].Attendance[j].OutTime == "")
                        {
                            AddCellToBody(table, "NA", 2);
                        }
                        else
                        {
                            AddCellToBody(table, _employees[i]?.Attendance[j]?.InTime != "" ? _employees[i]?.Attendance[j]?.InTime : "--", 1);
                            AddCellToBody(table, _employees[i]?.Attendance[j]?.OutTime != "" ? _employees[i].Attendance[j]?.OutTime : "--", 1);
                        }
                    }
                }
            }

            return table;
        }

        private static void AddCellToHeader(PdfPTable tableLayout, string cellText, int colSpan, int alignment = 1)
        {
            tableLayout.AddCell(
                new PdfPCell(
                    new Phrase(cellText,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 7, 1, iTextSharp.text.BaseColor.WHITE)))
                {
                    Colspan = colSpan,
                    HorizontalAlignment = alignment,
                    PaddingLeft = 0,
                    PaddingRight = 0,
                    PaddingBottom = 5,
                    PaddingTop = 5,
                    BorderWidth = 0.5f,
                    BackgroundColor = new iTextSharp.text.BaseColor(125, 109, 175)
                });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText, int colSpan, int alignment = 1)
        {
            tableLayout.AddCell(
                new PdfPCell(
                    new Phrase(cellText,
                new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 7, 1, iTextSharp.text.BaseColor.BLACK)))
                {
                    Colspan = colSpan,
                    HorizontalAlignment = alignment,
                    PaddingLeft = alignment == 0 ? 5 : 0,
                    PaddingRight = 0,
                    PaddingBottom = 5,
                    PaddingTop = 5,
                    BorderWidth = 0.5f,
                    BackgroundColor = cellText == "OFF" ? new iTextSharp.text.BaseColor(255, 255, 0) : new iTextSharp.text.BaseColor(255, 255, 255)
                });
        }
    }
}