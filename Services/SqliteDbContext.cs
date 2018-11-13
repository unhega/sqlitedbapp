using System;
// using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using sqlitedbapp.Models;

namespace sqlitedbapp.Services
{
    public class SqliteDbContext: DbContext
    {
        string dbname;
        public SqliteDbContext(DbContextOptions options):base(options){

        }
        public DbSet<Price> Prices {get; set;}
        public DbSet<Session> Sessions {get; set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Price>()
        //         .HasKey( c => c.Id);
        // }

    }
}