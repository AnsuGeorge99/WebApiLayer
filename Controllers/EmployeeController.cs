using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using WebApiLayer.Models;

namespace WebApiLayer.Controllers
{
    public class EmployeeController : ApiController
    {
        //api/employee
        public IEnumerable<Employee> Get()
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            return db.EmployeeT.ToList();
        }

        //api/employee/id
        public Employee Get(int id)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            return db.EmployeeT.FirstOrDefault(x => x.Id.Equals(id));
        }
        //create
        public HttpResponseMessage Post([FromBody] Employee em)
        {
            HttpResponseMessage response;
            try
            {
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    db.EmployeeT.Add(em);
                    db.SaveChanges();
                }
                response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }                          
        }

        //edit
        public HttpResponseMessage Put([FromBody] Employee emp)
        {
            HttpResponseMessage response;
            try
            {               
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    var data = db.EmployeeT.FirstOrDefault(x => x.Id.Equals(emp.Id));
                    if (data != null)
                    {
                        data.Id = emp.Id;
                        data.Name = emp.Name;
                        data.Designation = emp.Designation;
                        data.Salary = emp.Salary;
                        db.SaveChanges();
                    }                  
                }
                response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }
            catch 
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return response;
            }
        }

        //delete
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EmployeeDbContext db = new EmployeeDbContext())
                {
                    var data = db.EmployeeT.FirstOrDefault(x => x.Id.Equals(id));
                    if(data != null)
                    {
                        db.EmployeeT.Remove(data);
                    }
                }
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.OK);
                return resp;
            }
            catch
            {
                HttpResponseMessage resp = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                return resp;
            }

        }
    }
}