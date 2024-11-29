using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models
{
    public class Rubric
    {
        public string title { get; set; }
        public string AssignmentId { get; set; }
        public string AssignmentName { get; set; }
        public string ModuleItemId { get; set; }
        public List<Criterion> criteria { get; set; }
    }
}
