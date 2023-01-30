using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Ado_CRUD.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ado_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration) {
            _configuration = configuration;
        }

        // GET: api/<CustomerController>
        [Route("getAllCustomers")]
        [HttpGet]
        public List<Customer> Get()
        {
            List<Customer> customerList = new List<Customer>();

            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("select * from Customer", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            for(int i = 0; i < dt.Rows.Count; i++)
            {
                Customer customer = new Customer();
                customer.UserId = (int)dt.Rows[i]["UserId"];
                customer.Username = dt.Rows[i]["Username"].ToString();
                customer.Email = dt.Rows[i]["Email"].ToString();
                customer.FirstName = dt.Rows[i]["FirstName"].ToString();
                customer.LastName = dt.Rows[i]["LastName"].ToString();
                customer.CreateOn = dt.Rows[i]["CreateOn"].ToString();
                customer.IsActive = (bool)dt.Rows[i]["IsActive"];
                customerList.Add(customer);
            }

            return customerList;
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public Customer? Get(int id)
        {

            Customer customer = new Customer();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "Select * from Customer where UserId=" + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    customer.UserId = Convert.ToInt32(dr["UserId"]);
                    customer.Username = dr["Username"].ToString();
                    customer.Email = dr["Email"].ToString();
                    customer.FirstName = dr["FirstName"].ToString();
                    customer.LastName = dr["LastName"].ToString();
                    customer.CreateOn = dr["CreateOn"].ToString();
                    customer.IsActive = (bool)dr["IsActive"];
                }
            }

            return customer;
        }

        // GET api/<CustomerController>/5
        [Route("getCustomerRelatedData/{id}")]
        [HttpGet]
        public List<CustomerRelatedData> GetCustomerRelatedData(int id)
        {

            List<CustomerRelatedData> customerRelatedDataList = new List<CustomerRelatedData>();

            using (SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                SqlCommand cmd = new SqlCommand("sp_getAllcustomerRelatedData", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    CustomerRelatedData customerRelatedData = new CustomerRelatedData();

                    customerRelatedData.UserId = Convert.ToInt32(rdr["UserId"]);
                    customerRelatedData.Username = rdr["Username"].ToString();
                    customerRelatedData.Email = rdr["Email"].ToString();
                    customerRelatedData.FirstName = rdr["FirstName"].ToString();
                    customerRelatedData.LastName = rdr["LastName"].ToString();
                    customerRelatedData.CreateOn = rdr["CreateOn"].ToString();
                    customerRelatedData.IsActive = (bool)rdr["IsActive"];
                    customerRelatedData.OrderId = Convert.ToInt32(rdr["OrderId"]);
                    customerRelatedData.ProductId = Convert.ToInt32(rdr["ProductId"]);
                    customerRelatedData.OrderStatus = Convert.ToInt32(rdr["OrderStatus"]);
                    customerRelatedData.OrderType = Convert.ToInt32(rdr["OrderType"]);
                    customerRelatedData.OrderBy = Convert.ToInt32(rdr["OrderBy"]);
                    customerRelatedData.OrderedOn = rdr["OrderedOn"].ToString();
                    customerRelatedData.SippedOn = rdr["SippedOn"].ToString();
                    customerRelatedData.ProductName = rdr["ProductName"].ToString();
                    customerRelatedData.UnitPrice = (decimal)rdr["UnitPrice"];
                    customerRelatedData.SupplierId = Convert.ToInt32(rdr["SupplierId"]);
                    customerRelatedData.CreatedOn = (DateTime)rdr["CreatedOn"];
                    customerRelatedData.SupplierName = rdr["SupplierName"].ToString();

                    customerRelatedDataList.Add(customerRelatedData);
                }

                con.Close();
            }
            return customerRelatedDataList;
        }

        // POST api/<CustomerController>
        [HttpPost]
        public string Post([FromBody] Customer customer)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("insert into Customer values('"+ customer.Username+ "','" + customer.Email + "','" + customer.FirstName + "','" + customer.LastName + "','" + customer.CreateOn + "','" + customer.IsActive + "')", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Customer Added Successfully";
        }

        // PUT api/<CustomerController>/5
        [Route("updateSpecificCustomer/{id}")]
        [HttpPut]
        public string Put(int id, [FromBody] Customer customer)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("update Customer set Username='" + customer.Username + "',Email='" + customer.Email + "',FirstName='" + customer.FirstName + "',LastName='" + customer.LastName + "',CreateOn='" + customer.CreateOn + "',IsActive='" + customer.IsActive + "' where UserId=" + id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Customer Updated Successfully";
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            SqlCommand cmd = new SqlCommand("delete from Customer where UserId="+id, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return "Customer Deleted Successfully";
        }
    }
}
