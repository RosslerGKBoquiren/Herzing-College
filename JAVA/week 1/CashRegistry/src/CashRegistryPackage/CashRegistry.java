package CashRegistryPackage;

import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Scanner;

// This class represents a user
public class CashRegistry {
	// it contains two fields: password and name
    static class User {
        private final String password;
        private final String name;

        public User(String password, String name) {
            this.password = password;
            this.name = name;
        }
        
        // The following methods are used to retrieve user details - password and name
        public String getPassword() {
            return password;
        }

        public String getName() {
            return name;
        }
    }

    
    // This class represents an item available for purchase 
    // contains two fields: name and price
    static class Item {
        private final String name;
        private final double price;

        public Item(String name, double price) {
            this.name = name;
            this.price = price;
        }
        
        // getName of the item
        public String getName() {
            return name;
        }

        // getPrice of the item
        public double getPrice() {
            return price;
        }

        // this is the formatted representation of the item
        public String toString() {
            return name + " - $" + price;
        }
    }

    // initialization of users with each cashier a number and a password
    private static final Map<String, User> USERS = new HashMap<>();
    static {
        USERS.put("5276151", new User("pass6151", "ROBBIE"));
        USERS.put("0245064", new User("pass5064", "CARL"));
        USERS.put("0716199", new User("pass6199", "JOE"));
        USERS.put("0911201", new User("pass1120", "JOHN"));
        USERS.put("0513199", new User("pass3199", "ALICIA"));
        USERS.put("9633228", new User("pass3228", "IAN"));
        USERS.put("6910806", new User("pass0806", "ROSS"));
        USERS.put("4384848", new User("pass4848", "ANNIE"));
        USERS.put("0190200", new User("pass0200", "ROBERTA"));
        USERS.put("2024110", new User("pass4110", "DELILAH"));
    }
 
    // initialization of a list of items, populated with Item objects
    private static final List<Item> items = new ArrayList<>(Arrays.asList(
            new Item("Water", 1.99),
            new Item("Juice", 2.55),
            new Item("Red Bull", 3.99),
            new Item("Sandwich", 6.99),
            new Item("Beer", 5.00),
            new Item("Bagel", 3.65),
            new Item("Coffee", 2.25)
    ));

    
    // Login process
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        int loginAttempts = 0;

