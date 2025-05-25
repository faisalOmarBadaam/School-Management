using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Models;
using SchoolProject.Infrastructure.Abstract;
using SchoolProject.Service.Abstract;
using System.Linq.Expressions;

namespace SchoolProject.Service.Services
{
    public class StudentService : IStudentService
    {
        private IGenericRepositoryAsync<Student> _Repo { get; set; }
        public StudentService(IGenericRepositoryAsync<Student> repo)
        {
            _Repo = repo;
        }



        public IQueryable<Student> GetStudentsAsync(string searchItem, string sortColumn, string sortOrder)
        {
            var AllStudent = _Repo.GetTableNoTracking();
            if (!string.IsNullOrWhiteSpace(searchItem))
            {
                AllStudent = AllStudent.Where(s => s.Name.Contains(searchItem));
            }
            var _sortColumn = _GetSortColumn(sortColumn ?? "");
            if (sortOrder == "desc")
            {
                AllStudent = AllStudent.OrderByDescending(_sortColumn);
            }
            else
            {
                AllStudent = AllStudent.OrderBy(_sortColumn);
            }

            return AllStudent;

        }

        private static Expression<Func<Student, object>> _GetSortColumn(string sortColumn)
        {
            sortColumn = sortColumn.ToLower();
            return sortColumn switch
            {
                "Name" => (student) => student.Name,
                "Address" => (student) => student.Address,
                "Department" => (studnet) => studnet.Department.Name,
                _ => (s) => s.Id
            };

        }

        public async Task<Student> GetStudentByIDAsync(int id)
        {
            return await _Repo.GetTableNoTracking().Include(x => x.Department).FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task AddAsync(Student student, CancellationToken cancellationToken)
        {

            await _Repo.AddAsync(student, cancellationToken);

        }

        public async Task<bool> CheckIfNameExistAsync(string name, CancellationToken cancellationToken, int? id)
        {
            return await _Repo.GetTableNoTracking().AnyAsync(x => x.Name == name && x.Id != id, cancellationToken);
        }

        public async Task<bool> CheckIfPhoneExistAsync(string Phonenumber, CancellationToken cancellationToken, int? id)
        {
            return await _Repo.GetTableNoTracking().AnyAsync(x => x.Phone == Phonenumber && x.Id != id, cancellationToken);
        }

        public async Task UpdateAsync(Student student)
        {
            await _Repo.UpdateAsync(student);
        }

        public async Task DeleteAsync(Student Student)
        {
            await _Repo.DeleteAsync(Student);
        }


    }
}