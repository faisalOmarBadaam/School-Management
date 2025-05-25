using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Models
{
    public class StudentSubject
    {
        public int Id { get; set; }
        public int StudentID { get; set; }

        public int SubjectID {  get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
