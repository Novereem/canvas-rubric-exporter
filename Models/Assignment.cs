using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models
{
    public class Assignment
    {
        public int id { get; set; }
        public string name { get; set; }
        public List<Criterion> rubric { get; set; }
        public RubricSettings rubric_settings { get; set; }
    }
}
