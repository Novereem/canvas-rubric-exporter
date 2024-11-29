using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models.Display
{
    public class ModuleDisplay
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public override string ToString() => Name;
    }
}
