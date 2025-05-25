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
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.ToTable("Department");
            builder.HasKey(x => x.Id);


            builder.Property(x => x.Name).HasMaxLength(50).IsUnicode(true);

            builder.HasMany(x => x.Students).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentID);
            builder.HasMany(x => x.DepartmentSubjects).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentID);


        }
    }
}
