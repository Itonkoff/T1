using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Contexts;
using Api.Models;
using Api.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Api.Repositories.StudentRepository {
    public class StudentRepository : Repository<Student>, IStudentRepository {
        public StudentRepository(DatabaseContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await DatabaseContext.Student
                .Include(s => s.AcademicLevel)
                .Include(s => s.Program)
                .Include(s => s.User)
                .ToListAsync();
        }

        public Task<Student> GetStudentByIdAsync(int id)
        {
            return DatabaseContext.Student
                .Include(s => s.AcademicLevel)
                .Include(s => s.Program)
                .Include(s => s.User)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        public Task<Student> GetStudentByRefAsync(Guid regNumber)
        {
            return DatabaseContext.Student
                .Include(s => s.AcademicLevelNavigation)
                .Include(s => s.StudentProgramNavigation)
                .SingleOrDefaultAsync(a =>
                    a.RegNumber.ToString().Equals(regNumber.ToString())
                );
        }

        private DatabaseContext DatabaseContext
        {
            get { return Context as DatabaseContext; }
        }
    }
}