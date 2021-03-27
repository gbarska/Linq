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
      Console.WriteLine("LINQ Sorting Operators!");

      //create extension method ToCsv & ordering asc
      Console.WriteLine(GetOrderByExample().ToCsvString());
      Console.WriteLine(GetOrderByDescExample().ToCsvString());

      Console.WriteLine(GetOrderByWithObjects().ToJsonString());

      Console.WriteLine(GetReverseStringExample().ToJsonString());

    }
    public static IEnumerable<int> GetOrderByExample()
    {
      var rand = new Random();
      var randomValues = Enumerable.Range(1, 10).Select(_ => rand.Next(10) - 5);

      //order asc
      return randomValues.OrderBy(x => x);
    }

    public static IEnumerable<int> GetOrderByDescExample()
    {
      var rand = new Random();
      var randomValues = Enumerable.Range(1, 10).Select(_ => rand.Next(10) - 5);

      //order desc
      return randomValues.OrderByDescending(x => x);
    }

    public static string GetReverseStringExample()
    {
      return new string("this is a test".Reverse().ToArray());
    }
    public static IEnumerable<Person> GetOrderByWithObjects()
    {
      var people = new List<Person>
        {
          new Person{ Name = "Adam", Age = 36 },
          new Person { Name = "Boris", Age = 18 },
          new Person { Name = "Claire", Age = 36 },
          new Person { Name = "Adam", Age = 20 },
          new Person { Name = "Jack", Age = 20 }
        };

      //we can apply order by multiple times because it returns 
      //IOrderedEnumerable and the next times we can use the Then..
      //too work in a already ordered collection;
      return people.OrderBy(p => p.Age)
            .ThenByDescending(p => p.Name);

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
