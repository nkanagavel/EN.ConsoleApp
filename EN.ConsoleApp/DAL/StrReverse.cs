using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.DAL
{
    public class StrReverse
    {
        List<int> data = new List<int> { 10, 20, 30, 40, 50, 50 };
        public StrReverse()
        {

        }

        public string ReverseString(string inputString)
        {
            StringBuilder sbuilder = new StringBuilder();

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                sbuilder.Append(inputString[i]);
            }
            return sbuilder.ToString();
        }

        public void SingleSingleOrDefaultFirstFirstOrDefault()
        {
            try
            {

                //Single 

                var SingleResult = data.Single(i => i == 10);
                var SingleResult1 = data.Single(i => i == 50);


                //SingleOrDefault
                var SingleOrDefaultResult = data.SingleOrDefault(i => i == 10);
                var SingleOrDefaultResult1 = data.SingleOrDefault(i => i == 50);
                var SingleOrDefaultResult2 = data.SingleOrDefault(i => i == 60);

                //First
                var FirstResult = data.First(i => i == 10);
                var FirstResult1 = data.First(i => i == 50);
                var FirstResult2 = data.First(i => i == 60);


                //FirstOrDefault
                var FirstOrDefaultResult = data.FirstOrDefault(i => i == 10);
                var FirstOrDefaultResult1 = data.FirstOrDefault(i => i == 50);
                var FirstOrDefaultResult2 = data.FirstOrDefault(i => i == 60);


            }
            catch (Exception ex)
            {

            }
        }
    }
}
