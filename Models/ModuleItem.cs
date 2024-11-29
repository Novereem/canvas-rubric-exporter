using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models
{
    public class ModuleItem
    {
        public int id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public int content_id { get; set; }
    }
}
