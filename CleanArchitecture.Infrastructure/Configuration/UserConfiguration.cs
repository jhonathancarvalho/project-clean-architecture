using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.OwnsOne(u => u.Email, email =>
            {
                email.Property(e => e.Address)
                     .HasColumnName("Email") 
                     .IsRequired()
                     .HasMaxLength(255);
            });
        }
    }
}