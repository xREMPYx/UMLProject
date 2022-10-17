using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;
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

        //Data for import

        private List<Box> GetBoxes(List<BoxData> boxDatas)
        {
            List<Box> boxes = new List<Box>();

            foreach (BoxData bD in boxDatas)
            {
                Box b = new Box();

                b.Name = bD.Name;
                b.Width = bD.Width;
                b.Height = bD.Height;
                b.X = bD.X;
                b.Y = bD.Y;
                b.Type = bD.Type;
                b.Modifier = bD.Modifier;                
                b.Properties = bD.Properties;
                b.Methods = bD.Methods;

                boxes.Add(b);
            }

            return boxes;
        }

        private List<Relation> GetRelations(List<RelationData> relationDatas)
        {
            List<Relation> relations = new List<Relation>();

            foreach (RelationData rL in relationDatas)
            {
                //Relation relation = new Relation();                
            }

            return relations;
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
