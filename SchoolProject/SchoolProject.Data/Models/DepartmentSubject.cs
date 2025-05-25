using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Models
{
    public class DepartmentSubject
    {
        public int Id { get; set; }

        public int SubjectID { get; set; }  

        public int DepartmentID { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual Department Department { get; set; }
    }
}
