
class Shape {
    constructor(context) {

        //initialise context 
        this.canvas = this.getCanvas(context.selector);
        this.ctx = this.getContext(this.canvas);         
        this.xCenter = context.xCenter;
        this.yCenter = context.yCenter;
        this.strokeStyle = context.strokeStyle;
        this.lineWidth = context.lineWidth;
        this.fillStyle = context.fillStyle; 


        this.ctx.strokeStyle = this.strokeStyle;
        this.ctx.lineWidth = this.lineWidth;        
        this.ctx.fillStyle = this.fillStyle;                
        this.clearCanvas();
    }
    clearCanvas() {        
        this.ctx.clearRect(0, 0, this.canvas.width, this.canvas.height); 
    }

    getContext(canvas) {        
        return canvas.getContext('2d'); 
    }    
    getCanvas(selector) {
        var canvas = document.querySelector(selector);
        if (!canvas) {
            throw new Error('canvas element cannot be found!');
        }
        return canvas; 
    }
}



  
