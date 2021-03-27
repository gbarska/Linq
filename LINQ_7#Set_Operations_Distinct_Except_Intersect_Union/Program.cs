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
      Console.WriteLine("Linq Set Operations!");

      //gets the distinct elements in a collection
      Console.WriteLine(GetSimpleDistinctExample().ToJsonString());

      //gets only the elements that are present in both collectons
      Console.WriteLine(GetSimpleIntersectExample().ToJsonString());

      //gets the merged collection  
      Console.WriteLine(GetSimpleUnionExample().ToJsonString());
      
      //gets the elements from a single collection that are not in the other collection
      Console.WriteLine(GetSimpleExceptExample().ToJsonString());
    }

    public static IEnumerable<char> GetSimpleDistinctExample()
    {
      var word1 = "helloooo";
      var word2 = "help";

      return word1.Distinct();
    }
    public static IEnumerable<char> GetSimpleIntersectExample()
    {
      var word1 = "helloooo";
      var word2 = "help";
      return word1.Intersect(word2);
    }
    public static IEnumerable<char> GetSimpleUnionExample()
    {
      var word1 = "helloooo";
      var word2 = "help";

      return word1.Union(word2);
    }
    public static IEnumerable<char> GetSimpleExceptExample()
     {
      var word1 = "helloooo";
      var word2 = "help";

      return word1.Except(word2);
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