        // user has three attempts to enter a valid cashier number and password
        try {
            while (loginAttempts < 3) {
                System.out.print("Enter Cashier number: ");
                String cashierNumber = scanner.nextLine();

                // if the credentials are correct, the user is greeted and mainMenu() is called
                if (USERS.containsKey(cashierNumber)) {
                    System.out.print("Enter password: ");
                    String password = scanner.nextLine();
                    
                    // if user number is correct, the user will be prompted to enter the appropriate password
                    if (USERS.get(cashierNumber).getPassword().equals(password)) {
                        System.out.println("\nWELCOME BACK " + USERS.get(cashierNumber).getName());
                        // Main Menu appears after the greeting
                        mainMenu(scanner);
                        return;
                        
                    // if they fail three times, an error message is displayed
                    } else {
                        System.out.println("\nIncorrect password. Try again.");
                    }
                } else {
                    System.out.println("\nInvalid Cashier Number. Try again.");
                }
                loginAttempts++;
            }
            System.out.println("\nYOU HAVE EXCEEDED THE NUMBER OF TRIES, ARE YOU SURE YOU HAVE THE RIGHT NUMBER?");
        } catch (Exception error) {
            System.out.println("An unexpected error occurred: " + error.getMessage());
        }
    }

    
    // mainMenu() presents the user with options to add or purchase items, including exiting the program
    private static void mainMenu(Scanner scanner) {
        while (true) {
            try {
                System.out.println("\nMain Menu:");
                System.out.println("(Press 1) Add new items");
                System.out.println("(Press 2) Purchase items");
                System.out.println("(Press x) Exit");
                System.out.print("\nSelect an option: ");

                String choice = scanner.nextLine().toLowerCase();
                switch (choice) {
                    case "1":
                    	// calling the method to add new items
                        addNewItems(scanner);
                        break;
                    case "2":
                    	// calling the method to purchase items
                        purchaseItems(scanner);
                        break;
                        // exit the program
                    case "x":
                        System.out.println("\u001B[32m\nThank you! Goodbye!\u001B[0m");
                        return;
                    default:
                        System.out.println("\u001B[31m\nInvalid choice. Please try again.\u001B[0m");
                }
            } catch (Exception error) {
                System.out.println("\u001B[31m\nAn unexpected error occurred: " + error.getMessage() + "\u001B[0m");
            }
        }
    }
    
    // add items allow the user to add items to the items list or delete existing items
    private static void addNewItems(Scanner scanner) {
        while (true) {
            try {
                System.out.println("\nExisting Items:");
                for (int i = 0; i < items.size(); i++) {
                    System.out.println((i + 1) + ". " + items.get(i));
                }
                
                // the user can enter the name and price of the item
                System.out.print("\nEnter new item name (or 'x' to return to main menu): ");
                String itemName = scanner.nextLine();
                if (itemName.equalsIgnoreCase("x")) {
                    break;
                }
                System.out.print("\nEnter price for " + itemName + ": ");
                double price = Double.parseDouble(scanner.nextLine());
                if (price < 0) {
                    System.out.println("\u001B[31m\nPrice cannot be negative. Try again.\u001B[0m");
                } else {
                	// add the new item to the list after naming and entering price
                    items.add(new Item(itemName, price));
                    System.out.println("\u001B[32m\n" + itemName + " added successfully.\u001B[0m");
                }
                
                // the program also allows deleting items based on user input
                System.out.print("\nDo you need to delete an item? (y / n): ");
                String deleteResponse = scanner.nextLine();
                if (deleteResponse.equalsIgnoreCase("y")) {
                	
                	// display updated list of available items for purchase
                	System.out.println("\nUpdated Items List:");
                    for (int i = 0; i < items.size(); i++) {
                        System.out.println((i + 1) + ". " + items.get(i));
                    }
                    
                    // prompt the user to enter the item to be deleted from the list
                    System.out.print("\nEnter the item number to delete: ");
                    int itemNumber = Integer.parseInt(scanner.nextLine());
                    if (itemNumber > 0 && itemNumber <= items.size()) {
                        Item removedItem = items.remove(itemNumber - 1);
                        System.out.println("\u001B[32m\n" + removedItem.getName() + " removed successfully.\u001B[0m");
                    } else {
                        System.out.println("\u001B[31m\nInvalid item number. Please try again.\u001B[0m");
                    }
                }
                
            } catch (NumberFormatException error) {
                System.out.println("\u001B[31m\nInvalid price. Please enter a valid number.\u001B[0m");
            } catch (Exception error) {
                System.out.println("\u001B[31m\nAn unexpected error occurred: " + error.getMessage() + "\u001B[0m");
            }
        }
    }

    
    // purchase items allows the user to add items to a shopping cart and remove items from it
    private static void purchaseItems(Scanner scanner) {
    	
    	
        double grandTotal = 0.0;
        List<String> cart = new ArrayList<>();
        DecimalFormat decimalFormat = new DecimalFormat("#.00");

        while (true) {
            try {
                System.out.println("\nOptions:");
                System.out.println("(Press 1) Add item to cart");
                System.out.println("(Press 2) Remove item from cart");
                System.out.println("(Press x) Finish");
                System.out.print("\nSelect an option: ");
                String action = scanner.nextLine();

                if (action.equalsIgnoreCase("x")) {
                    break;
                }

                // option 1 allows the user to select available items for purchase and choose a quantity
                switch (action) {
                    case "1":
                    	// displaying available items for purchase
                        System.out.println("\nAvailable Items:");
                        for (int i = 0; i < items.size(); i++) {
                            System.out.println((i + 1) + ". " + items.get(i));
                        }
                        
                        System.out.print("\nEnter item number to purchase: ");
                        String input = scanner.nextLine();
                        int itemNumber = Integer.parseInt(input);
                        
                        // if the user inputs an invalid item number or a negative value, an error will show
                        if (itemNumber < 1 || itemNumber > items.size()) {
                            System.out.println("\u001B[31m\nInvalid item number. Try again.\u001B[0m");
                        } else {
                        	// validate the quantity of items to be purchased
                            System.out.print("\nEnter quantity: ");
                            int quantity = Integer.parseInt(scanner.nextLine());

                            if (quantity < 0) {
                                System.out.println("\u001B[31m\nQuantity cannot be negative. Try again.\u001B[0m");
                                
                            // else the item and quantity chosen will be added to cart, and a subtotal price will be displayed
                            } else {
                                Item item = items.get(itemNumber - 1);
                                double subtotal = item.getPrice() * quantity;
                                grandTotal += subtotal;

                                cart.add(quantity + " x " + item.getName() + " - $" + decimalFormat.format(subtotal));
                                System.out.println("\u001B[32m\nAdded " + quantity + " x " + item.getName() + " to cart. Subtotal: $" + decimalFormat.format(grandTotal) + "\u001B[0m");

                                System.out.println("\u001B[33m\nCurrent Cart: \u001B[0m");
                                for (String cartItem : cart) {
                                    System.out.println("\u001B[33m" + cartItem + "\u001B[0m");
                                }
                            }
                        }
                        break;
                    
                        
                    // option 2 allows the user to remove items and/or quantity from cart
                    case "2":
                        if (cart.isEmpty()) {
                            System.out.println("\u001B[31m\nCart is empty.\u001B[0m");
                        } else {
                            System.out.println("\u001B[33m\nCurrent Cart: \u001B[0m");
                            for (int i = 0; i < cart.size(); i++) {
                                System.out.println((i + 1) + ". " + cart.get(i));
                            }
                            System.out.print("Enter item number to remove: ");
                            int removeItem = Integer.parseInt(scanner.nextLine());
                            if (removeItem > 0 && removeItem <= cart.size()) {
                                String[] itemDetails = cart.get(removeItem - 1).split(" x ");
                                int currentQuantity = Integer.parseInt(itemDetails[0]);
                                System.out.print("Enter quantity to remove: ");
                                int quantityToRemove = Integer.parseInt(scanner.nextLine());

                                // validate quantity to remove
                                if (quantityToRemove > 0 && quantityToRemove <= currentQuantity) {
                                    if (quantityToRemove == currentQuantity) {
                                        String removed = cart.remove(removeItem - 1);
                                        System.out.println("\u001B[32mRemoved " + removed + " from cart.\u001B[0m");
                                    } else {
                                        int newQuantity = currentQuantity - quantityToRemove;
                                        String updatedItem = newQuantity + " x " + itemDetails[1];
                                        cart.set(removeItem - 1, updatedItem);
                                        System.out.println("\u001B[32mRemoved " + quantityToRemove + " of " + itemDetails[1] + " from cart.\u001B[0m");
                                    }
                                } else {
                                    System.out.println("\u001B[31mInvalid quantity. Please try again.\u001B[0m");
                                }
                            } else {
                                System.out.println("\u001B[31mInvalid item number. Try again.\u001B[0m");
                            }
                        }
                        break;

                    default:
                        System.out.println("\u001B[31mInvalid option. Please try again.\u001B[0m");

                }
            } catch (NumberFormatException error) {
                System.out.println("\u001B[31m\nInvalid input. Please enter a valid number.\u001B[0m");
            } catch (Exception error) {
                System.out.println("\u001B[31m\nAn unexpected error occurred: " + error.getMessage() + "\u001B[0m");
            }
        }
        // display the grand total after finishing the purchase
        System.out.println("\u001B[32m\nGrand Total: $" + decimalFormat.format(grandTotal) + "\u001B[0m");
    }


}


