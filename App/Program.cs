﻿using Database.Contracts;
using Database.Database;
using Database.Decorators;
using Database.Models;

IInMemoryDatabase database = new InMemoryDatabase();

database = new LoggingDecorator(database);
database = new ErrorReporterDecorator(database);
var statistics = new Statistics();
database = new StatisticsDecorator(database, statistics);

var user1 = new User { Id = 1, FullName = "Bruce Wayne", Address = "123 Gotham", Salary = 50000 };
var user2 = new User { Id = 2, FullName = "Frodo Baggins", Address = "456 The Shire", Salary = 60000 };

database.AddUser(user1);
database.AddUser(user2);
database.AddIndex("FullName");

var users = database.GetUsersByIndexedColumn("FullName", "Bruce Wayne");

Console.WriteLine($"Found {users.Count} users with FullName 'Bruce Wayne'");

foreach (var entry in statistics.MethodDurations)
{
    Console.WriteLine($"{entry.Key} took {entry.Value.TotalMilliseconds} ms");
}
