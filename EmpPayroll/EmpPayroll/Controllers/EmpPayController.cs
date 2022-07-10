using BussinessLayer.Interface;
using CommanLayer.ResponsiveModel;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EmpPayroll.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmpPayController : ControllerBase
    {
        IEmpPayBL emppaybl;
        public EmpPayController(IEmpPayBL emppaybl)
        {
            this.emppaybl = emppaybl;
        }

        [HttpPost("Register")]
        public ActionResult RegisterEmp(EmpPayDetail employeedetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpPayDetail employee = emppaybl.Register(employeedetail);

                    if (employee != null)
                    {
                        return this.Ok(new { success = true, message = "employee registered successfully", data = employee });
                    }
                    else return this.BadRequest(new { success = false, message = "employee registered unsuccessfull" });
                }
                else
                    throw new Exception("Model not valid");
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { success = false, exception.Message });
            }
        }

        [HttpPut("Update")]
        public ActionResult UpdateEmp(EmpPayDetail employeedetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpPayDetail employee = emppaybl.Update(employeedetail);

                    if (employee != null)
                    {
                        return this.Ok(new { success = true, message = "employee updated successfully", data = employee });
                    }
                    else return this.BadRequest(new { success = false, message = "employee updated unsuccessfull" });
                }
                else
                    throw new Exception("Model not valid");
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { success = false, exception.Message });
            }
        }

        [HttpDelete("Remove")]
        public ActionResult RemoveEmp(EmpPayDetail employeedetail)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpPayDetail employee = emppaybl.Remove(employeedetail);

                    if (employee != null)
                    {
                        return this.Ok(new { success = true, message = "employee remove successfully", data = employee });
                    }
                    else return this.BadRequest(new { success = false, message = "employee remove unsuccessfull" });
                }
                else
                    throw new Exception("Model not valid");
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { success = false, exception.Message });
            }
        }

        [HttpGet("GetDetails")]
        public ActionResult GetEmp(EmpPayDetail employeedetaill)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmpPayDetail employee = new EmpPayDetail();
                    employee = emppaybl.Get(employeedetaill);

                    if (employee != null)
                    {
                        return this.Ok(new { success = true, message = "employee get successfully", data = employee });
                    }
                    else return this.BadRequest(new { success = false, message = "employee get unsuccessfull" });
                }
                else
                    throw new Exception("Model not valid");
            }
            catch (Exception exception)
            {
                return this.BadRequest(new { success = false, exception.Message });
            }
        }
    }
}