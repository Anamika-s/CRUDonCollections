using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDOnCollection.Models;
namespace CRUDOnCollection.Controllers
{
    public class StudentController : Controller
    {
       static  List<Student> students = null;
        public StudentController()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                     new Student() { Id = 1, Name = "Aashna", BatchCode = "DotNet", Marks = 90 },

                    new Student() { Id = 2, Name = "Priynaka", BatchCode = "DotNet", Marks = 87 },
                    new Student() { Id = 3, Name = "Tisha", BatchCode = "SAP", Marks = 98 },
                    new Student() { Id = 4, Name = "Naveen", BatchCode = "SAP", Marks = 90 },
                    new Student() { Id = 5, Name = "Siddhant", BatchCode = "DotNet", Marks = 90 },
                    new Student() { Id = 6, Name = "Vaibhav", BatchCode = "DotNet", Marks = 90 },

            };
            }
        }
        // GET: Student
        public ActionResult Index()
        {
           // ViewBag.students = students;
            return View(students);
        }
        public ActionResult GetStudentById(int? id)
        {if (id.HasValue)
            {
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                    return View(student);
                else
                    ViewBag.msg = "Student with ID do not exist";
                return View();
            }
        else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }
        }
        
        public ActionResult Create()
        {
            Student student = new Student();
            return View(student);
        }
        [HttpPost]
        public ActionResult Create(Student student)
        {
            students.Add(student);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                    return View(student);
                else
                    ViewBag.msg = "Student with ID do not exist";
                return View();
            }
            else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Edit(int id, Student student)
        {
            Student obj = students.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                foreach (var temp in students)

                {
                    if (temp.Id == obj.Id)
                    {
                        temp.BatchCode = student.BatchCode;
                        temp.Marks = student.Marks;
                        break;
                    }
                }
            }
                return RedirectToAction("Index");
            }

        public ActionResult Delete(int? id)
        {
            if (id.HasValue)
            {
                var student = students.FirstOrDefault(x => x.Id == id);
                if (student != null)
                    return View(student);
                else
                    ViewBag.msg = "Student with ID do not exist";
                return View();
            }
            else
            {
                ViewBag.msg = "Please provide ID";
                return View();
            }

        }
        [HttpPost]
        public ActionResult Delete(int id, Student student)
        {
            Student obj = students.FirstOrDefault(x => x.Id == id);
            if (obj != null)
            {
                students.Remove(obj);    
            }
            return RedirectToAction("Index");
        }

        public ActionResult Create1()
        {
            return View();
        }

        public ActionResult Index1()
        {
            return View(students);
        }
    }


}