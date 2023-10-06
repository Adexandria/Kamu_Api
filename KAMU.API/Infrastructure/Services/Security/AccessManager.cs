using KAMU.API.Domain.Models;
using KAMU.API.Infrastructure.Repositories.Interfaces;

namespace KAMU.API.Infrastructure.Services.Security
{
    public class AccessManager : IAccessManager
    {
        public AccessManager(ISuperAdminRepository superAdminRepository, 
            IUserInstructorRepository instructorRepository, 
            IStudentRepository studentRepository)
        {
            _superAdminRepository  = superAdminRepository;
            _studentRepository  = studentRepository;
            _instructorRepository  = instructorRepository;

        }
        public bool AuthenticateAsync(string email, string password)
        {
            object user;
            


        }


        public IUserInstructorRepository _instructorRepository;
        public IStudentRepository _studentRepository;
        public ISuperAdminRepository _superAdminRepository;
    }
}
