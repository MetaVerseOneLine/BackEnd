using EFCore_TEST.Data;
using EFCore_TEST.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_TEST.Repositories
{
    public class GradeRepository : IGradeRepository
    {
        private readonly EFContext _context;

        public GradeRepository(EFContext context)
        {
            _context = context;
        }
        public async Task<Grade> Create(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return grade;
        }

        public async Task Delete(int id)
        {
            var gradeToDelete = await _context.Grades.FindAsync(id);
            _context.Grades.Remove(gradeToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Grade>> Get()
        {
            return await _context.Grades.ToListAsync();
        }

        public async Task<IEnumerable<Student>> Get(int id)
        {
            return await _context.Students.Where(b => b.CurrentGradeId == id).ToListAsync();
        }

        public async Task Update(Grade grade)
        {
            _context.Entry(grade).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
