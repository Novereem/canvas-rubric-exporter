using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models
{
    public class Criterion
    {
        public string id { get; set; }
        public double points { get; set; }
        public string description { get; set; }
        public string long_description { get; set; }
        public bool criterion_use_range { get; set; }
        public List<Rating> ratings { get; set; }
    }
}
