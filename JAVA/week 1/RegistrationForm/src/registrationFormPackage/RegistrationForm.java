package registrationFormPackage;

import javax.swing.*;
import javax.swing.text.MaskFormatter;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class RegistrationForm extends JFrame {
    
	private JFormattedTextField phoneField;
	
    public RegistrationForm() {
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
        JPanel genderPanel = new JPanel(new FlowLayout(FlowLayout.LEFT));
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
        addLabel("State:", gridBagConstraints, 7);
        String[] states = {"Yukon", "Nunavut", "Northwest Territories", "Alberta", "British Columbia", "Manitoba", "New Brunswick", "Newfoundland and Labrador", "Nova Scotia", "Ontario", "Prince Edward Island", "Quebec", "Saskatchewan"};
        JComboBox<String> stateComboBox = new JComboBox<>(states);
        addComponent(stateComboBox, gridBagConstraints, 2, 7);

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
        JPanel buttonPanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        JButton submitButton = new JButton("Submit");
        JButton clearButton = new JButton("Clear");
        buttonPanel.add(submitButton);
        buttonPanel.add(clearButton);
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 10;
        gridBagConstraints.gridwidth = 2;
        add(buttonPanel, gridBagConstraints);

        // Action listeners for buttons
        submitButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                StringBuilder output = new StringBuilder("Form Data:\n");
                output.append("Name: ").append(nameField.getText()).append("\n");
                output.append("Email: ").append(emailField.getText()).append("\n");
                output.append("Password: ").append(new String(passwordField.getPassword())).append("\n");
                output.append("Confirm Password: ").append(new String(confirmPasswordField.getPassword())).append("\n");
                output.append("Gender: ").append(maleButton.isSelected() ? "Male" : femaleButton.isSelected() ? "Female" : "Not selected").append("\n");
                output.append("Address: ").append(addressField.getText()).append("\n");
                output.append("State: ").append((String) stateComboBox.getSelectedItem()).append("\n");
                output.append("Country: ").append(countryField.getText()).append("\n");
                output.append("Phone No: ").append(phoneField.getText()).append("\n");
                System.out.println(output.toString());

                // Basic error handling
                if (nameField.getText().isEmpty() || emailField.getText().isEmpty() || countryField.getText().isEmpty() || phoneField.getText().contains("_")) {
                    JOptionPane.showMessageDialog(null, "Please fill out all required fields correctly.", "Error", JOptionPane.ERROR_MESSAGE);
                }
            }
        });

        clearButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                nameField.setText("");
                emailField.setText("");
                passwordField.setText("");
                confirmPasswordField.setText("");
                genderGroup.clearSelection();
                addressField.setText("");
                stateComboBox.setSelectedIndex(0);
                countryField.setText("");
                phoneField.setText("");
            }
        });

        setVisible(true);
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
        new RegistrationForm();
    }
}