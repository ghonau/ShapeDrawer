class ShapeDrawer {
    constructor(context) {
        this.context = context;
    }
    getMeasurementValue(data, measurementName) {
        return data.Measurements[0].Name.toLowerCase() === measurementName.toLowerCase() ? data.Measurements[0].Value : data.Measurements[1].Value
    }
    draw(input) {
        var context = this.context; 
        var self = this; 
        $.ajax({
            url: 'https://localhost:44319/api/Shapes',
            type: 'POST',
            dataType: 'json',
            data: {
                Command: input,
                MaxSize: this.context.MaxSize
            },
            success: function (data) {
                if (!data.Message) {
                    var shapeName = data.Shape.toLowerCase();
                    switch (shapeName) {
                        case "isosceles triangle": {
                            var drawer = new IsoscelesTriangle(context);
                            var width = self.getMeasurementValue(data, 'width');
                            var height = self.getMeasurementValue(data, 'height'); 
                            drawer.draw(width, height);
                            break;
                        }                        
                        case "scalene  triangle": {
                            var drawer = new ScaleneTriangle(context);
                            var width = self.getMeasurementValue(data, 'width');
                            var height = self.getMeasurementValue(data, 'height');
                            drawer.draw(width, height);
                            break;
                        }
                        case "equilateral triangle": {
                            var drawer = new EquilateralTriangle(context);
                            drawer.draw(data.Measurements[0].Value);
                            break;
                        }
                        case "rectangle": {
                            var drawer = new Rectangular(context);
                            var width = self.getMeasurementValue(data, 'width');
                            var height = self.getMeasurementValue(data, 'height');
                            drawer.draw(width, height);
                            break;
                        }
                        case "square": {
                            var drawer = new Square(context);
                            drawer.draw(data.Measurements[0].Value);
                            break;
                        }
                        case "parallelogram": {
                            var drawer = new RegularPolygon(context);
                            drawer.draw(4, data.Measurements[0].Value);
                            break;
                        }
                        case "pentagon": {
                            var drawer = new RegularPolygon(context);
                            drawer.draw(5, data.Measurements[0].Value);
                            break;
                        }
                        case "hexagon": {
                            var drawer = new RegularPolygon(context);
                            drawer.draw(6, data.Measurements[0].Value);
                            break;
                        }
                        case "heptagon": {
                            var drawer = new RegularPolygon(context);
                            drawer.draw(7, data.Measurements[0].Value);
                            break;
                        }
                        case "octagon": {
                            var drawer = new RegularPolygon(context);
                            drawer.draw(8, data.Measurements[0].Value);
                            break;
                        }
                        case "circle": {
                            var drawer = new Circle(context);
                            drawer.draw(data.Measurements[0].Value);
                            break;
                        }
                        case "oval": {
                            var drawer = new Oval(context);
                            var xRadius = self.getMeasurementValue(data, 'xRadius'); 
                            var yRadius = self.getMeasurementValue(data, 'yRadius'); 
                            drawer.draw(xRadius,yRadius);
                            break;
                        }

                    }
                }
                else {
                    bootbox.alert(data.Message);
                }                
            },
            error: function (xhr, status, error) {
                bootbox.alert(error); 
            }
        });        
    }
}