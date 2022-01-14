using System;
using System.Collections.Generic;
using System.Linq;

namespace LazyFunctionalBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new PersonBuilder()
.Called("Dmitri")
.WorksAs("Programmer")
.Born(new DateTime(1981, 1, 1))
.Build();//.Build1();
            Console.WriteLine(person);
        }
    }
    public class Person
    {
        public string Name, Position; public DateTime DateOfBirth;
        public override string ToString()
        {
            return $"{nameof(Name)}:{Name },{nameof(Position)}:{Position },{nameof(DateOfBirth)}:{DateOfBirth }";
        }
    }
    public sealed class PersonBuilder
    {
        private readonly List<Func<Person, Person>> actions =
        new List<Func<Person, Person>>();
        public PersonBuilder Do(Action<Person> action)
        => AddAction(action);
        public Person Build()
        => actions.Aggregate(new Person(), (p, f) => f(p));
        public Person Build1()
        {
            var p = new Person();
            foreach (var item in actions)
            {
                item(p);
            }
            return p;
        }
        private PersonBuilder AddAction(Action<Person> action)
        {
            actions.Add(p => { action(p); return p; });
            return this;
        }

        public PersonBuilder Called(string name)
=> Do(p => p.Name = name);
    }
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorksAs
        (this PersonBuilder builder, string position)
        => builder.Do(p => p.Position = position);
    }
    public static class PersonBuilderBirthDateExtensions
    {
        public static PersonBuilder Born
        (this PersonBuilder builder, DateTime dateOfBirth)
        => builder.Do(p => p.DateOfBirth = dateOfBirth);
    }
}
