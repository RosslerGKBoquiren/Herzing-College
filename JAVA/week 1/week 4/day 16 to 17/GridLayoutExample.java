package lecture;

import java.awt.Color;
import java.awt.GridLayout;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class GridLayoutExample {

	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("This is my first window");
		frame.setSize(400, 300);
		frame.setAlwaysOnTop(true);
		frame.setResizable(false);
		
		//Create Panel
		JPanel pan = new JPanel();	
		pan.setLayout(new GridLayout(4, 5, 5, 5));
		pan.setBackground(Color.LIGHT_GRAY);
		
		JButton btns[] = new JButton[20];
		
		for(int i = 0; i < btns.length; i++) {
			btns[i] = new JButton(i + 1 + "");
			pan.add(btns[i]);
		}
		
				
		//Add Panel to the Frame
		frame.setContentPane(pan);
		frame.setLocationRelativeTo(null); // Place the frame in the center of the screen
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); //Display the frame

	}

}
