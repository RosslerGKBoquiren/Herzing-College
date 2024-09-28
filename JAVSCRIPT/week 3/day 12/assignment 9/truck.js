

import Vehicle from `.vehicle.js`;

class Truck extends Vehicle {
    constructor(name, color, speed, acceleration) {
        super(name, color, speed);
        this.acceleration = acceleration;
    }

    move() {
        return speed;
    }
    
}

export default Truck;