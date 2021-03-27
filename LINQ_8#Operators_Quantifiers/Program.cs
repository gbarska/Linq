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
      Console.WriteLine("Linq Operators: Quantifiers!");

      //checks whether all elements satisfy the condition 
      GetSimpleAllOperatorExample();

      //checks whether at least one element satisfies the condition 
      GetSimpleAnyOperatorExample();

      //universal way of checking whether a collection has some value
      GetSimpleContainsOperatorExample();
    }

    public static void GetSimpleAllOperatorExample()
    {
      int[] numbers = { 1, 2, 3, 4, 5 };
      Console.WriteLine("-----------");
      Console.WriteLine("Are all numbers > 0? " + numbers.All(x => x > 0));
      Console.WriteLine("Are all numbers odd? " + numbers.All(x => x % 2 == 1));
    }
    public static void GetSimpleAnyOperatorExample()
    {
      int[] numbers = { 1, 2, 3, 4, 5 };
      Console.WriteLine("-----------");
      Console.WriteLine("Any numbers < 2? " + numbers.Any(x => x < 2));
      Console.WriteLine("Any number in the collection? " + numbers.Any());
    }
    public static void GetSimpleContainsOperatorExample()
    {
      int[] numbers = { 1, 2, 3, 4, 5 };
      Console.WriteLine("-----------");
      Console.WriteLine("Contains 5? " + numbers.Contains(5));
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
