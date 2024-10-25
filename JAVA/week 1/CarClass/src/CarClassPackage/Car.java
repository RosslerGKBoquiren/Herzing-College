package CarClassPackage;

public class Car {
	
    private String manufacturer;
    private String model;
    private int year;
    private boolean isRunning;

    
    public Car(String manufacturer, String model, int year) {
        this.manufacturer = manufacturer;
        this.model = model;
        this.year = year;
        this.isRunning = false; 
    }

    
    public void start() {
        isRunning = true;
        System.out.println(manufacturer + " " + model + " is now running.");
    }

    
    public void stop() {
        isRunning = false;
        System.out.println(manufacturer + " " + model + " has stopped.");
    }

    
    public boolean isRunning() {
        return isRunning;
    }

    
    public void displayInfo() {
    	
        System.out.println("Manufacturer: " + manufacturer);
        System.out.println("Model: " + model);
        System.out.println("Year: " + year);
        System.out.println("Is Running: " + (isRunning ? "Yes" : "No"));
        
    }
}
