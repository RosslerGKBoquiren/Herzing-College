/**
 *MyFrame.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 7, 2024
 *2024
 */
package Day2;

import javax.swing.JFrame;

/**
 * 
 */
public class MyFrame extends JFrame{
	public MyFrame() {
		this.setTitle("This is my frame.");
		this.setSize(800,350);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		MyPanel mp = new MyPanel();
		this.setContentPane(mp);
		//or i can replace 1st line with the parenthesis content of 2nd line
		//like this.setContentPane(new MyPanel());
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}

}
