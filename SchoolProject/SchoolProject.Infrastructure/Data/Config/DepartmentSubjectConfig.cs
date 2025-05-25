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
    internal class DepartmentSubjectConfig : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.ToTable("DepartmentSubject");
            builder.HasKey(x => x.Id);



            builder.HasOne(x => x.Subject).WithMany(x => x.DepartmentSubjects).HasForeignKey(x => x.SubjectID);
            builder.HasOne(x => x.Department).WithMany(x => x.DepartmentSubjects).HasForeignKey(x => x.DepartmentID);
        }
    }
}
