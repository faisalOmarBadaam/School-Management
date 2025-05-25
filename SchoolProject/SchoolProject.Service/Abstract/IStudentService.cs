using SchoolProject.Data.Models;

namespace SchoolProject.Service.Abstract
{
    public interface IStudentService
    {
        public IQueryable<Student> GetStudentsAsync(string searchItem, string sortCloumn, string sortOrder);
        public Task<Student> GetStudentByIDAsync(int id);
        public Task AddAsync(Student student, CancellationToken cancellationToken);
        public Task UpdateAsync(Student student);
        public Task<bool> CheckIfNameExistAsync(string name, CancellationToken cancellationToken, int? id = null);
        public Task<bool> CheckIfPhoneExistAsync(string Phonenumber, CancellationToken cancellationToken, int? id = null);
        public Task DeleteAsync(Student student);


    }
}
