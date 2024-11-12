/**
 *AbsolutePosition.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 8, 2024
 *2024
 */
package Day2;

import java.awt.Color;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 * 
 */
public class AbsolutePosition {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("Absolute Positioning");
		frame.setSize(400,300);
		frame.setResizable(true);
		frame.setAlwaysOnTop(true);
		frame.setLayout(null);
		
		JPanel pan = new JPanel();
		pan.setBackground(Color.RED);
		pan.setBounds(150, 25, 100, 200);
		
		JButton btn = new JButton("Click");
		pan.add(btn);
		btn.setBounds(20, 30, 70, 30);
		
		frame.setContentPane(pan);
		frame.setLocationRelativeTo(null);
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);

	}

}
