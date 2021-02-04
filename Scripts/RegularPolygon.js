
class RegularPolygon extends Shape {
    constructor(context) {
        super(context); 
    }       
    draw(numberOfSides, size) {
        if (numberOfSides < 3) {
            console.log('number of sides needs to be greater or equal to 3');
            return;
        }
            

        this.ctx.beginPath();
        this.ctx.moveTo(this.xCenter + size * Math.cos(0), this.yCenter + size * Math.sin(0));

        for (var i = 1; i <= numberOfSides; i += 1) {
            this.ctx.lineTo(this.xCenter + size * Math.cos(i * 2 * Math.PI / numberOfSides), this.yCenter + size * Math.sin(i * 2 * Math.PI / numberOfSides));
        }
        
        this.ctx.stroke();        
        this.ctx.fill();
       
    }
}



  
