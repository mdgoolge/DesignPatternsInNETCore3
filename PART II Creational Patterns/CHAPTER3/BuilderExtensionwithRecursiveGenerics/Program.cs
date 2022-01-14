using System;

namespace BuilderExtensionwithRecursiveGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //var me = Person.New
 //           var me = new PersonInfoBuilder()
 //.Called("Dmitri") // returns PersonInfoBuilder
 //.WorksAsA("Quant") // will not compile
 //.Build();
        }
    }
    public class Person
    {
        public string Name;
        public string Position;
    }
    public abstract class PersonBuilder
    {
        protected Person person = new Person();
        public Person Build()
        {
            return person;
        }
    }
    public class PersonInfoBuilder : PersonBuilder
    {
        public PersonInfoBuilder Called(string name)
        {
            person.Name = name;
            return this;
        }
    }
    public class PersonJobBuilder : PersonInfoBuilder
    {
        public PersonJobBuilder WorksAsA(string position)
        {
            person.Position = position;
            return this;
        }
    }
    public class PersonInfoBuilder<SELF> : PersonBuilder
where SELF : PersonInfoBuilder<SELF>
    {
        public SELF Called(string name)
        {
            person.Name = name;
            return (SELF)this;
        }
    }
}
