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
      Console.WriteLine("LINQ Filtering Operators!");

      //filter only evenNumbers.
      Console.WriteLine(GetFilteringExample().ToJsonString());
      //projection(Select) + filtering (where)
      Console.WriteLine(GetProjectionWithFilteringExample().ToJsonString());

      Console.WriteLine(GetOfTypeFilteringExample().ToJsonString());

    }
    public static IEnumerable<int> GetFilteringExample()
    {
      var numbers = Enumerable.Range(1, 10);
      var evenNumbers = numbers.Where(number => number % 2 == 0);

      return evenNumbers;
    }
    public static IEnumerable<int> GetProjectionWithFilteringExample()
    {
      var numbers = Enumerable.Range(1, 10);
      var oddNumbers = numbers.Select(number => number * number).Where(number => number % 2 != 0);

      return oddNumbers;
    }

    public static IEnumerable<float> GetOfTypeFilteringExample()
    {
      object[] values = { 1, 2.5f, 3, 4.56f };
      return values.OfType<float>();
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
}