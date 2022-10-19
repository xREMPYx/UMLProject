using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
using UMLProject.Enums;
using UMLProject.Models;
using UMLProject.Models.DataModels;
using UMLProject.Relations;

namespace UMLProject.Utils
{
    public class DataService
    {
        private PaintingArea area { get; set; }
        public DataService(PaintingArea area)
        {
            this.area = area;            
        }

        public void Export(string path)
        {
            File.WriteAllText(path, Formatter.Serialize<PaintingAreaData>(GetPaintingAreaData()));
        }

        public void Import(string path)
        {
            PaintingAreaData areaData = Formatter.GetDeserialized<PaintingAreaData>(path);

            List<Box> boxes = GetBoxes(areaData);

            area.Boxes = boxes;
            area.Relations = GetRelations(areaData.relationDatas, boxes);

            area.SetSize((int)areaData.Width, (int)areaData.Height);            
        }

        //Data for import

         private List<Box> GetBoxes(PaintingAreaData areaData)
        {
            List<Box> boxes = new List<Box>();

            foreach (BoxData bD in areaData.boxDatas)
            {
                string name = bD.Name;
                AccessModifier modifier = bD.Modifier;
                BoxType type = bD.Type;
                List<Property> properties = bD.Properties;
                List<Method> methods = bD.Methods;

                Box b = new Box(name, modifier, type, methods, properties);
                
                b.Width = bD.Width;
                b.Height = bD.Height;
                b.X = bD.X;
                b.Y = bD.Y;
                b.IsSelected = false;
                                       
                boxes.Add(b);
            }

            return boxes;
        }

        private List<Relation> GetRelations(List<RelationData> relationDatas, List<Box> boxes)
        {
            List<Relation> result = new List<Relation>();

            foreach (RelationData rL in relationDatas)
            {                
                Box from = boxes.Where(b => b.Name == rL.FromName).FirstOrDefault();
                Box to = boxes.Where(b => b.Name == rL.ToName).FirstOrDefault();

                Relation relation = RelationGetter.GetRelation(rL.Type, from);

                relation.From = from;
                relation.To = to;
                relation.StartX = rL.StartX;
                relation.StartY = rL.StartY;
                relation.MidX = rL.MidX;
                relation.MidY = rL.MidY;
                relation.EndX = rL.EndX;
                relation.EndY = rL.EndY;
                relation.FromText = rL.FromText;
                relation.ToText = rL.ToText;
                relation.IsModified = rL.IsModified;
                relation.IsSelected = false;

                result.Add(relation);
            }

            return result;
        }

        //Data for export
        private PaintingAreaData GetPaintingAreaData()
        {
            PaintingAreaSize size = PaintingArea.Size;

            SizeF sizeF = new SizeF(size.Width, size.Height);

            return new PaintingAreaData(sizeF, GetBoxDatas(), GetRelationDatas());
        }

        private List<BoxData> GetBoxDatas()
        {
            List<BoxData> boxes = new List<BoxData>();

            foreach (Box b in area.Boxes)
            {
                boxes.Add(new BoxData(b));
            }

            return boxes;
        }

        private List<RelationData> GetRelationDatas()
        {
            List<RelationData> relations = new List<RelationData>();

            foreach (Relation r in area.Relations)
            {
                relations.Add(new RelationData(r));
            }

            return relations;
        }
    }
}
