using BussinessLayer.Interface;
using CommanLayer.ResponsiveModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLayer.Services
{
    public class EmpPayBL: IEmpPayBL
    {
        IEmpPayRL emppayrl;
        public EmpPayBL(IEmpPayRL emppayrl)
        {
            this.emppayrl = emppayrl;
        }
        public EmpPayDetail Register(EmpPayDetail employee)
        {
            try
            {
                return emppayrl.InsertEmployeeData(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpPayDetail Update(EmpPayDetail employee)
        {
            try
            {
                return emppayrl.UpdateDetail(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpPayDetail Remove(EmpPayDetail employee)
        {
            try
            {
                return emppayrl.RemoveDetails(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public EmpPayDetail Get(EmpPayDetail employee)
        {
            try
            {
                return emppayrl.Getdetails(employee);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}