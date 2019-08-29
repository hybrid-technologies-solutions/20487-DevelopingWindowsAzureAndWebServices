using System;
using System.Data.Entity;
using System.Linq;
using EF_CodeFirst.Infra;

namespace EF_CodeFirst
{
    class Program
    {
        static string ConnectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Database=Module_02_Demos;Integrated Security=True";
        static void Main(string[] args)
        {
            // Initializing the database and populating seed data using DropCreateDatabaseIfModelChanges initializer
            (new DropCreateDBOnModelChanged()).InitializeDatabase(new SchoolContext(ConnectionString));

            // Creating a SchoolContext to be used to access data

            // Getting the courses list from the database

            // Writing the courses list to the console

            // For each course, writing the students list to the console

            // Waiting for user input before closing the console window
        }
    }
}
