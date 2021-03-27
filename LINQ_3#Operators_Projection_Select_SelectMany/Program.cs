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
      Console.WriteLine("LINQ Projection Operators!");

      //echo squared sequence
      Console.WriteLine(GetSelectSquareExample().ToJsonString());

      //echo the lenght of the words of the phrase
      Console.WriteLine(GetSelectStringSplitExample().ToJsonString());

      Console.WriteLine(GetGenerateRandomValuesSelectExample().ToJsonString());

      Console.WriteLine(GetStringsSplitSelectManyExample().ToJsonString());

      Console.WriteLine(GetCombineMultipleCollectionSelectManyExample().ToJsonString());

    }

    public static IEnumerable<int> GetSelectSquareExample()
    {
      var numbers = Enumerable.Range(1, 4);
      //square each number..
      return numbers.Select(x => x * x);
    }
    public static IEnumerable<object> GetSelectStringSplitExample()
          => "This is a nice sentence".Split().Select(w => new { Word = w, Size = w.Length });

    public static IEnumerable<int> GetGenerateRandomValuesSelectExample()
    {
      Random rand = new Random();
      //we don't care to the iterated value this time so we are not using it
      //i only want to perform the task n times where n is the size of the collection..
      return Enumerable.Range(1, 10).Select(_ => rand.Next(10));
    }

    public static IEnumerable<string> GetStringsSplitSelectManyExample()
    {
      var sequences = new[] { "red,blue,green", "orange", "white, pink" };

      // the code below would return a collection with 3 string[] as a result of applying a split
      // var allWords = sequences.Select(str => str.Split(','));

      //now with the SelectMany the collection is merged into a simple IEnumerable<string>
      //because the operator flattens the arrays to strings
      var allWords = sequences.SelectMany(str => str.Split(','));

      return allWords;
    }
    public static IEnumerable<object> GetCombineMultipleCollectionSelectManyExample()
    {
      string[] objects = { "house", "car", "bicycle" };
      string[] colors = { "red", "blue", "green" };

      var pairs = colors.SelectMany(_ => objects, (color, obj) => new { Color = color, Obj = obj });
      return pairs;
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