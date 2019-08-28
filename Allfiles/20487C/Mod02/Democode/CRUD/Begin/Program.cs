using System;
using System.Data.Entity;
using System.Linq;
using EF_CodeFirst.Infra;
using System.Data.SqlClient;
using EF_CodeFirst.Model;
using System.Collections.Generic;

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

            // Getting the WCF Course from the courses repository

            // Creating two new students

            // Adding the students to the WCF course

            // Giving the course teacher a 1000$ raise

            // Getting a student called Student_1

            // Remove a student from the WCF course

            // Print the course details to the console
        }

    }
}

