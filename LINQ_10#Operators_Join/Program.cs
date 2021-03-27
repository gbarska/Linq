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
      Console.WriteLine("Linq Operators: Join!");

      GetSimpleJoinExample();
      GetGroupJoinExample();
    }

    public static void GetSimpleJoinExample()
    {
      var people = GetPeople();
      var records = GetRecords();

      //joins people with records and creates new object combining the data
      var query = people.Join(records,
          x => x.Email,//from table Person
          y => y.Mail,//from table Records
        (person, record) => new { Name = person.Name, SkypeId = record.SkypeId });

      Console.WriteLine("----------------");

      foreach (var item in query)
      {
        Console.WriteLine($"{item.Name} has skype ID {item.SkypeId}");
      }

    }
    public static void GetGroupJoinExample()
    {

      var people = GetPeople();
      var records = GetRecords();

      var result = people.GroupJoin(records,
          x => x.Email,
          y => y.Mail,
      (person, recs) => new
      {
        Name = person.Name,
        SkypeIds = recs.Select(r => r.SkypeId).ToArray()
      }
    );

      Console.WriteLine("----------------");
      Console.WriteLine(result.ToJsonString());

    }

    public static IEnumerable<Person> GetPeople()
    {
      return new Person[]
      {
        new Person("Jane", "jane@foo.com"),
        new Person("John", "john@foo.com"),
        new Person("Chris", string.Empty)
      };
    }
    public static IEnumerable<Record> GetRecords()
    {
      return new Record[]
      {
        new Record("jane@foo.com", "JaneAtFoo"),
        new Record("jane@foo.com", "JaneAtHome"),
        new Record("john@foo.com", "John1980")
      };
    }
  }
}

public class Person
{
  public string Name, Email;

  public Person(string name, string email)
  {
    Name = name;
    Email = email;
  }
}

class Record
{
  public string Mail, SkypeId;

  public Record(string mail, string skypeId)
  {
    Mail = mail;
    SkypeId = skypeId;
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
