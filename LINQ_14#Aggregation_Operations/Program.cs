using System.IO;
using System.ComponentModel;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Collections;
using Newtonsoft.Json;
using System.Drawing;

namespace Gbarska.Course.Linq
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine("Linq Aggregation Operations!");

      //dangerous operation, Count iterates over the whole collection
      //it  shouldn't be used with endless collections
      Console.WriteLine("The numbers count: " + GetSimpleCountExample());
      GetSimpleAverageSumExample();
      Console.WriteLine(GetSimpleStringAggregateExample());
      GetSimpleRectangleAggregateExample();

    }

    public static int GetSimpleCountExample()
    {
      var numbers = Enumerable.Range(1, 10);
      return numbers.Count();
    }

    public static void GetSimpleAverageSumExample()
    {
      var numbers = Enumerable.Range(1, 10);

      Console.WriteLine("Sum = " + numbers.Sum());
      Console.WriteLine("Average = " + numbers.Average());
    }

    public static string GetSimpleStringAggregateExample()
    {
      var words = new[] { "one", "two", "three" };
      return words.Aggregate("hello", (p, x) => p + "," + x);
    }

    public static void GetSimpleRectangleAggregateExample()
    {
      var rectangles = new[] {
        new Rectangle(0,0,20,20),
        new Rectangle(20,20,60,60),
        new Rectangle(80,80,20,20)
      };
      Console.WriteLine(rectangles.Aggregate(Rectangle.Union));
    }

  }
  public static class CourseLinqExtensions
  {
    public static string ToJsonString(this IEnumerable enumerable)
    {
      Console.WriteLine("----------");
      return $"{JsonConvert.SerializeObject(enumerable, Formatting.Indented)}\n----------\n";
    }
    public static IEnumerable<T> Prepend<T>(this IEnumerable<T> values, T value)
    {
      yield return value;
      foreach (var item in values)
      {
        yield return item;
      }
    }

    public static string ToCsvString(this IEnumerable<int> numbers)
    {
      return string.Join(",", numbers.Select(v => v.ToString()).ToArray());
    }
  }
}