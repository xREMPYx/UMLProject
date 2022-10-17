using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMLProject.Models.DataModels
{
    public class PaintingAreaData
    {
        public SizeF Size { get; set; }
        public List<BoxData> boxDatas { get; set; }
        public List<RelationData> relationDatas { get; set; }

        public PaintingAreaData(SizeF size, List<BoxData> boxDatas, List<RelationData> relationDatas)
        {
            this.Size = size;
            this.boxDatas = boxDatas;
            this.relationDatas = relationDatas;
        }
    }
}
