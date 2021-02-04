using ShapeDrawer.Models;
using ShapeDrawer.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace ShapeDrawer.Controllers.api
{
    public class ShapesController : ApiController
    {

        private ApplicationDbContext _applicationDbContext;
        public ShapesController()
        {
            _applicationDbContext = new ApplicationDbContext(); 
        }
        // GET: api/Shapes
       [HttpPost]
        public DrawingCommandResponseDto Get(DrawingCommandRequestDto commandDto)
        {
            var input = commandDto.Command;
            string[] separators = { "Draw an", "Draw a", "with an", "with a", "of", "and an", "and a" };
            var message = string.Empty; 
            if (string.IsNullOrEmpty(input))
            {
                return new DrawingCommandResponseDto
                {
                    Message = string.Format("Input data cannot be empty") 
                };
            }
            var parts = input.Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(part => part.Trim()).ToList();
                     
            
            var shapeName = parts[0];            
            var shape =_applicationDbContext.Shapes.Where(s => s.Name == shapeName).FirstOrDefault();
            if(shape == null)
            {
                return new DrawingCommandResponseDto
                {
                    Message = string.Format("Could not find a shape called {0}", shapeName)
                };
            }
            var numberOfMeasurements = _applicationDbContext
                .ShapeMeasurementTypes
                .Where(sr => sr.ShapeId == shape.Id)
                .Count();
                

            var firstMeasurement = parts[1];
            if (numberOfMeasurements == 1)
            {                            
                if (parts.Count != 3)
                    return new DrawingCommandResponseDto
                    {
                        Message = HttpUtility.HtmlEncode("Enter your input as Draw a(n) <shape> with a <measurement> of <amount> [and a(n) <measurement> of <amount>]")
                    };
                return CreateDrawingCommandResponseWithSingleMeasurement(parts, shapeName, shape, firstMeasurement);

            }
            else if(numberOfMeasurements == 2)
            {
                if (parts.Count != 5)
                    return new DrawingCommandResponseDto
                    {
                        Message = HttpUtility.HtmlEncode("Enter your input as Draw a(n) <shape> with a <measurement> of <amount> [and a(n) <measurement> of <amount>]")
                    };
                return CreateDrawingCommandResponseWithTwoMeasurments(parts, shapeName, shape);

            }
            else
            {
                return new DrawingCommandResponseDto
                {
                    Message = string.Format("Unexpected exception occured please try later")
                };
            }
            
        }
       

        private DrawingCommandResponseDto CreateDrawingCommandResponseWithSingleMeasurement(List<string> parts, string shapeName, Shape shape, string firstMeasurement)
        {
            // we have only one measurement in db                

            var measurementType = _applicationDbContext
                .ShapeMeasurementTypes
                .Include("MeasurementType")
                .Where(sr => sr.ShapeId == shape.Id)
                .Where(sr => sr.MeasurementType.DispalyName == firstMeasurement)
                .Select(sr => sr.MeasurementType)
                .FirstOrDefault();

            int measurementValue;
            if (int.TryParse(parts[2], out measurementValue))
            {
                if (measurementValue < 0 || measurementValue > 200)
                    return new DrawingCommandResponseDto {
                        Message = "Measurement values should be between 0 and 200"
                    };

                var measurements = new List<MeasurementDto>();
                measurements.Add(new MeasurementDto
                {
                    Name = measurementType.DispalyName,
                    Value = measurementValue
                });
                return new DrawingCommandResponseDto
                {
                    Measurements = measurements,
                    Shape = shapeName

                };
            }
            else
            {
                var shapeMeasurementsInDb = _applicationDbContext.ShapeMeasurementTypes.Where(sr => sr.ShapeId == shape.Id).Select(sr => sr.MeasurementType).ToList();
                return new DrawingCommandResponseDto
                {
                    Message = string.Format("In order to draw a {0} you will need to provide a measurement of {1} with valid value", shapeName, shapeMeasurementsInDb[0].DispalyName)
                };
            }
        }

        private DrawingCommandResponseDto CreateDrawingCommandResponseWithTwoMeasurments(List<string> parts, string shapeName, Shape shape)
        {
            
            var secondMeasurement = parts[3];
            int firstMeasurementValue, secondMeasurementValue;
            var shapeMeasurementsInDb = _applicationDbContext.ShapeMeasurementTypes.Where(sr => sr.ShapeId == shape.Id).Select(sr => sr.MeasurementType).OrderBy(sr => sr.Id).ToList();
            if (int.TryParse(parts[2], out firstMeasurementValue) && int.TryParse(parts[4], out secondMeasurementValue))
            {
                
                if(firstMeasurementValue > 200 || firstMeasurementValue < 0 || secondMeasurementValue < 0 || secondMeasurementValue > 200)
                {
                    return new DrawingCommandResponseDto
                    {
                        Message = "Measurement values should be between 0 and 200"
                    };
                }
                var measurements = new List<MeasurementDto>();
                measurements.Add(new MeasurementDto
                {
                    Name = parts[1],
                    Value = firstMeasurementValue
                });
                measurements.Add(new MeasurementDto
                {
                    Name = parts[3],
                    Value = secondMeasurementValue
                });
                return new DrawingCommandResponseDto
                {
                    Measurements = measurements,
                    Shape = shapeName
                };
            }
            else
            {
                
                return new DrawingCommandResponseDto
                {
                    Message = string.Format("In order to draw a {0} you will need to provide two measurements of {1} and {2} with valid values", shapeName, shapeMeasurementsInDb[0].DispalyName, shapeMeasurementsInDb[1].DispalyName)
                };
            }
        }
    }
}