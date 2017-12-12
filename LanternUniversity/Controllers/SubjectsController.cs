using System;
using System.Collections.Generic;
using LanternUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanternUniversity.Controllers
{
    [Route("api/[controller]")]
    public class SubjectsController : Controller
    {
        private readonly IRepository<Subject> _repository;

        public SubjectsController(IRepository<Subject> repository)
        {
            _repository = repository;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Subject Get(Guid id)
        {
            var student = _repository.Get(id);
            //TODO: Return correct status codes
            return student;
        }

        // POST api/students
        [HttpPost]
        public void Post(Subject student) //Would use a view model in reality
        {
            //TODO: Validation
            _repository.Add(student);
        }

    }
}