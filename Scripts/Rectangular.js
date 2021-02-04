
class Rectangular extends Shape {
    constructor(context){
        super(context);
    }

    draw(width, height) {
        this.ctx.beginPath();
        this.ctx.rect(this.xCenter, this.yCenter, width, height);
        this.ctx.stroke();
        this.ctx.fill();
    }
}



  
