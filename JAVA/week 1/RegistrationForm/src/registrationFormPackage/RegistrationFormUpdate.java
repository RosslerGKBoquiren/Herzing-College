package registrationFormPackage;

import java.awt.Color;
import java.awt.Font;
import java.awt.GridBagConstraints;
import java.awt.GridBagLayout;
import java.awt.Insets;
import java.awt.event.MouseAdapter;
import java.awt.event.MouseEvent;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.util.regex.Pattern;

import javax.swing.ButtonGroup;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JComponent;
import javax.swing.JFormattedTextField;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JMenu;
import javax.swing.JMenuBar;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JPopupMenu;
import javax.swing.JRadioButton;
import javax.swing.JTextField;
import javax.swing.text.MaskFormatter;

public class RegistrationFormUpdate extends JFrame{

	private JFormattedTextField phoneField;
	
	public RegistrationFormUpdate() {
		// Frame settings
        setTitle("New Account Registration");
        setSize(400, 500);
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setLayout(new GridBagLayout());
        GridBagConstraints gridBagConstraints = new GridBagConstraints();
        gridBagConstraints.insets = new Insets(10, 50, 5, 50);
        gridBagConstraints.fill = GridBagConstraints.HORIZONTAL;

        // Title label
        JLabel titleLabel = new JLabel("New Account Registration");
        titleLabel.setFont(new Font("Serif", Font.BOLD, 20));
        titleLabel.setForeground(Color.BLUE);
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.gridwidth = 2;
        add(titleLabel, gridBagConstraints);

        // Name field
        gridBagConstraints.gridwidth = 1;
        addLabel("Name:", gridBagConstraints, 1);
        JTextField nameField = new JTextField(20);
        addComponent(nameField, gridBagConstraints, 2, 1);

        // Email field
        addLabel("Email Address:", gridBagConstraints, 2);
        JTextField emailField = new JTextField(20);
        addComponent(emailField, gridBagConstraints, 2, 2);

        // Password field
        addLabel("Create Password:", gridBagConstraints, 3);
        JPasswordField passwordField = new JPasswordField(20);
        addComponent(passwordField, gridBagConstraints, 2, 3);

        // Confirm password field
        addLabel("Confirm Password:", gridBagConstraints, 4);
        JPasswordField confirmPasswordField = new JPasswordField(20);
        addComponent(confirmPasswordField, gridBagConstraints, 2, 4);

        // Gender radio buttons
        addLabel("Gender:", gridBagConstraints, 5);
        JPanel genderPanel = new JPanel();
        JRadioButton maleButton = new JRadioButton("Male");
        JRadioButton femaleButton = new JRadioButton("Female");
        ButtonGroup genderGroup = new ButtonGroup();
        genderGroup.add(maleButton);
        genderGroup.add(femaleButton);
        genderPanel.add(maleButton);
        genderPanel.add(femaleButton);
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 5;
        add(genderPanel, gridBagConstraints);

        // Address field
        addLabel("Address:", gridBagConstraints, 6);
        JTextField addressField = new JTextField(20);
        addComponent(addressField, gridBagConstraints, 2, 6);

        // Province drop box
        addLabel("Province:", gridBagConstraints, 7);
        String[] province = {"Select a province", "Yukon", "Nunavut", "Northwest Territories", "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan"};
        JComboBox<String> provinceComboBox = new JComboBox<>(province);
        addComponent(provinceComboBox, gridBagConstraints, 2, 7);

        // Country field
        addLabel("Country:", gridBagConstraints, 8);
        JTextField countryField = new JTextField(20);
        addComponent(countryField, gridBagConstraints, 2, 8);

        // Phone number field with MaskFormatter
        addLabel("Phone No:", gridBagConstraints, 9);
        try {
            MaskFormatter phoneFormatter = new MaskFormatter("(###) ###-####");
            phoneFormatter.setPlaceholderCharacter('_');
            phoneField = new JFormattedTextField(phoneFormatter);
            phoneField.setColumns(20);
        } catch (Exception e) {
            e.printStackTrace();
        }
        addComponent(phoneField, gridBagConstraints, 2, 9);

        // Buttons
        JPanel buttonPanel = new JPanel();
        JButton submitButton = new JButton("Submit");
        JButton clearButton = new JButton("Clear");
        buttonPanel.add(submitButton);
        buttonPanel.add(clearButton);
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 10;
        gridBagConstraints.gridwidth = 2;
        add(buttonPanel, gridBagConstraints);

        // Action listeners for buttons
        submitButton.addActionListener(e -> {
            String name = nameField.getText();
            String email = emailField.getText();
            String password = new String(passwordField.getPassword());
            String confirmPassword = new String(confirmPasswordField.getPassword());
            String gender = maleButton.isSelected() ? "Male" : femaleButton.isSelected() ? "Female" : "";
            String address = addressField.getText();
            String selectedProvince = (String) provinceComboBox.getSelectedItem(); 
            String country = countryField.getText();
            String phone = phoneField.getText();

            // Validate form fields
            StringBuilder errors = new StringBuilder();
            if (name.isEmpty()) errors.append("Name cannot be empty.\n");
            if (email.isEmpty() || !isValidEmail(email)) errors.append("Invalid email address.\n");
            if (password.isEmpty()) errors.append("Password cannot be empty.\n");
            if (!password.equals(confirmPassword)) errors.append("Passwords do not match.\n");
            if (gender.isEmpty()) errors.append("Gender must be selected.\n");
            if (address.isEmpty()) errors.append("Address cannot be empty.\n");
            if (selectedProvince.equals("Select a province")) errors.append("Please select a province.\n");
            if (country.isEmpty()) errors.append("Country cannot be empty.\n");
            if (phone.contains("_")) errors.append("Phone number is incomplete.\n");

            if (errors.length() > 0) {
                JOptionPane.showMessageDialog(this, errors.toString(), "Validation Error", JOptionPane.ERROR_MESSAGE);
            } else {
                int confirm = JOptionPane.showConfirmDialog(this,
                        "Please confirm your details:\n" +
                                "Name: " + name + "\n" +
                                "Email: " + email + "\n" +
                                "Gender: " + gender + "\n" +
                                "Address: " + address + "\n" +
                                "Province: " + selectedProvince + "\n" +
                                "Country: " + country + "\n" +
                                "Phone: " + phone,
                        "Confirm Details",
                        JOptionPane.YES_NO_OPTION);

                if (confirm == JOptionPane.YES_OPTION) {
                    saveToDatabase(name, email, password, gender, address, selectedProvince, country, phone);
                }
            }
        });


        clearButton.addActionListener(e -> {
            nameField.setText("");
            emailField.setText("");
            passwordField.setText("");
            confirmPasswordField.setText("");
            genderGroup.clearSelection();
            addressField.setText("");
            provinceComboBox.setSelectedIndex(0);
            countryField.setText("");
            phoneField.setText("");
        });

        // Add Menu Bar
        JMenuBar menuBar = new JMenuBar();

        JMenu fileMenu = new JMenu("File");
        JMenuItem closeMenuItem = new JMenuItem("Close");
        closeMenuItem.addActionListener(e -> dispose());
        fileMenu.add(closeMenuItem);

        JMenu editMenu = new JMenu("Edit");
        JMenuItem clearMenuItem = new JMenuItem("Clear");
        clearMenuItem.addActionListener(e -> clearButton.doClick());
        editMenu.add(clearMenuItem);

        JMenu helpMenu = new JMenu("Help");
        JMenuItem versionMenuItem = new JMenuItem("Version");
        versionMenuItem.addActionListener(e -> JOptionPane.showMessageDialog(this, "             Version 2.0"));
        JMenuItem aboutMenuItem = new JMenuItem("About");
        aboutMenuItem.addActionListener(e -> JOptionPane.showMessageDialog(this, "   Author: Rossler Boquiren"));
        helpMenu.add(versionMenuItem);
        helpMenu.add(aboutMenuItem);

        menuBar.add(fileMenu);
        menuBar.add(editMenu);
        menuBar.add(helpMenu);
        setJMenuBar(menuBar);

        // Add Context Menu
        JPopupMenu contextMenu = new JPopupMenu();
        JMenuItem color1 = new JMenuItem("Light Blue");
        color1.addActionListener(e -> getContentPane().setBackground(Color.CYAN));
        JMenuItem color2 = new JMenuItem("Light Green");
        color2.addActionListener(e -> getContentPane().setBackground(Color.GREEN));
        JMenuItem color3 = new JMenuItem("Light Yellow");
        color3.addActionListener(e -> getContentPane().setBackground(Color.YELLOW));

        contextMenu.add(color1);
        contextMenu.add(color2);
        contextMenu.add(color3);

        addMouseListener(new MouseAdapter() {
            public void mousePressed(MouseEvent e) {
                if (e.isPopupTrigger()) contextMenu.show(e.getComponent(), e.getX(), e.getY());
            }

            public void mouseReleased(MouseEvent e) {
                if (e.isPopupTrigger()) contextMenu.show(e.getComponent(), e.getX(), e.getY());
            }
        });

        setVisible(true);
    }
	
