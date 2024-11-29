using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanvasRubricExporter.Models
{
    public class RubricSettings
    {
        public int id { get; set; }
        public string title { get; set; }
        public double points_possible { get; set; }
        public bool free_form_criterion_comments { get; set; }
        public bool hide_score_total { get; set; }
        public bool hide_points { get; set; }
    }
}
