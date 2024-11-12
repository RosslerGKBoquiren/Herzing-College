/**
 *Practice.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 11, 2024
 *2024
 */
package Day3;

import java.awt.BorderLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextField;

/**
 * 
 */
public class Practice extends JFrame implements ActionListener {
	JTextField textfield;
	JLabel labelPrint = new JLabel();
	public Practice() {
		this.setTitle("Practice");
		this.setSize(600, 300);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		JPanel pan = new JPanel();
		
		JLabel lab = new JLabel("Name: ");
		textfield = new JTextField(20);
		JButton btn = new JButton("Save");
		
		pan.add(lab);
		pan.add(textfield);
		pan.add(btn);
		pan.add(labelPrint);
		//add an anonymous inner class to btn that is a listener for action event
		/*
		 * btn.addActionListener(new ActionListener() {
		 * 
		 * @Override public void actionPerformed(ActionEvent e) {
		 * System.out.println("Button Clicked");
		 * 
		 * }
		 * 
		 * });
		 */
		//making entire frame listen for action event.
		btn.addActionListener(this);
		
		
		this.add(pan, BorderLayout.CENTER);
		
		
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}
	public static void main(String[] args) {
		new Practice();

	}
	/* When the user clicks the onscreen button, the button fires an action event. 
	 * This results in the invocation of the action listener's actionPerformed method 
	 * (the only method in the FrameImpleActListener interface). 
	 * The single argument to the method is an ActionEvent object that gives information 
	 * about the event and its source.
	 */
	@Override
	public void actionPerformed(ActionEvent e) {
		System.out.println("Button Clicked");
		System.out.println(textfield.getText());
		labelPrint.setText(textfield.getText());
		
	}
	

}
