using CommanLayer.ResponsiveModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Interface
{
    public interface IEmpPayRL
    {
        public EmpPayDetail InsertEmployeeData(EmpPayDetail employee);
        public EmpPayDetail UpdateDetail(EmpPayDetail employee);
        public EmpPayDetail RemoveDetails(EmpPayDetail employee);
        public EmpPayDetail Getdetails(EmpPayDetail employee);
    }
}
