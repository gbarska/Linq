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
      Console.WriteLine("Linq Concatenation Operations!");
      Console.WriteLine(GetSimpleConcatExample().ToJsonString());
      Console.WriteLine(GetConcatWithPrependExample().ToJsonString());
    }

    public static IEnumerable<Type> GetSimpleConcatExample()
    {
      var integralTypes = new[] { typeof(int), typeof(short) };
      var fpTypes = new[] { typeof(float), typeof(double) };
      return integralTypes.Concat(fpTypes);
    }

    public static IEnumerable<Type> GetConcatWithPrependExample()
    {
      var integralTypes = new[] { typeof(int), typeof(short) };
      var fpTypes = new[] { typeof(float), typeof(double) };
      //concat always puts the sequence at the end of the collections, with the prepend extension we can put one //element at the beginning of the list instead.
      return integralTypes.Concat(fpTypes).Prepend(typeof(bool));
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
