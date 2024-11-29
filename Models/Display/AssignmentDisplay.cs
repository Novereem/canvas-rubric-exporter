using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models.Display
{
    public class AssignmentDisplay
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public string ModuleItemId { get; set; }
        public string RubricId { get; set; }
        public override string ToString() => Name;
    }
}
