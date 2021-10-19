using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;

namespace TestApi.Controllers
{
    public class ProductController : ApiController
    {
        productDBEntities dbobj = new productDBEntities();
        //Adding post request
        [HttpPost]
        public string Post(product_tbl obj)
        {
            dbobj.product_tbl.Add(obj);
            dbobj.SaveChanges();
            return "Product Added";
        }
        [HttpGet]
        public IEnumerable<product_tbl> Get() {
            return dbobj.product_tbl.ToList();
        }
        //Get Signle product

        [HttpGet]
        public product_tbl Get(int id) {
            product_tbl pro = dbobj.product_tbl.Find(id);
            return pro;
            
        }
        //update the recode
        [HttpPut]
        public string Put(int id, product_tbl product) {
            var p = dbobj.product_tbl.Find(id);
            p.name = product.name;
            p.price = product.price;
            p.quantity = product.quantity;
            p.active = product.active;
            dbobj.Entry(p).State = System.Data.Entity.EntityState.Modified;
            dbobj.SaveChanges();


            return "Product Updated";
        }
        [HttpDelete]
        public string Delete(int id) {
            var p = dbobj.product_tbl.Find(id);
            dbobj.product_tbl.Remove(p);
            dbobj.SaveChanges();
            return "Deleted";
        
        }


    }
}
