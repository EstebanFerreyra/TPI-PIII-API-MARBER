﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Models;
using System;
using System.Collections.Generic;

namespace Models.Models.Configurations
{
    public partial class UsersConfiguration : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> entity)
        {
            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.IdRole).HasColumnName("id_Role");

            entity.Property(e => e.UserEmail)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("userEmail");

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("userName");

            entity.Property(e => e.UserPassword)
                .IsRequired()
                .HasMaxLength(250)
                .HasColumnName("userPassword");

            entity.HasOne(d => d.IdRoleNavigation)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__id_Role__4316F928");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Users> entity);
    }
}