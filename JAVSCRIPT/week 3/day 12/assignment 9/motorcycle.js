

import Vehicle from './vehicle.js';

class Motorcycle extends Vehicle {
    constructor(name, color, speed, acceleration) {
        super(name, color, speed);
        this.acceleration = acceleration;
    }

    move() {
        this.speed += 0.5 * this.acceleration;
        return this.speed;
    }
    
}

export default Motorcycle;