using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Training.Models;

namespace Training.Controllers
{
    public class ValuesController : ApiController
    {
        Staff_context context = new Staff_context();

        // GET api/values
        public IEnumerable<object> Get()
        {
            var query = from staff in context.Staff_details
                        join sub in context.Subhandel_Detail on staff.Staff_id equals sub.Staff_id
                        select new
                        {
                            StaffId = staff.Staff_id,
                            StaffName = staff.Staff_name,
                            StaffContact = staff.Staff_contact,
                            StaffSalary = staff.Staff_salary,
                            StaffNative = staff.Staff_native,
                            StaffYears = staff.Staff_years,
                            StaffSub = sub.Staff_sub
                        };

            return query.ToList();
        }

        /*public IEnumerable<Staff_details> Get()
        {
            return context.Staff_details.ToList();*//*.Select(s => new Staff_details
            {
                Staff_name = s.Staff_name,
                Staff_salary = s.Staff_salary,
                Staff_native = s.Staff_native,
                Staff_contact = s.Staff_contact
            }).AsEnumerable();*/
        /*var staffList = context.Staff_details
            .Select(s => new
            {
                Staff_name = s.Staff_name,
                Staff_salary = s.Staff_salary,
                Staff_native = s.Staff_native,
                Staff_contact = s.Staff_contact
            })
            .ToList();

        return staffList;*//*
    }*/


        // GET api/values/5
        public Staff_details Get(int id)
        {
            return context.Staff_details.Find(id);
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] Staff_details staff)
        {
            if (staff == null)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data. Staff object is null.");
            }

            var validator = new StaffDetailsValidator();
            var validationResult = validator.Validate(staff);

            if (!validationResult.IsValid)
            {
                // If validation fails, return a Bad Request response with validation error messages
                var errorMessages = validationResult.Errors.Select(error => error.ErrorMessage).ToList();
                return Request.CreateResponse(HttpStatusCode.BadRequest, errorMessages);
            }

            using (Staff_context dbcontext = new Staff_context())
            {
                // Add the new Staff_details object to the context
                dbcontext.Staff_details.Add(staff);
                dbcontext.SaveChanges();

                // Return a 201 Created response with the newly created staff's ID
                return Request.CreateResponse(HttpStatusCode.Created, staff.Staff_id);
            }
        }
        /* [HttpPost]
         public HttpResponseMessage Post(Subhandel_detail sub)
         {
             context.Subhandel_Detail.Add(sub);
             context.SaveChanges();
             return Request.CreateResponse(HttpStatusCode.Created, sub.Staff_id);
         }*/


        // PUT api/values/5
        [HttpPut]
        public HttpResponseMessage Put(int id, [FromBody] Staff_details staff)
        {
            using (Staff_context dbcontext = new Staff_context())
            {
                // Find the entity with the specified ID
                var entity = dbcontext.Staff_details.FirstOrDefault(e => e.Staff_id == id);

                if (entity == null)
                {
                    // If the entity with the specified ID doesn't exist, return a 404 Not Found response
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                // Update the entity with the new values
                entity.Staff_name = staff.Staff_name; // Assuming FirstName is a property of Staff_details
                entity.Staff_contact = staff.Staff_contact;   // Assuming LastName is a property of Staff_details
                entity.Staff_salary = staff.Staff_salary;
                entity.Staff_native = staff.Staff_native;// Update other properties as needed
                entity.Staff_years = staff.Staff_years;
                dbcontext.SaveChanges();

                // Return a 204 No Content response indicating success
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
        }


        // DELETE api/values/5
        public void Delete(int id)
        {
            Staff_details del = context.Staff_details.Find(id);
            context.Staff_details.Remove(del);
            context.SaveChanges();
        }
    }
}
