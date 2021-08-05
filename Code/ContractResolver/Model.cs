using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.ContractResolver
{
    public class Model
    {
        public string Description { get; set; }
        public string Value { get; set; }
        public string Price { get; set; }
        public Model2 Model2 { get; set; }
    }

    public class Model2 
    {
        public string Value { get; set; }
        public string Description { get; set; }
    }
}
