using System.Linq;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Gbarska.Course.Linq
{
  class Program
  {
    static void Main(string[] args)
    {
      var lista = new List<string>() { "my", "hello", "world" };

      Console.WriteLine("LINQ Generations Operations!");

      //regular list
      Console.WriteLine(lista.ToJsonString());
      //empty
      Console.WriteLine(Enumerable.Empty<int>().ToJsonString());
      //repeat the content n times
      Console.WriteLine(Enumerable.Repeat("hello", 3).ToJsonString());
      //gives u a range of numbers..
      Console.WriteLine(Enumerable.Range(1, 10).ToJsonString());
      //gives all the letters from a to z
      Console.WriteLine(Enumerable.Range('a', 'z' - 'a').Select(c => (char)c).ToJsonString());
      //gives a sequence of char 'x'
      Console.WriteLine(Enumerable.Range(1, 10).Select(i => new string('x', i)).ToJsonString());

    }

  }
  public static class CourseLinqExtensions
  {
    public static string ToJsonString<T>(this IEnumerable<T> enumerable) => JsonConvert.SerializeObject(enumerable, Formatting.Indented);
  }

}
