
class ScaleneTriangle extends Shape {
    constructor(context) {
        super(context);
    }
    
    draw(width, height) {
        this.ctx.beginPath();
        this.ctx.moveTo(this.xCenter, this.yCenter - height);
        this.ctx.lineTo(this.xCenter, this.yCenter);
        this.ctx.lineTo(this.xCenter + width, this.yCenter);
        this.ctx.closePath(); 
        this.ctx.stroke(); 
        this.ctx.fill();
    }
}



  
