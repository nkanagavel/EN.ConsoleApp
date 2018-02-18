using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EN.DataLayer.DBFirst;
using EN.WebApplication.Filters;
using EN.WebApplication.DAL;
using System.Web.Security;
using System.IO;
using System.Text;
using EN.WebApplication.Models;

namespace EN.WebApplication.Controllers
{
    [LogActionAttribute]
    public class HomeController : Controller
    {
        private readonly MonkeyDBEntities monkeyDBEntities = new MonkeyDBEntities();
        private readonly UsersDbContext usersDbContext = new UsersDbContext();
        private readonly EmployeeContext employeeContext = new EmployeeContext();
        public ActionResult Login()
        {
            //string filepath = @"C:\Users\itluser\Desktop\GPSIPW_BUFR_161202055_1800_ALL.GPS_NWS";
            //string outptufilepath = @"C:\Users\itluser\Desktop\GPSIPW_BUFR_161202055_1800_ALL.txt";
            //StringBuilder sb1 = new StringBuilder();
            //string myString;
            //using (FileStream fs1 = new FileStream(filepath, FileMode.Open))
            //{
            //    using (BinaryReader br = new BinaryReader(fs1))
            //    {

            //        Byte[] bytes = br.ReadBytes((Int32)fs1.Length);

            //       // var test = br.ReadString();

            //        byte[] bin = br.ReadBytes(Convert.ToInt32(fs1.Length));
            //        myString = Convert.ToBase64String(bin);

            //        //foreach (byte b in test)
            //        //{
            //        //    sb1.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            //        //}
            //    }

            //    //bool b = br.ReadBoolean();
            //    //byte _byte = br.ReadByte();
            //    //char _char = br.ReadChar();
            //    //string _string = br.ReadString();
            //    //int _int = br.ReadInt16();
            //    //double _dbl = br.ReadDouble();
            //}


            //byte[] rebin = Convert.FromBase64String(myString);
            //using (FileStream fs2 = new FileStream(outptufilepath, FileMode.Create))
            //using (BinaryWriter bw = new BinaryWriter(fs2))
            //    bw.Write(rebin);

            //byte[] fileBytes = System.IO.File.ReadAllBytes(filepath);
            //StringBuilder sb = new StringBuilder();
            //foreach (byte b in fileBytes)
            //{
            //    string s_unicode2 = System.Text.Encoding.UTF8.GetString(fileBytes);
            //    //String.Concat(fileBytes.Select(b => b.ToString("x2")));
            //    sb.Append(Convert.ToString(b));
            //    //sb.Append(String.Concat(fileBytes.Select(b => b.ToString("x2"))));
            //}
            //System.IO.File.WriteAllText(outptufilepath, sb.ToString());

            //FileStream fs = System.IO.File.OpenRead(filepath);
            //byte[] data = new byte[fs.Length];

            //fs.Read(data, 0, data.Length);

            return View();
        }

        public byte[] ReadFully(Stream stream)
        {
            byte[] buffer = new byte[32768];
            using (MemoryStream ms = new MemoryStream())
            {
                while (true)
                {
                    int read = stream.Read(buffer, 0, buffer.Length);
                    if (read <= 0)
                        return ms.ToArray();
                    ms.Write(buffer, 0, read);
                }
            }
        }

        [HttpPost]
        public ActionResult Login(UserModel usermodel)
        {
            var user = usersDbContext.Users.Where(u => u.Username == usermodel.Username && u.Password == usermodel.Password).FirstOrDefault();
            if (user != null)
            {
                //FormsAuthentication.SetAuthCookie(usermodel.Username, true);
                var authTicket = new FormsAuthenticationTicket(1, usermodel.Username, DateTime.Now, DateTime.Now.AddMinutes(5), true, Newtonsoft.Json.JsonConvert.SerializeObject(user));
                var authToken = FormsAuthentication.Encrypt(authTicket);
                var authCookies = new HttpCookie(FormsAuthentication.FormsCookieName, authToken);
                Response.Cookies.Add(authCookies);

                return RedirectToAction("Index");
            }
            return View(usermodel);
        }


        public ActionResult Index()
        {
            //string filePath = @"C:\Users\itluser\Desktop\New folder\SIN MING AVE -FINAL2.xlsx";
            string filePath = @"C:\Users\itluser\Desktop\sin ming  december report1.xlsx";
            UploadExcelDataToDB uploadExcelDataToDB = new UploadExcelDataToDB();
            uploadExcelDataToDB.ReadExcelData(filePath);




            // var user = usersDbContext.Users.Where(i=>i.Username)

            //IEnumerable<Student> emp = monkeyDBEntities.Students;
            //IQueryable<Student> student = monkeyDBEntities.Students;

            // var stud = emp.Where(i => i.StudentID == 1).ToList();
            //IEnumerable<Student> s = student.Where(i => i.StudentID == 1).ToList();
            // var rMethod = Request.HttpMethod;
            return View("Index");
        }

        public ActionResult GetAttendanceReportPdf(string attendancemonth, string attendanceyear)
        {
            PdfClass pdfClass = new PdfClass();

            var attendanceMemoryStream = pdfClass.GetAttendanceReportPdf(attendancemonth, attendanceyear);

            string strPDFFileName = string.Format("Staff Attendance" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".pdf");
            string strAttachment = Server.MapPath("~/Downloads/" + strPDFFileName);
            return File(attendanceMemoryStream, "application/pdf", strPDFFileName);
        }
        //[Route(Name = "about")]
        //[CustAuthorizeAttribute(_groups = "Read")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "ContactView";
            ViewData["message"] = "messageData";
            return View("Contact");
        }
    }
}