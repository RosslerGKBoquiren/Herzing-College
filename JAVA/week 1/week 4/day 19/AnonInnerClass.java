/**
 *AnonInnerClass.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 12, 2024
 *2024
 */
package Day3;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 * 
 */
public class AnonInnerClass extends JFrame {

	public AnonInnerClass() {
		this.setTitle("Anonymous Inner Class");
		this.setSize(400, 300);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		JPanel topPan = new JPanel();
		JPanel centerPan = new JPanel();
		
		JButton btnRed = new JButton("Red");
		JButton btnGreen = new JButton("Green");
		JButton btnBlue = new JButton("BLue");
		topPan.add(btnRed);
		topPan.add(btnGreen);
		topPan.add(btnBlue);
		
		btnRed.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				topPan.setBackground(Color.RED);
				centerPan.setBackground(Color.PINK);
				
			}
			
		});
		btnGreen.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				topPan.setBackground(Color.GREEN);
				centerPan.setBackground(Color.YELLOW);
				
			}
			
		});
		
		btnBlue.addActionListener(new ActionListener() {

			@Override
			public void actionPerformed(ActionEvent e) {
				topPan.setBackground(Color.BLUE);
				centerPan.setBackground(Color.CYAN);
				
			}
			
		});
		
		topPan.setBackground(Color.BLACK);
		centerPan.setBackground(Color.DARK_GRAY);
		
		this.add(topPan, BorderLayout.NORTH);
		this.add(centerPan, BorderLayout.CENTER);
		
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}

	public static void main(String[] args) {
		new AnonInnerClass();

	}

}
