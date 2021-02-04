class Oval extends Shape {
    constructor(context) {
        super(context);
    }

    draw(xRadius, yRadius) {
        this.ctx.beginPath();
        this.ctx.ellipse(this.xCenter, this.yCenter, xRadius, yRadius, Math.PI * 2, 0, 2 * Math.PI);
        this.ctx.stroke();
        this.ctx.fill();
    }
}