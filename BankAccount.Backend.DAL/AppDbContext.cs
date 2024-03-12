﻿using BankAccount.Backend.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Backend.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<ClientEntity> Clients { get; set; }
        public DbSet<PhisycalUserEntity> PhisycalUsers { get; set; }
        public DbSet<TypeListUserEntity> TypeListUsers { get; set; }
        public DbSet<LegalUserEntity> LegalUsers { get; set; }  
        public DbSet<AccountEntity> Accounts { get; set; } 
        public DbSet<ListAccountEntity> ListAccounts { get; set; } 
        public DbSet<PaymentEntity> Payments { get; set; } 

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<CourseEntity>()
        //        .HasMany(t => t.Students)
        //        .WithMany(t => t.Courses)
        //        .UsingEntity(j => j.ToTable("CoursesUsers"));
        //}
    }
}
