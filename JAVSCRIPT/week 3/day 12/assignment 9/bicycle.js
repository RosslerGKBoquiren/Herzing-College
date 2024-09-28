

import Vehicle from `.vehicle.js`;

class Bicycle extends Vehicle {
    constructor(name, color, speed, acceleration) {
        super(name, color, speed);
        this.acceleration = acceleration;
    }

    move() {
        return speed += 0.5 * this.acceleration;
    }
    
}

export default Bicycle;