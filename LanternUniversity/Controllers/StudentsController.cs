using System;
using System.Collections.Generic;
using LanternUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanternUniversity.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IRepository<Student> _repository;

        public StudentsController(IRepository<Student> repository)
        {
            _repository = repository;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Student Get(Guid id)
        {
            var student = _repository.Get(id);
            //TODO: Return correct status codes
            return student;
        }

        // POST api/students
        [HttpPost]
        public void Post(Student student) //Would use a view model in reality
        {
            //TODO: Validation
            _repository.Add(student);
        }

    }
}