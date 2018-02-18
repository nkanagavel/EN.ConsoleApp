using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EN.ConsoleApp.Model
{
    public class StationResponse
    {
        public List<Station> Result { get; set; }
        public string ErrorMessage { get; set; }
        public Guid Id { get; set; }
        public int Code { get; set; }
    }
    
}
