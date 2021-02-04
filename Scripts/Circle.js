
class Circle extends Oval {
    constructor(context) {
        super(context);
    }

    draw(radius) {
        super.draw(radius, radius); 
    }
}