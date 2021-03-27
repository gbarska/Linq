using System.IO;
using System.ComponentModel;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;

namespace Gbarska.Course.Linq
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("LINQ Grouping Data!");

      //create extension method ToCsv & ordering asc
      Console.WriteLine(GetSimpleGroupByExample().ToJsonString());
      Console.WriteLine(GetPeopleByAgeExample().ToJsonString());
      Console.WriteLine(GetPeopleByAgeNamesExample().ToJsonString());
    }
    public static IEnumerable<IGrouping<string, Person>> GetSimpleGroupByExample()
    {
      var people = GetPeople();

      //specific Linq interface IGrouping it reminds a dictionary but has its own details
      IEnumerable<IGrouping<string, Person>> byName = people.GroupBy(p => p.Name);

      return byName;
    }
    public static IEnumerable<IGrouping<Boolean, Person>> GetPeopleByAgeExample()
    {
      var people = GetPeople();
      //the return will be two groups one with key: true and other with key: false
      return people.GroupBy(p => p.Age > 30);
    }

    public static IEnumerable<IGrouping<int, string>> GetPeopleByAgeNamesExample()
    {
      var people = GetPeople();
      //the key => ages
      //the comparer => name
      var byAge = people.GroupBy(p => p.Age, p => p.Name);

      foreach (var group in byAge)
      {
        Console.WriteLine($"These people are {group.Key} years old:");
        foreach (var personName in group)
          Console.WriteLine($" - {personName}");
      }
      return byAge;
    }
    public static List<Person> GetPeople()
    {
      return new List<Person>{
          new Person { Name = "Adam", Age = 20 },
          new Person{ Name = "Adam", Age = 36 },
          new Person { Name = "Boris", Age = 18 },
          new Person { Name = "Claire", Age = 36 },
          new Person { Name = "Adam", Age = 20 }, // dup
          new Person { Name = "Jack", Age = 20 }
        };
    }
    public class Person
    {
      public string Name;
      public int Age;
    }
  }
}
public static class CourseLinqExtensions
{
  public static string ToJsonString(this IEnumerable enumerable)
  {
    Console.WriteLine("----------");
    return $"{JsonConvert.SerializeObject(enumerable, Formatting.Indented)}\n----------\n";
  }

  public static string ToCsvString(this IEnumerable<int> numbers)
  {
    return string.Join(",", numbers.Select(v => v.ToString()).ToArray());
  }
}
