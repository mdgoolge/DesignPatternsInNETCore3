using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }
    public class Person
    {
        public string Name;
        // DoB and other useful properties here
    }
    //public class Relationships // low-level
    //{
    //    public List<(Person, Relationship, Person)> Relations
    //    = new List<(Person, Relationship, Person)>();
    //    public void AddParentAndChild(Person parent, Person child)
    //    {
    //        Relations.Add((parent, Relationship.Parent, child));
    //        Relations.Add((child, Relationship.Child, parent));
    //    }
    //}

    public class Relationships : IRelationshipBrowser // low-level
    {
        // no longer public!
        private List<(Person, Relationship, Person)> relations
        = new List<(Person, Relationship, Person)>();
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            return relations
            .Where(x => x.Item1.Name == name
            && x.Item2 == Relationship.Parent)
            .Select(r => r.Item3);
        }
    }
}
