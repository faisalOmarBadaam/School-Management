using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Models
{
    public class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public string Phone { get; set; }

        public int? DepartmentID { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
