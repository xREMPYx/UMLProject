using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Relations;

namespace UMLProject.Enums
{
    public enum RelationType
    {
        Association,
        Inheritance,
        Implementation,
        Dependency,
        Aggregation,
        Composition
    }

    public static class RelationGetter
    {
        public static Relation GetRelation(RelationType relation, Box box)
        {
            Dictionary<RelationType, Relation> relations = new Dictionary<RelationType, Relation>();

            relations.Add(RelationType.Association, new Association(box));
            relations.Add(RelationType.Inheritance, new Inheritance(box));
            relations.Add(RelationType.Implementation, new Implementaion(box));
            relations.Add(RelationType.Dependency, new Dependency(box));
            relations.Add(RelationType.Aggregation, new Aggregation(box));
            relations.Add(RelationType.Composition, new Composition(box));

            return relations[relation];
        }
    }
}
