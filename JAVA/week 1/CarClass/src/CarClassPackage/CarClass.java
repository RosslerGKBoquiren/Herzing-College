package CarClassPackage;

public class CarClass {

    public static void main(String[] args) {
        
        Car car1 = new Car("Toyota", "Tundra", 2020);
        Car car2 = new Car("Lexus", "IS250", 2011);
        Car car3 = new Car("Lexus", "NX", 2018);
        
        
        System.out.print("\n");
        car1.start();
        car1.stop();
        car1.displayInfo();
        System.out.print("\n");

        car2.start();
        car2.displayInfo();
        car2.stop();
        System.out.print("\n");
        
        car3.displayInfo();
        car3.start();
        car3.stop();
        System.out.print("\n");
        
    }
}
