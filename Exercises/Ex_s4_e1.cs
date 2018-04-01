/*
Series 4: Polymorphism

Exercise 1: Design a database connection
To access a database, we need to open a connection to it first and close it once our job is done.
Connecting to a database depends on the type of the target database and the database
management system (DBMS). For example, connecting to a SQL Server database is different
from connecting to an Oracle database. But both these connections have a few things in
common:
• They have a connection string
• They can be opened
• They can be closed
• They may have a timeout attribute (so if the connection could not be opened within the
timeout, an exception will be thrown).
Your job is to represent these commonalities in a base class called DbConnection. This class
should have two properties:
ConnectionString : string
Timeout : TimeSpan
A DbConnection will not be in a valid state if it doesn’t have a connection string. So you need to
pass a connection string in the constructor of this class. Also, take into account the scenarios
where null or an empty string is sent as the connection string. Make sure to throw an exception
to guarantee that your class will always be in a valid state.
Our DbConnection should also have two methods for opening and closing a connection. We
don’t know how to open or close a connection in a DbConnection and this should be left to the
classes that derive from DbConnection. These classes (eg SqlConnection or OracleConnection)
will provide the actual implementation. So you need to declare these methods as abstract.
Derive two classes SqlConnection and OracleConnection from DbConnection and provide a
simple implementation of opening and closing connections using Console.WriteLine(). In the
real-world, SQL Server provides an API for opening or closing a connection to a database. But
for this exercise, we don’t need to worry about it.

*/

using System;
using System.Collections;
using System.Collections.Generic;

namespace ExercisesPolymorphism 
{
    public abstract class DbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        // ctor with a string param -> will NOT be passed to derived classes
        public DbConnection(string conString)
        {
            this.ConnectionString = conString;
        }

        // abstract methods for opening and closing DB
        public abstract void OpenDb();
        public abstract void CloseDb();

    }

    // dervied class from DbConnection
    public class SqlConnection : DbConnection
    {
        // ctor with link
        public SqlConnection(string conString) : base(conString)
        {
            this.ConnectionString = conString;
        }

        // override OpenDb
        public override void OpenDb()
        {
        Console.WriteLine("Open SQL DB: {0}", this.ConnectionString);         
        }

        // override CloseDb
        public override void CloseDb()
        {
        Console.WriteLine("Close SQL DB: {0}", this.ConnectionString);         
        }

    }

    // dervied class from DbConnection
    public class OracleConnection : DbConnection
    {
        // ctor with link
        public OracleConnection(string conString) : base(conString)
        {
            this.ConnectionString = conString;
        } 

        // override OpenDb
        public override void OpenDb()
        {
        Console.WriteLine("Open Orcale DB: {0}", this.ConnectionString);

        }

        // override CloseDb
        public override void CloseDb()
        {
        Console.WriteLine("Close Oracle DB: {0}", this.ConnectionString);         
        }

    }


    class Program 
    {
        static void Main (string[] args) 
        {
            var oracle = new OracleConnection("Oracle string.");
            var sequel = new SqlConnection("Sequel string.");

            oracle.OpenDb();
            oracle.CloseDb();

            sequel.OpenDb();
            sequel.CloseDb();

        }
    }
}