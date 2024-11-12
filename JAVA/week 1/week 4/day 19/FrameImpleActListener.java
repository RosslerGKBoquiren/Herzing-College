/**
 *FrameImpleActListener.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 6, 2024
 *2024
 */
package Day3;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.BorderFactory;
import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

/**
 * 
 */
public class FrameImpleActListener extends JFrame implements ActionListener {

	JPanel topPan, centerPan;
	JButton btns[] = new JButton[4];
	String btnLbl[] = {"RED", "BLUE", "GREEN", "DEFAULT"};
	
	public FrameImpleActListener() {
		this.setTitle("Main Frame Listener");
		this.setSize(400, 300);
		//this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		topPan = new JPanel();
		centerPan = new JPanel();
		
		topPan.setBackground(Color.BLACK);
		centerPan.setBackground(Color.LIGHT_GRAY);
		
		for(int i = 0; i <btns.length; i++) {
			btns[i] = new JButton(btnLbl[i]);
			topPan.add(btns[i]);
			btns[i].addActionListener(this);
		}
		
		this.add(topPan, BorderLayout.NORTH);
		this.add(centerPan, BorderLayout.CENTER);
		
		this.setLocationRelativeTo(null); 
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
		this.setVisible(true); 
	}

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
	public static void main(String[] args) {
		new FrameImpleActListener();
		//downcasting
		Object obj = new Object();
		obj = "Nasrin";
		String str = (String) obj;
		System.out.println(str);
		//upcasting
		String stri = new String();
		stri = "Nasrin Khodapanah";
		//Object obje = stri;
		Object obje = (Object) stri;
		System.out.println(obje);

	}

}
