using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMLProject.Components;

namespace UMLProject.Utils
{
    public static class Formatter
    {
        public static string Serialize<T>(T area)
        {
            return JsonConvert.SerializeObject(area);
        }

        public static T GetPaintingArea<T>(string area)
        {
            return JsonConvert.DeserializeObject<T>(area);
        }
    }
}
