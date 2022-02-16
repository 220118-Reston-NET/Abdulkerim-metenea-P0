using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using storeBL;
using storeModel;

namespace StoreAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      private ICustomerBL _custBL;
      public CustomerController(ICustomerBL p_custBL)
      {
          _custBL = p_custBL;
      }        
      // GET: api/Customer
        [HttpGet("(GetAll)")]
        public IActionResult GetAllCustomer()
        {
            try
            {
                return Ok(_custBL.GetAllCustomer());
            }
            catch(SqlException)
            {
                return NotFound();
            }
        }

        // GET: api/Customer/5
        [HttpGet("{CustomerName}")]
        public IActionResult GetCustomerByName( string Name)
        {
            try
            {
                return Ok(_custBL.SearchCustomer(Name));
            }
            catch (SqlException)
            {
                return NotFound();
            }
        }

        // POST: api/Customer
        [HttpPost("Add")]
        public IActionResult Post([FromBody] Customer p_cust)
        {
             try
             {
                 return Created("Scuccessfully Added", _custBL.AddCustomer(p_cust));
             }
             catch (System.Exception ex)
             {
                 
                 return Conflict(ex.Message);
             }
        }

        // PUT: api/Customer/5
        [HttpPut("Update/{id}")]
        // public IActionResult Put(int id, [FromBody] Customer p_cust)
        // {
        //     p_cust.CustID = id;
        //     try
        //     {
        //         return OK(_custBL.UpdateCustomer(p_cust));
        //     }
        //     catch (System.Exception ex)
        //     {
                
        //         return Conflict(ex.Message);
        //     }

        // }

        // DELETE: api/Customer/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
