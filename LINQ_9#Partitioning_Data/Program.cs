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
      Console.WriteLine("Linq Partitioning Data!");

      //the idea of partitioning is that given a stream of data we might want to ignore
      //some of items and process the others for example

      Console.WriteLine(GetSimpleSkipTakeExample().ToJsonString());

      //skips elements while the condition is true then stop skipping
      Console.WriteLine(GetSimpleSkipWhileExample().ToJsonString());

      //stop the stream of data after the condition is reached
      Console.WriteLine(GetSimpleTakeWhileExample().ToJsonString());
    }

    public static IEnumerable<int> GetSimpleSkipTakeExample()
    {
      var numbers = new[] { 3, 3, 2, 2, 1, 1, 2, 2, 3, 3 };

      //skip => bypass 
      //take => maximum elements (no problem to pass more items here than available in the 
      //collection)
      return numbers.Skip(2).Take(6);
    }
    public static IEnumerable<int> GetSimpleSkipWhileExample()
    {
      var numbers = new[] { 3, 3, 2, 2, 1, 1, 2, 2, 3, 3 };

      return numbers.SkipWhile(i => i == 3);
    }
    public static IEnumerable<int> GetSimpleTakeWhileExample()
    {
      var numbers = new[] { 3, 3, 2, 2, 1, 1, 2, 2, 3, 3 };

      return numbers.TakeWhile(i => i > 1);
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
