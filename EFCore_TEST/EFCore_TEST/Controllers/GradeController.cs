using EFCore_TEST.Data;
using EFCore_TEST.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class GradeController : ControllerBase
    {
        private readonly EFContext _context;

        public GradeController(EFContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Grade> GetAll()
        {
            return _context.Grades.ToList();
        }

        [HttpPost]
        public IActionResult AddGrade([FromBody] Grade grade)
        {
            if (grade == null)
            {
                return BadRequest();
            }

            _context.Grades.Add(grade);
            _context.SaveChanges();

            return CreatedAtRoute("GetGrade", new { id = grade.GradeId }, grade);

        }

        [HttpGet("{id}", Name = "GetGrade")]
        public IActionResult GetById(long id)
        {
            var item = _context.Grades.FirstOrDefault(t => t.GradeId == id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
        /*
        public IActionResult Create([FromBody] TodoItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.TodoItems.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }
        */
        /*
        private readonly IConfiguration _configuration;
        public GradeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Grades>>


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select GradeId, GradeName, Section from efcoremysql.grades
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
        public JsonResult Post(Grade grade)
        {
            string query = @"
                        insert into efcoremysql.grades (GradeId, GradeName, Section) values (@GradeId, @GradeName, @Section);
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Default");
            MySqlDataReader myReader;
            using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@GradeId", grade.GradeId);
                    myCommand.Parameters.AddWithValue("@GradeName", grade.GradeName);
                    myCommand.Parameters.AddWithValue("@Section", grade.Section);
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
