/**
 *MyPanel.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 7, 2024
 *2024
 */
package Day2;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.awt.RenderingHints;
import java.io.File;

import javax.imageio.ImageIO;
import javax.swing.JPanel;

/**
 * 
 */
public class MyPanel extends JPanel{
	/*
	 * public MyPanel() { this.setBackground(Color.BLUE); JButton btn = new
	 * JButton("Text"); this.add(btn);
	 * 
	 * }
	 */
	@Override
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		Graphics2D g2 = (Graphics2D) g;
		 g2.setStroke(new BasicStroke(5));
		g.setColor(Color.RED);
		g.drawRect(50, 50, 100, 150);
		
		g.setColor(Color.BLUE);
		g.drawOval(160, 50, 70, 150);
		
		Font f = new Font("Arial",Font.BOLD,20);
		g.setFont(f);
		g.setColor(Color.magenta);
		g.drawString("Herzing", 240, 130);
		g.setColor(Color.black);
		g2.setRenderingHint(RenderingHints.KEY_ANTIALIASING, RenderingHints.VALUE_ANTIALIAS_ON);
		g.drawRoundRect(450, 200, 200, 100, 50, 50);
		int[] x = {320, 320, 420, 520, 420};
		int[] y = {50, 250, 230, 150, 70};
		g.drawPolygon(x,y,5);
		
		try {
			Image img = ImageIO.read(new File("C:\\Users\\nasri\\OneDrive\\Pictures\\Screenshots\\ant.jpg"));
			g.drawImage(img, 550, 50, 200, 100, this);
		}catch (Exception e) {
			e.printStackTrace();
		}
		
	}
		
	
}
