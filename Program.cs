using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
}

class Program
{
    static void Main()
    {
        // Create a list of persons
        var persons = new List<Person>
        {
            new Person { FirstName = "John", LastName = "Doe", Age = 30 },
            new Person { FirstName = "Jane", LastName = "Smith", Age = 25 }
        };

        // Serialize the list to JSON
        var json = JsonSerializer.Serialize(persons);

        // Specify the file path where you want to save the JSON data
        var filePath = @"rr.json";

        // Write the JSON data to the file
        File.WriteAllText(filePath, json);

        // Read the JSON data from the file
        var jsonFromFile = File.ReadAllText(filePath);

        // Deserialize the JSON data back to a list of persons
        var personsFromFile = JsonSerializer.Deserialize<List<Person>>(jsonFromFile);

        // Now you can work with the list of persons
        foreach (var person in personsFromFile)
        {
            Console.WriteLine($"Name: {person.FirstName} {person.LastName}, Age: {person.Age}");
        }
    }
}
