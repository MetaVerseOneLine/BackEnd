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
