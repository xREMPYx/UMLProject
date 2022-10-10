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
            if (relation == RelationType.Association)
                return new Association(box);

            return new Association(box);
        }
    }
}
