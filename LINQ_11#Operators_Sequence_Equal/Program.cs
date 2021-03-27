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
      Console.WriteLine("Linq Operators: Sequence Equal!");

      GetSimpleSequenceEqualExample();
    }

    public static void GetSimpleSequenceEqualExample()
    {
      var arr1 = new[] { 1, 2, 3 };
      var arr2 = new[] { 1, 2, 3 };

      // LINQ
      Console.WriteLine(arr1.SequenceEqual(arr2));

      var list1 = new List<int> { 1, 2, 3 };
      Console.WriteLine(arr1.SequenceEqual(list1));
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
