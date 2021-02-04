using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapeDrawer.Models.Dto
{
    public class DrawingCommandResponseDto
    {
        public string Shape { get; set; }
        public IEnumerable<MeasurementDto> Measurements { get; set; }

        public string Message { get; set; }
         
    }
}