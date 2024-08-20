using CRUDAppUsingADO.Models;
using CRUDAppUsingADO.Utility;
using System.Data.SqlClient;
using System.Data;



namespace CRUDAppUsingADO.DAL
{
    public class Employee_DataAccessLayer
    {
        //assing and initialised variable
        string cs = ConnectionString.dbcs;

        //We need on method which give all the data in return from the database 
        //here return type is "List" Type data
        public List<Employees> getAllEmployee()
        {


            List<Employees> Emplist = new List<Employees>();


            using (SqlConnection con = new SqlConnection(cs))
            {
                //to execute querry and command we need sqlCommand 
                //sqlCommand is command used for to create Query and Communicate to the Database
                SqlCommand cmd = new SqlCommand("spGetAllEmployee", con);

                //Here is CommandTyoe is Comming from 
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {


                    Employees emp = new Employees();

                    emp.Id = Convert.ToInt32(Reader["Id"]);
                    emp.Name = Reader["name"].ToString() ?? "";
                    emp.Gender = Reader["gender"].ToString() ?? "";
                    emp.Age = Convert.ToInt32(Reader["age"]);
                    emp.Designation = Reader["designation"].ToString() ?? "";
                    emp.City = Reader["city"].ToString() ?? "";



                    Emplist.Add(emp);
                }

            }
            return Emplist;

        }
        public Employees getEmployeesById(int? id)
        {
            Employees emp = new Employees();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("select * from employees where id=@id", con);

                //Here is CommandTyoe is Comming from 
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                SqlDataReader Reader = cmd.ExecuteReader();

                while (Reader.Read())
                {

                    emp.Id = Convert.ToInt32(Reader["id"]);
                    emp.Name = Reader["name"].ToString() ?? "Empty Value - Assign some Value";
                    emp.Gender = Reader["gender"].ToString() ?? "Empty Value - Assign some Value";
                    emp.Age = Convert.ToInt32(Reader["age"]);
                    emp.Designation = Reader["designation"].ToString() ?? "Empty Value - Assign some Value";
                    emp.City = Reader["city"].ToString() ?? "Empty Value - Assign some Value";

                }
                return emp;
            }
        }





        public void AddEmployee(Employees e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);

                //Here is CommandTyoe is Comming from 
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", e.Name);
                cmd.Parameters.AddWithValue("@gender", e.Gender);
                cmd.Parameters.AddWithValue("@age", e.Age);
                cmd.Parameters.AddWithValue("@designation", e.Designation);
                cmd.Parameters.AddWithValue("@city", e.City);
                con.Open();
                cmd.ExecuteNonQuery();


            }
        }


        public void UpdateEmployee(Employees e)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);

                //Here is CommandTyoe is Comming from 
                cmd.CommandType = CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", e.Id);
                cmd.Parameters.AddWithValue("@name", e.Name);
                cmd.Parameters.AddWithValue("@gender", e.Gender);
                cmd.Parameters.AddWithValue("@age", e.Age);
                cmd.Parameters.AddWithValue("@designation", e.Designation);
                cmd.Parameters.AddWithValue("@city", e.City);
                con.Open();
                cmd.ExecuteNonQuery();


            }
        }
    
        public void DeleteEmployee(int? id)
        {
            using (SqlConnection con=new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);

                //Here is CommandTyoe is Comming from 
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id",id);
                con.Open( );    
                cmd.ExecuteNonQuery();
            }
        }
    
    
    }

}
