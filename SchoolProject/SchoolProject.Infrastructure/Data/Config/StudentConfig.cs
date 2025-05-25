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
    internal class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Student");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode(true);

            builder.Property(x=>x.Address).HasMaxLength(50).IsUnicode(true);

            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.HasIndex(x => x.Phone).IsUnique();

            builder.HasOne(x=>x.Department).WithMany(x=>x.Students).HasForeignKey(x=>x.DepartmentID);
            builder.HasMany(x => x.StudentSubjects).WithOne(x => x.Student).HasForeignKey(x => x.StudentID);

        }
    }
}
