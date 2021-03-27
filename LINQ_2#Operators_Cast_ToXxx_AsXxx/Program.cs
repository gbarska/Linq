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
      var lista = new List<string>() { "my", "hello", "world" };

      Console.WriteLine("LINQ Operators!");

      //applies the Average operators ...
      Console.WriteLine(GetCastEnumerableExample().ToJsonString());

      //show usage of ToList(), ToDictionary, ToArray() to materialize the enumerable
      Console.WriteLine(GetMaterializedCollectionExample().ToJsonString());

      //AsEnumerable()
      Console.WriteLine(GetAsEnumerableExample().ToJsonString());

    }

    public static IEnumerable<int> GetAsEnumerableExample()
    {
      //every array is an IEnumerable by definition, and can applied in operators like Where, Select an so on
      var arr = new[] { 1, 2, 3 };

      //if we must return an IEnumerable<int> instance we must convert it with the AsEnumerable()..
      //cannot return the arr directly, can only return after converting
      return arr.AsEnumerable();

    }
    public static Dictionary<double, bool> GetMaterializedCollectionExample()
    {
      var numbers = Enumerable.Range(1, 10);
      var array = numbers.ToArray();
      var list = numbers.ToList();
      var dictionary = numbers.ToDictionary(i => (double)i / 10, i => i % 2 == 0);
      return dictionary;
    }
    public static IEnumerable<int> GetCastEnumerableExample()
    {
      //arrayList old implementation from  c# 1 for collections..
      var lista = new ArrayList();
      lista.Add(1);
      lista.Add(2);
      lista.Add(3);
      lista.Add(4);

      //converts each value inside the ArrayList and creates an enumerable result
      //that can be used with the others operators normally.
      return lista.Cast<int>();
    }

  }
  public static class CourseLinqExtensions
  {
    public static string ToJsonString(this IEnumerable enumerable) => JsonConvert.SerializeObject(enumerable, Formatting.Indented);
  }

}
