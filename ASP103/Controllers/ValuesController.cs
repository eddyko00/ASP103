﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ASP103.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        internal class Product
        {
            public String Name;
            public DateTime ExpiryDate;
            public float Price;

        }
        // GET api/values

        [HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        public ActionResult<string> Get()
        {
            Product product = new Product();

            product.Name = "Working...";
            product.ExpiryDate = new DateTime(2008, 12, 28);
            product.Price = 3.99F;

            String objString = JsonConvert.SerializeObject(product);
            Product idObj = JsonConvert.DeserializeObject<Product>(objString);
            //string[] stReturn = new string[] { objString };
            return objString;
        }


        // GET /api/values/11?sqlcmd=SELECT * FROM customer
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id, string sqlcmd)
        {


            if (id == 11) // SELECT
            {
                if (sqlcmd != null)
                {
                    return Program.SelectSQLCmd(sqlcmd, 0); // no json
                }
            }
            else if (id == 1) // SELECTT
            {
                if (sqlcmd != null)
                {
                    return Program.SelectSQLCmd(sqlcmd, 1); // with json
                }
            }
            else if (id == 22) // INSERT
            {
                if (sqlcmd != null)
                {
                    return Program.InsertSQLCmd(sqlcmd);
                }
            }
            else if (id == 33) // UPDATE
            {
                if (sqlcmd != null)
                {
                    return Program.UpdateSQLCmd(sqlcmd);
                }
            }
            else if (id == 44) // Execute
            {
                if (sqlcmd != null)
                {
                    return Program.ExecuteSQLCmd(sqlcmd);
                }
            }
            return "ERROR";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


}

