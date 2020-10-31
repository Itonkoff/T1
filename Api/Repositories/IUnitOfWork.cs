using System;
using System.Threading.Tasks;
using Api.Repositories.StudentRepository;

namespace Api.Repositories.Base {
    public interface IUnitOfWork : IDisposable
    {
        IStudentRepository Students { get; }
        Task<int> CommitAsync();
    }
}