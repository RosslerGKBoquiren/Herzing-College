package LayoutPackage;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Font;

import javax.swing.Box;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class Layout {

    public static void main(String[] args) {
        
        JFrame frame = new JFrame("Teacher-Based Layout Example");
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setSize(800, 400); 

        // Set BorderLayout for the main frame
        frame.setLayout(new BorderLayout(8, 8));
        
        Font customFont = new Font("New Times Roman", Font.BOLD, 16);

        // Left Panel for BTN1 and BTN2
        JPanel leftPanel = new JPanel();
        leftPanel.setLayout(new BoxLayout(leftPanel, BoxLayout.Y_AXIS)); 
        JButton btn1 = new JButton("BTN1");
        JButton btn2 = new JButton("BTN2");
        btn1.setBackground(Color.BLUE);
        btn1.setForeground(Color.WHITE);
        btn1.setFont(customFont);
        btn1.setPreferredSize(new Dimension(270, 120));
        btn1.setMaximumSize(new Dimension(270, 120)); 
        
        btn2.setBackground(Color.BLUE);
        btn2.setForeground(Color.WHITE);
        btn2.setFont(customFont);
        btn2.setPreferredSize(new Dimension(270, 272));
        btn2.setMaximumSize(new Dimension(270, 272)); 
        leftPanel.add(btn1);
        leftPanel.add(Box.createVerticalStrut(8)); 
        leftPanel.add(btn2);

        // Center Button BTN3
        JButton btn3 = new JButton("BTN3");
        btn3.setBackground(Color.BLUE);
        btn3.setForeground(Color.WHITE);
        btn3.setFont(customFont);
        btn3.setPreferredSize(new Dimension(300, 300)); 
        btn3.setMaximumSize(new Dimension(300, 300));

        // Right Panel containing two parts: top and bottom
        JPanel rightPanel = new JPanel();
        rightPanel.setLayout(new BorderLayout(8, 8));

        // Top Right Panel for BTN4 and BTN5
        JPanel topRightPanel = new JPanel();
        topRightPanel.setLayout(new BoxLayout(topRightPanel, BoxLayout.Y_AXIS)); 
        JButton btn4 = new JButton("BTN4");
        
        btn4.setBackground(Color.BLUE);
        btn4.setForeground(Color.WHITE);
        btn4.setPreferredSize(new Dimension(256, 80));
        btn4.setMaximumSize(new Dimension(256, 80));
        btn4.setFont(customFont);
        
        JButton btn5 = new JButton("BTN5");
        btn5.setBackground(Color.BLUE);
        btn5.setForeground(Color.WHITE);
        btn5.setFont(customFont);
        btn5.setPreferredSize(new Dimension(256, 80));
        btn5.setMaximumSize(new Dimension(256, 80));
        topRightPanel.add(btn4);
        topRightPanel.add(Box.createVerticalStrut(8)); 
        topRightPanel.add(btn5);

        // Bottom Right Panel for BTN6, BTN7, BTN8
        JPanel bottomRightPanel = new JPanel();
        bottomRightPanel.setLayout(new BoxLayout(bottomRightPanel, BoxLayout.X_AXIS)); // Use BoxLayout to control sizing
        JButton btn6 = new JButton("BTN6");
        btn6.setBackground(Color.BLUE);
        btn6.setForeground(Color.WHITE);
        btn6.setFont(customFont);
        btn6.setPreferredSize(new Dimension(80, 224));
        btn6.setMaximumSize(new Dimension(80, 224));
        
        JButton btn7 = new JButton("BTN7");
        btn7.setBackground(Color.BLUE);
        btn7.setForeground(Color.WHITE);
        btn7.setFont(customFont);
        btn7.setPreferredSize(new Dimension(80, 224));
        btn7.setMaximumSize(new Dimension(80, 224));

        JButton btn8 = new JButton("BTN8");
        btn8.setBackground(Color.BLUE);
        btn8.setForeground(Color.WHITE);
        btn8.setFont(customFont);
        btn8.setPreferredSize(new Dimension(80, 224));
        btn8.setMaximumSize(new Dimension(80, 224));
        bottomRightPanel.add(btn6);
        bottomRightPanel.add(Box.createHorizontalStrut(8)); 
        bottomRightPanel.add(btn7);
        bottomRightPanel.add(Box.createHorizontalStrut(8)); 
        bottomRightPanel.add(btn8);

        // Add top and bottom panels to the right panel
        rightPanel.add(topRightPanel, BorderLayout.NORTH);
        rightPanel.add(bottomRightPanel, BorderLayout.CENTER);

        // Add panels to the frame
        frame.add(leftPanel, BorderLayout.WEST);
        frame.add(btn3, BorderLayout.CENTER);
        frame.add(rightPanel, BorderLayout.EAST);

        // Set visibility
        frame.setVisible(true);
    }
}

