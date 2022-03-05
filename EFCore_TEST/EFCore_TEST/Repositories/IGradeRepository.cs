using EFCore_TEST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_TEST.Repositories
{
    public interface IGradeRepository
    {
        Task<IEnumerable<Grade>> Get();
        Task<IEnumerable<Student>> Get(int id);
        Task<Grade> Create(Grade grade);
        Task Update(Grade grade);
        Task Delete(int id);

    }
}
