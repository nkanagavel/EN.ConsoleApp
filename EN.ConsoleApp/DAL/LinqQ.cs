using EN.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    public class LinqQ
    {
        List<Employee> employees = new List<Employee>();
        public LinqQ()
        {
            employees.Add(new Employee() { EmployeeId = 1, EmployeeName = "Kanagavel", Skills = new List<string>() { "C#", "ASP.NET" } });
            employees.Add(new Employee() { EmployeeId = 2, EmployeeName = "Mithra", Skills = new List<string>() { "C#", "MVC" } });
            employees.Add(new Employee() { EmployeeId = 3, EmployeeName = "Suganya", Skills = new List<string>() { "DB", "Informatica" } });
            employees.Add(new Employee() { EmployeeId = 4, EmployeeName = "Suganya K", Skills = new List<string>() { "Informatica" } });
        }

        public void CheckSelectAndSelectMany()
        {
            var selectList = employees.Where(i => i.EmployeeId == 1).Select(e => e.Skills).ToList();
            var selectManyList = employees.Where(i => i.EmployeeId == 1).SelectMany(em => em.Skills).ToList();


            Console.WriteLine();
            var selectList1 = employees.Select(e => e.Skills).ToList();
            var selectManyList1 = employees.SelectMany(em => em.Skills).ToList();

            List<Int32> ints = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 40, 50, 51, 52, 53 };
            var yieldInt = GetData(ints).ToList();

            var skip = employees.Skip(1).ToList();
            var take = employees.Take(2).ToList();
            var skipTake = employees.Skip(1).Take(1).ToList();
            var takeSkip = employees.Take(2).Skip(1).ToList();
            var skipWhile = employees.SkipWhile(i => i.EmployeeId == 2).ToList();

            var categories = new List<Category>();
            categories.Add(new Category() { CategoryId = 1, CategoryName = "Food", ClientId = 1 });
            categories.Add(new Category() { CategoryId = 2, CategoryName = "Milk", ClientId = 1 });
            categories.Add(new Category() { CategoryId = 3, CategoryName = "Toys", ClientId = 1 });
            categories.Add(new Category() { CategoryId = 4, CategoryName = "Toys", ClientId = 2 });
            categories.Add(new Category() { CategoryId = 5, CategoryName = "Food", ClientId = 2 });
            categories.Add(new Category() { CategoryId = 6, CategoryName = "Milk", ClientId = 3 });

            var categoryValues = new List<CategoryValue>();
            categoryValues.Add(new CategoryValue() { CategoryValueId = 1, CategoryValueName = "Maggi", ClientLocationId = 1 });
            categoryValues.Add(new CategoryValue() { CategoryValueId = 2, CategoryValueName = "Avin", ClientLocationId = 3 });
            categoryValues.Add(new CategoryValue() { CategoryValueId = 3, CategoryValueName = "Bear", ClientLocationId = 4 });
            categoryValues.Add(new CategoryValue() { CategoryValueId = 4, CategoryValueName = "Avin", ClientLocationId = 1 });
            categoryValues.Add(new CategoryValue() { CategoryValueId = 5, CategoryValueName = "Maggi", ClientLocationId = 1 });
            categoryValues.Add(new CategoryValue() { CategoryValueId = 6, CategoryValueName = "Veg", ClientLocationId = 1 });

            var clientLocationmap = new List<ClientLocationMap>();
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 1, ClientLocationId = 1 });
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 1, ClientLocationId = 2 });
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 1, ClientLocationId = 3 });
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 2, ClientLocationId = 2 });
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 2, ClientLocationId = 1 });
            clientLocationmap.Add(new ClientLocationMap() { ClientId = 3, ClientLocationId = 1 });

            var result = (from cat in categories
                          join clm in clientLocationmap on cat.ClientId equals clm.ClientId
                          join catv in categoryValues on clm.ClientLocationId equals catv.ClientLocationId
                          where cat.CategoryId == 1
                          select new { cat.CategoryName, catv.CategoryValueName }).ToList();

            //  var result1 = categories.Join(clientLocationmap);

        }


        public IEnumerable<Int32> GetData(List<Int32> ints)
        {
            foreach (var i in ints)
            {
                if (i > 21)
                    yield return i;
            }
        }

        public void WhereSelect()
        {
            var select = employees.Select(i => i.EmployeeId == 1);
            var where = employees.Where(i => i.EmployeeId == 1);
            var selectQ = employees.Select(i => new { i.EmployeeId, i.EmployeeName }).ToList();
            var selectModel = employees.Select(i => new Emp { EmployeeId = i.EmployeeId, EmployeeName = i.EmployeeName }).ToList();
        }


        public void CheckMissingNumber()
        {
            var intput = Enumerable.Range(1, 100).ToList();
            intput.Remove(10);
            intput.Remove(50);
            var output = Enumerable.Range(1, 100).Except(intput).ToList();

            var inputArray = new List<int> { 1, 2, 4, 5, 7, 8, 9, 11, 15 };
            var missingArray = new List<int>();

            int startValue = inputArray[0];

            for (int i = 0; i < inputArray.Count; i++)
            {

                if (inputArray[i] == startValue)
                {
                    startValue++;
                }
                else
                {
                    missingArray.Add(startValue);
                    startValue++;
                    i--;
                }
            }

            Console.WriteLine("Missing Numbers Are:{0}", string.Join(",", missingArray));

            inputArray = new List<int> { 2, 4, 5, 7, 8, 9, 11, 15, 3 };

            inputArray = inputArray.OrderBy(x => x).ToList();
            startValue = inputArray.Min();
            var endValue = inputArray.Max();

            //start = arr[0];
            //var end = arr[arr.Count - 1];

            var missingnumbers = Enumerable.Range(startValue, endValue - startValue + 1).Except(inputArray).ToList();

            Console.WriteLine("--Using Enumerable--Missing Numbers Are:{0}", string.Join(",", missingnumbers));

            //var oInt = new List<int>();

            //for (int i = 0; i < 100; ++i)
            //{
            //    if (i + 1 != ints[i])
            //    {
            //        oInt.Add(i + 1);

            //    }
            //}
            //for (int i = 1; i <= 100; ++i)
            //{
            //    if (i != Convert.ToInt32(ints[i - 1]))
            //    {
            //        oInt.Add(i);
            //        i++;
            //    }
            //}
        }
    }


}
