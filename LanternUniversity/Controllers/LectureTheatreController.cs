using System;
using System.Collections.Generic;
using LanternUniversity.Models;
using Microsoft.AspNetCore.Mvc;

namespace LanternUniversity.Controllers
{
    [Route("api/[controller]")]
    public class LectureTheatreController : Controller
    {
        private readonly IRepository<LectureTheatre> _repository;

        public LectureTheatreController(IRepository<LectureTheatre> repository)
        {
            _repository = repository;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<LectureTheatre> Get()
        {
            return _repository.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public LectureTheatre Get(Guid id)
        {
            var lectureTheatre = _repository.Get(id);
            //TODO: Return correct status codes
            return lectureTheatre;
        }

        // POST api/students
        [HttpPost]
        public void Post(LectureTheatre lectureTheatre) //Would use a view model in reality
        {
            //TODO: Validation
            _repository.Add(lectureTheatre);
        }

    }
}