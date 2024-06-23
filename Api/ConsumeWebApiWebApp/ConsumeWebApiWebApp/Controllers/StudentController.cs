using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;//to make this app client  so that we can request from
using ConsumeWebApiWebApp.Models;
using Microsoft.Ajax.Utilities;

namespace ConsumeWebApiWebApp.Controllers
{
    public class StudentController : Controller
    {//very important with respect to exams also to get data
        // GET: Student
        [HttpGet]
        public ActionResult AllStudents()
        {
            IEnumerable<Student> slist=null;
            //Ratta lagana hai is code ka
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/Student/StuGet");
                var resptask =client.GetAsync("StuGet");
                resptask.Wait();
                var result=resptask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask=result.Content.ReadAsAsync<IList<Student>>();
                    readTask.Wait();
                    slist= readTask.Result; 

                }
            }

                return View(slist);
        }
        [HttpGet]
        public ActionResult SaveStudent()
        {

            return View();
        }
        //Paper question must consume API code jo form sy data ly ge post ka code jo api k through data save krny k liye use hota hai
        [HttpPost]
        public ActionResult SaveStudent(Student s)
        {
            using (var client=new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/Student/PostStudent");
                var resp = client.PostAsJsonAsync<Student>("PostStudent",s);
                resp.Wait();
                var result=resp.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllStudents");

                }
                return View(s);
            }

                
        }
        //Consume API mn consume client aaye ga
        [HttpGet]

        public ActionResult Details(int id)
        {
            Student s= new Student();
            //Ratta lagana hai is code ka
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/Student/StuGet");
                var resptask = client.GetAsync("StuGet?id="+id);
                resptask.Wait();
                var result = resptask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Student>();
                    readTask.Wait();
                   s = readTask.Result;

                }
            }

            return View(s);

        }
        [HttpGet]
        public ActionResult Delete(int id) 
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/Student/Delete");
                var deletetask = client.DeleteAsync("Delete/" + id.ToString());
                deletetask.Wait();
                var result = deletetask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("AllStudents");

                }

                return View();
               
            }
        }
        public ActionResult Edit(int id)
        {
            Student s = new Student();
            //Ratta lagana hai is code ka
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44378/api/Student/StuGet");
                var resptask = client.GetAsync("StuGet?id=" + id);
                resptask.Wait();
                var result = resptask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Student>();
                    readTask.Wait();
                    s = readTask.Result;

                }
            }

            return View(s);

        }

    }
}