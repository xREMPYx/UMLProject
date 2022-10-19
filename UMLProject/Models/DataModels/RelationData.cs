using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Relations;

namespace UMLProject.Models.DataModels
{
    public class RelationData
    {
        public RelationType Type { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int MidX { get; set; }
        public int MidY { get; set; }
        public int EndX { get; set; }
        public int EndY { get; set; }
        public bool IsModified { get; set; }
        public string FromName { get; set; }
        public string ToName { get; set; }
        public string FromText { get; set; } = String.Empty;
        public string ToText { get; set; } = String.Empty;

        public RelationData()
        {

        }

        public RelationData(Relation relation)
        {
            this.Type = relation.Type;
            this.StartX = relation.StartX;
            this.StartY = relation.StartY;
            this.MidX = relation.MidX;
            this.MidY = relation.MidY;
            this.EndX = relation.EndX;
            this.EndY = relation.EndY;
            this.FromName = relation.From.Name;
            this.ToName = relation.To.Name;
            this.FromText = relation.FromText;
            this.ToText = relation.ToText;
            this.IsModified = relation.IsModified;                        
        }
    }
}
