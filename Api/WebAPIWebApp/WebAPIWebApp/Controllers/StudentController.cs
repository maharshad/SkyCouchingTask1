using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPIWebApp.Controllers
{
    public class StudentController : ApiController
    {
        StuFeeDBEntities1 obj=new StuFeeDBEntities1();

        [HttpGet]
        public IHttpActionResult StuGet()
        {
            return Ok(obj.Students.ToList());
        }
        [HttpGet]
        public IHttpActionResult StuGet(int id)
        {
            return Ok((obj.Students.Where(i=>i.rollno==id).FirstOrDefault()));
        }
        [HttpPost]
        //localhost://api/Student/PostStudent
        
        public IHttpActionResult PostStudent([FromBody] Student s)
        {
            obj.Students.Add(s);
            obj.SaveChanges();
            return Ok("Student saved"); 
        }
        public IHttpActionResult Delete(int id)
        {
            var s = obj.Students.Where(x=> x.rollno==id).First();
            obj.Students.Remove(s);
            obj.SaveChanges();
            return Ok("Record Deleted");


        }

    }
}
