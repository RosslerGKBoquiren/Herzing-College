package lecture;

import java.awt.Color;
import java.awt.Dimension;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class FlowLayoutSample {

	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("Flow Layout Example");
		frame.setSize(400,300);
		frame.setResizable(true);
		frame.setAlwaysOnTop(true);
		
		JPanel pan = new JPanel();
		pan.setBackground(Color.darkGray);
		
		JButton btns[] = new JButton[15];
		
		for(int i = 0; i < btns.length; i++) {
			btns[i] = new JButton(i + 1 + "");
			btns[i].setPreferredSize(new Dimension(50, 50));
			pan.add(btns[i]);
		}
		
		
		frame.setContentPane(pan);
		frame.setLocationRelativeTo(null);  //place frame in the middle of screen
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //close application when frame closes
		frame.setVisible(true); //display frame

	}

}
