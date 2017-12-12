using System.Linq;
using LanternUniversity.Controllers;
using LanternUniversity.Models;
using Xunit;

namespace LanternUniversity.UnitTests.Controllers
{
    public class StudentsControllerTests
    {
        StudentsController _sut;

        [Fact]
        public void Post_Should_AddStudentToCollection()
        {
            var sc = new InMemoryRepository<Student>();

            _sut = new StudentsController(sc);
            var student = new Student { FirstName = "Luke", LastName = "Spice" };

            _sut.Post(student);

            Assert.Equal(1, sc.GetAll().Count);
            Assert.Equal(student, sc.GetAll().First());
        }
    }
}
