using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShapeDrawer.Models.Dto
{
    public class DrawingCommandRequestDto
    {
        public string Command { get; set; }
        public int MaxSize { get; set; }
         
    }
}