package lecture;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class myFrame {

	public static void main(String[] args) {
		JFrame myFrame = new JFrame();
		myFrame.setTitle("This is my first window");
		myFrame.setSize(400, 300);
		myFrame.setAlwaysOnTop(true);
		myFrame.setResizable(false);
		
		//Create Panel
		JPanel pan = new JPanel();
		pan.setBackground(Color.cyan); //Set color to the pan
		
		//add a Button
		JButton button = new JButton();
		button.setText("Button");
		
		//Add the button to the pan
		pan.add(button);				
				
				
		//Add Panel to the Frame
		myFrame.setContentPane(pan);
		myFrame.setLocationRelativeTo(null); // Place the frame in the center of teh sccreen
		myFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		myFrame.setVisible(true); //Display the frame

	}

}
