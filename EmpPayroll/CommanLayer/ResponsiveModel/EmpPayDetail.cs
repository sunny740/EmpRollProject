using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommanLayer.ResponsiveModel
{
    public class EmpPayDetail
    {
        public int ID { get; set; }
        public string EmpName { get; set; }
        public string Image { get; set; }
        public string Gender { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
