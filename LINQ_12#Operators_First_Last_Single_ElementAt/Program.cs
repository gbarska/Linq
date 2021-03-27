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
      Console.WriteLine("Linq Operators: First, Last, ElementAt!");

      GetSimpleSequenceEqualExample();
    }

    public static void GetSimpleSequenceEqualExample()
    {
      // first: returns first element satisfying a predicate or throws
      var numbers = new List<int> { 1, 2, 3 };

      Console.WriteLine("First element:" + numbers.First());
      //throws exceptions if not element satisfies the condition
      Console.WriteLine("First element greater than 2: " + numbers.First(x => x > 2)); // try 10
      //no exception
      Console.WriteLine("First or default greater than 10:" + numbers.FirstOrDefault(x => x > 10)); // string - null

      // same for last value
      Console.WriteLine("Last element:" + numbers.Last());
      Console.WriteLine("Last smaller than 3: " + numbers.Last(x => x < 3));

      // single: ensures that there's only one value, otherwise throws
      // throws because non-singular
      Console.WriteLine("Single:" + numbers.Single(x => x == 1));

      // also throws
      // Console.WriteLine(numbers.SingleOrDefault());

      // doesn't throw only if sequence is empty
      Console.WriteLine("Empty array: " + new int[] { }.SingleOrDefault());

      Console.WriteLine("Item at position 1: " + numbers.ElementAt(1));
      Console.WriteLine("Item at position 4: " + numbers.ElementAtOrDefault(4));
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
