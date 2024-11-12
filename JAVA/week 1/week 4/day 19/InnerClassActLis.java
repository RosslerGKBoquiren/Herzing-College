/**
 *InnerClassActLis.java
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
public class InnerClassActLis extends JFrame {
	JPanel topPan, centerPan;
	public InnerClassActLis() {
		this.setTitle("Inner Class Action Listener");
		this.setSize(400, 300);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		topPan = new JPanel();
		centerPan = new JPanel();
		
		JButton btnRed = new JButton("RED");		
		JButton btnGreen = new JButton("GREEN");
		JButton btnBlue = new JButton("BLUE");
	
		topPan.add(btnRed);
		topPan.add(btnGreen);
		topPan.add(btnBlue);
		
		btnRed.addActionListener(new ChangeBgColor());
		btnGreen.addActionListener(new ChangeBgColor());
		btnBlue.addActionListener(new ChangeBgColor());
		
		topPan.setBackground(Color.BLACK);
		centerPan.setBackground(Color.LIGHT_GRAY);
		
		this.add(topPan, BorderLayout.NORTH);
		this.add(centerPan, BorderLayout.CENTER);
		
		this.setLocationRelativeTo(null); 
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
		this.setVisible(true);
	}
	
	public static void main(String[] args) {
		new InnerClassActLis();
	}
	class ChangeBgColor implements ActionListener {

		@Override
		public void actionPerformed(ActionEvent e) {
			JButton btn = (JButton) e.getSource();
			
			switch (btn.getText()) {
			case "RED":
				topPan.setBackground(Color.RED);
				centerPan.setBackground(Color.PINK);
				break;
			case "BLUE":
				topPan.setBackground(Color.BLUE);
				centerPan.setBackground(Color.CYAN);
				break;
			case "GREEN":
				topPan.setBackground(Color.GREEN);
				centerPan.setBackground(Color.YELLOW);
				break;
			default:
				topPan.setBackground(Color.BLACK);
				centerPan.setBackground(Color.LIGHT_GRAY);			
			}
			
		}
		
	}

}
