using System;
using LanternUniversity.Models;
using LanternUniversity.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LanternUniversity.Controllers
{
    [Route("api/[controller]")]
    public class EnrolmentsController : Controller
    {
        readonly IRepository<Student> studentsRepository;
        readonly IRepository<Subject> subjectRepository;

        public EnrolmentsController(IRepository<Student> studentsRepository,
                                    IRepository<Subject> subjectRepository)
        {
            this.studentsRepository = studentsRepository;
            this.subjectRepository = subjectRepository;
        }

        // POST api/values
        [HttpPost]
        public void Post(Guid studentId, Guid subjectId)
        {
            var student = studentsRepository.Get(studentId);
            var subject = subjectRepository.Get(subjectId);
            //TODO: Return correct status codes when not found

            if(EnrolmentService.CanStudentEnrolInSubject(student, subject))
            {
                subject.AddStudent(student);
                student.AddSubject(subject);
            }
                
        }


    }
}
