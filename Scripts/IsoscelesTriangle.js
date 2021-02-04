
class IsoscelesTriangle extends Shape {
    constructor(context) {
        super(context);
    }
    
    draw(width, height) {
        this.ctx.beginPath();
        this.ctx.moveTo(this.xCenter - (width / 2), this.yCenter);
        this.ctx.lineTo(this.xCenter + (width / 2), this.yCenter);
        this.ctx.lineTo(this.xCenter, this.yCenter - height);
        this.ctx.closePath(); 
        this.ctx.stroke(); 
        this.ctx.fill();
    }
}



  
