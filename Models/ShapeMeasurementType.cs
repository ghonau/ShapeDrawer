using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapeDrawer.Models
{
    public class ShapeMeasurementType
    {
        public int Id { get; set; }
        public Shape Shape { get; set; }

        public int ShapeId { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public int MeasurementTypeId { get; set; }
    }
}