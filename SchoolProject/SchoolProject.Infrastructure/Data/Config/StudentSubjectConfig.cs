using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrastructure.Data.Config
{
    internal class StudentSubjectConfig : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {

            builder.ToTable("StudentSubject");
            builder.HasKey(x => x.Id);



            builder.HasOne(x => x.Student).WithMany(x => x.StudentSubjects).HasForeignKey(x => x.StudentID);
            builder.HasOne(x => x.Subject).WithMany(x => x.StudentSubjects).HasForeignKey(x => x.SubjectID);
        }
    }
}
