using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EN.ConsoleApp.DAL;
using EN.ConsoleApp.Model;

namespace EN.ConsoleApp
{
    public delegate double DelegateExample(int number);
    class Program
    {
        // delegate <return type> <delegate-name> <parameter list>

        static void Main(string[] args)
        {
            Derived devived = new Derived(10);

            StrReverse obj = new StrReverse();
            string inputstring = string.Empty;

            //emailModule emailModule = new emailModule();
            //emailModule.ConnectToExchangeServer();

            CSharpFeatures cSharpFeatures = new CSharpFeatures();
            delegateExamples delegateExObj = new delegateExamples();

            List<string> operationList = new List<string>();

            operationList.Add("1. Reverse the string.");
            operationList.Add("2. Find the given string is palindrome.");
            operationList.Add("3. Difference b/n Select() and SelectMany() and Select & Where");
            operationList.Add("4. Expression Bodied Methods");
            operationList.Add("5. Auto-Property Initializers");
            operationList.Add("6. Conditional Access Operator");
            operationList.Add("7. String Interpolation");
            operationList.Add("8. Delegates");
            operationList.Add("9. Get First Letters of a string");
            operationList.Add("10. Single, SingleOrDefault, First and FirstOrDefault");
            operationList.Add("11. Polymorphism");
            operationList.Add("12. Read Excel file");
            operationList.Add("13. EF-CodeFirst");
            operationList.Add("14. Oops - Abstract and Interface.");
            operationList.Add("15. Oops - Polymorphism.");
            operationList.Add("16. Oops - Polymorphism.");
            //Oops WhereSelect


            foreach (var operation in operationList)
            {
                Console.WriteLine(operation.ToString());
            }

            Console.WriteLine("Choose your Option --); ");

            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the String to be reversed.");
                    inputstring = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputstring))
                        Console.WriteLine($"Reversed String : {obj.ReverseString(inputstring)}");

                    else
                        Console.WriteLine("Please enter the String to be reversed.");
                    Console.ReadKey();
                    break;

                case 2:
                    Console.WriteLine("Enter the String to verify whether its palindrome.");
                    inputstring = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(inputstring))
                    {
                        string ouputString = obj.ReverseString(inputstring);

                        if (ouputString == inputstring)
                            Console.WriteLine($"The string : {inputstring} is Palindrome.");
                        else
                            Console.WriteLine($"The string : {inputstring} is not Palindrome.");
                    }
                    else
                        Console.WriteLine("Please enter the String to be reversed.");
                    Console.ReadKey();
                    break;
                case 3:
                    LinqQ linq = new LinqQ();
                    linq.CheckMissingNumber();
                    linq.WhereSelect();
                    linq.CheckSelectAndSelectMany();
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine("Enter Employee Id to Find.");
                    inputstring = Console.ReadLine();
                    var skills = cSharpFeatures.GetSkillByEmployeeId(Convert.ToInt32(inputstring));
                    Console.WriteLine($"Skills for Employee Id {Convert.ToInt32(inputstring)} is {string.Join(",", skills)} ");
                    Console.ReadKey();
                    Main(null);
                    break;
                case 5:
                    var lastName = cSharpFeatures.LastName;
                    Console.WriteLine($"Auto-Property Initializer value for LastName {lastName} ");
                    Console.ReadKey();
                    Main(null);
                    break;
                case 6:
                    Console.WriteLine("Enter Employee Id to Find.");
                    inputstring = Console.ReadLine();
                    var employeeName = cSharpFeatures.GetEmployeeNameById(Convert.ToInt32(inputstring));
                    Console.WriteLine($"Conditional Access Operator {employeeName} ");
                    Console.ReadKey();
                    Main(null);
                    break;
                case 7:
                    var fullName = cSharpFeatures.GetFullName();
                    Console.WriteLine($"String-Interpolation {fullName} ");
                    Console.ReadKey();
                    Main(null);
                    break;
                case 8:
                    DelegateExample delegateEx = delegateExObj.SumValue;
                    var sum = delegateEx(2);
                    Console.WriteLine($"Sum On Delegate : {Convert.ToString(sum)}");
                    DelegateExample delegateEx1 = new DelegateExample(delegateExObj.Muliply);
                    var multiply = delegateEx1(10);
                    Console.WriteLine($"Sum On Delegate : {Convert.ToString(multiply)}");

                    Console.ReadKey();
                    Main(null);
                    break;

                case 9:
                    var firstLetters = cSharpFeatures.GetFirstLetters();
                    Console.WriteLine($"First Letters:- {firstLetters} ");
                    Console.ReadKey();
                    Main(null);
                    break;
                case 10:
                    obj.SingleSingleOrDefaultFirstFirstOrDefault();
                    Console.ReadKey();
                    Main(null);
                    break;
                case 11:
                    Polymorphism polymorphism = new Polymorphism();
                    polymorphism.Area(20);
                    Console.WriteLine("Polymorphism-Area-Two Parameters - {0}", polymorphism.Area(20, 30));
                    Console.ReadKey();
                    Main(null);
                    break;
                case 12:
                    TestClass testClass = new TestClass();
                    testClass.GetExcelData();
                    Console.WriteLine("Polymorphism-Area-Two Parameters - {0}", 1);
                    Console.ReadKey();
                    Main(null);
                    break;
                case 13:
                    EFCodeFirst efCodeFirst = new EFCodeFirst();
                    efCodeFirst.InsertData();
                    break;
                case 14:
                    AbstractInterface abstractInterface = new AbstractInterface();
                    abstractInterface.NonAbstarctFun();
                    abstractInterface.AbstractFun();
                    abstractInterface.InterfaceFun1();
                    Console.ReadKey();
                    Main(null);
                    break;
                case 15:
                    DapperClass dapperClass = new DapperClass();
                    Console.WriteLine($"Command Text : Employee Ids : {dapperClass.GetEmployeeIdTextCommand()}");
                    Console.WriteLine($"SP : Employee Ids : {dapperClass.GetEmployeeIdSP()}");
                    //Console.WriteLine(dapperClass.InsertDepartmentSP());
                    //Console.WriteLine(dapperClass.InsertEmployeeSP());
                    //Console.WriteLine(dapperClass.InsertDepartmentComText());
                    Console.WriteLine(dapperClass.InsertEmployeeComText());
                    dapperClass.GetEmployees();
                    Console.ReadKey();
                    Main(null);
                    break;
                default:
                    Console.WriteLine("Default case");
                    Console.ReadKey();
                    break;


            }

        }


    }
}