	private boolean isValidEmail(String email) {
        String emailRegex = "^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$";
        return Pattern.matches(emailRegex, email);
    }
	
	
	private void saveToDatabase(String name, String email, String password, String gender, String address,
            String provinceValue, String country, String phone) {
	try (Connection conn = DriverManager.getConnection("jdbc:mysql://localhost:3306/registration", "root", "");
		PreparedStatement stmt = conn.prepareStatement("INSERT INTO users (name, email, password, gender, address, province, country, phone) VALUES (?, ?, ?, ?, ?, ?, ?, ?)")) {
		
		stmt.setString(1, name);
		stmt.setString(2, email);
		stmt.setString(3, password);
		stmt.setString(4, gender);
		stmt.setString(5, address);
		stmt.setString(6, provinceValue);
		stmt.setString(7, country);
		stmt.setString(8, phone);
		
		int rowsInserted = stmt.executeUpdate();
		if (rowsInserted > 0) {
		JOptionPane.showMessageDialog(this, "Registration successful!", "Success", JOptionPane.INFORMATION_MESSAGE);
		}
	
	} catch (Exception ex) {
		ex.printStackTrace();
		JOptionPane.showMessageDialog(this, "Error saving data to the database.", "Database Error", JOptionPane.ERROR_MESSAGE);
		}
	}


    private void addLabel(String text, GridBagConstraints gridBagConstraints, int y) {
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = y;
        add(new JLabel(text), gridBagConstraints);
    }

    private void addComponent(JComponent component, GridBagConstraints gridBagConstraints, int gridWidth, int y) {
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = y;
        gridBagConstraints.gridwidth = gridWidth;
        add(component, gridBagConstraints);
    }
	
	
	public static void main(String[] args) {
		new RegistrationFormUpdate();

	}

}
