/**
 *LabelClass.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 12, 2024
 *2024
 */
package Day3;

import java.awt.Font;
import java.awt.Image;

import javax.swing.ImageIcon;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

/**
 * 
 */
public class LabelClass extends JFrame {
	public LabelClass() {
		this.setTitle("My Label Class");
		this.setSize(400, 300);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		JPanel pan = new JPanel();
		JLabel lbl1 = new JLabel("This is my first label");
		Font f1 = new Font("Consolas", Font.PLAIN, 30);
		lbl1.setFont(f1);
		
		JLabel lbl2 = new JLabel();
		ImageIcon icon = new ImageIcon("images\\sport-congresse.jpg");
		Image img = icon.getImage().getScaledInstance(icon.getIconWidth()/10, icon.getIconHeight()/10,Image.SCALE_SMOOTH );
		ImageIcon icon2 = new ImageIcon(img);
		
		lbl2.setIcon(icon2);

		pan.add(lbl1);
		pan.add(lbl2);
		
		this.setContentPane(pan);
		
		this.setLocationRelativeTo(null); 
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); 
		this.setVisible(true);
	}
	public static void main(String[] args) {
		new LabelClass();

	}

}
