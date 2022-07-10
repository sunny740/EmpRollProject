using CommanLayer.ResponsiveModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Interface
{
    public interface IEmpPayBL
    {
        public EmpPayDetail Register(EmpPayDetail employee);
        public EmpPayDetail Update(EmpPayDetail employee);
        public EmpPayDetail Remove(EmpPayDetail employee);
        public EmpPayDetail Get(EmpPayDetail employee);
    }
}