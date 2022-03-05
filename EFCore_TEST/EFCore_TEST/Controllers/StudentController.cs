using EFCore_TEST.Data;
using EFCore_TEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_TEST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly EFContext _context;

        public StudentController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Student> GetAll()
        {
            return _context.Students.ToList();
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            var tmp_grade = student.CurrentGradeId;
            var temp = _context.Grades.FirstOrDefault(t => t.GradeId == tmp_grade);

            temp.Students.Add(student);
            _context.Students.Add(student);
            _context.SaveChanges();
            
            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);

        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(long id)
        {
            var item = _context.Students.FirstOrDefault(t => t.Id == id);
            if (item == null)
            {
                return NotFound();
            }
            var temp = _context.Grades.FirstOrDefault(t => t.GradeId == item.CurrentGradeId);
            return new ObjectResult(item);
        }
        /*
        private readonly IConfiguration _configuration;
        public StudentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select Id, Name, CurrentGradeId from efcoremysql.students
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Student student)
        {
            string query = @"
                        insert into efcoremysql.students (Name, CurrentGradeId) values (@Name, @CurrentGradeId);
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@Name", student.Name);
                    myCommand.Parameters.AddWithValue("@CurrentGradeId", student.CurrentGradeId);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }
        */
    }
}
