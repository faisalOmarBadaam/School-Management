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
    internal class SubjectConfig : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.ToTable("Subject");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode(true);

           

            builder.HasMany(x => x.StudentSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectID);
            builder.HasMany(x => x.DepartmentSubjects).WithOne(x => x.Subject).HasForeignKey(x => x.SubjectID);




        }
    }
}
