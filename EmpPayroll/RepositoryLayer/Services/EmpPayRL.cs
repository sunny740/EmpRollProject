using CommanLayer.ResponsiveModel;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Services
{
    public class EmpPayRL: IEmpPayRL
    {
        static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmpRegistrations;Integrated Security=True";
        static SqlConnection sqlConnection = new SqlConnection(connectionString);

        public void EstablishConnection()
        {
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    sqlConnection.Open();
                    Console.WriteLine("Connection is Open");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    sqlConnection.Close();
                    Console.WriteLine("Connection is closed");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public EmpPayDetail InsertEmployeeData(EmpPayDetail employee)
        {
            try
            {
                List<EmpPayDetail> list = new List<EmpPayDetail>();
                using (sqlConnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("InsertEmployeeDetails", sqlConnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@ID", employee.ID);
                    sqlCommand.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    sqlCommand.Parameters.AddWithValue("@Image", employee.Image);
                    sqlCommand.Parameters.AddWithValue("@Gender", employee.Gender);
                    sqlCommand.Parameters.AddWithValue("@Salary", employee.Salary);
                    sqlCommand.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    sqlCommand.Parameters.AddWithValue("@Department", employee.Department);
                    sqlCommand.Parameters.AddWithValue("@Notes", employee.Notes);
                    var returnParameter = sqlCommand.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    //list.Add(employee);
                    //Console.WriteLine(address.FirstName + "," + address.LastName + "," + address.Address + "," + address.City + "," + address.State + ","
                    //       + address.Zip + "," + address.PhoneNumber + "," + address.Email);
                    sqlConnection.Open();
                    int i = sqlCommand.ExecuteNonQuery();
                    sqlConnection.Close();
                    if (i >= 1)
                    {

                        return employee;

                    }
                    return null;

                    //var result = sqlCommand.ExecuteNonQuery();
                    //sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        //update salary
        public EmpPayDetail UpdateDetail(EmpPayDetail employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("UpdateEmpDetail", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    command.Parameters.AddWithValue("@EmpName", employee.EmpName);
                    command.Parameters.AddWithValue("@Image", employee.Image);
                    command.Parameters.AddWithValue("@Gender", employee.Gender);
                    command.Parameters.AddWithValue("@Department", employee.Department);
                    command.Parameters.AddWithValue("@Salary", employee.Salary);
                    command.Parameters.AddWithValue("@StartDate", employee.StartDate);
                    command.Parameters.AddWithValue("@Notes", employee.Notes);

                    employee = new EmpPayDetail();
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    return employee;
                    //connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return employee;
            }
        }
        public EmpPayDetail RemoveDetails(EmpPayDetail employee)
        {
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spDeletePersonById", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", employee.ID);
                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employee;
        }
        EmpPayDetail IEmpPayRL.Getdetails(EmpPayDetail employee)
        {
            throw new NotImplementedException();
        }
        public EmpPayDetail Getdetails(EmpPayDetail employee)
        {
            List<EmpPayDetail> list = new List<EmpPayDetail>();
            EmpPayDetail employee1 = new EmpPayDetail();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("spViewContacts", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            employee.ID = reader.GetInt32(0);
                            employee.EmpName = reader.GetString(1);
                            employee.Image = reader.GetString(2);
                            employee.Gender = reader.GetString(3);
                            employee.Department = reader.GetString(4);
                            employee.Salary = reader.GetInt64(5);
                            employee.StartDate = reader.GetDateTime(6);
                            employee.Notes = reader.GetString(7);

                            list.Add(employee);
                            Console.WriteLine(employee.ID + "," + employee.EmpName + "," + employee.Image + "," + employee.Gender + ","
                                + employee.Department + "," + employee.Salary + "," + employee.StartDate + "," + employee.Notes);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return employee;
        }
    }
}
