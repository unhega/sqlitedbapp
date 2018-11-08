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
        DbSet<Price> Prices {get; set;}

        // protected override void OnModelCreating(ModelBuilder modelBuilder){
        //     modelBuilder.Entity<Price>()
        //         .HasKey( c => c.Id);
        // }

    }
}