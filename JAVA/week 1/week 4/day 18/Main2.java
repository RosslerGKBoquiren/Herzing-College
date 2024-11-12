/**
 *Main2.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 8, 2024
 *2024
 */
package Day2;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Image;
import java.io.File;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import javax.swing.JPanel;


class Main2 {

	/**
	 * @param args
	 */
	public static void main(String[] args) {
		MyFrame2 mf = new MyFrame2();

	}

}
 class MyFrame2 extends JFrame{
	public MyFrame2() {
		this.setTitle("This is my frame2.");
		this.setSize(800,300);
		this.setResizable(false);
		this.setAlwaysOnTop(true);
		
		this.setContentPane(new MyPanel2());
		
		this.setLocationRelativeTo(null);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		this.setVisible(true);
	}

}
 class MyPanel2 extends JPanel{
	/*
	 * public MyPanel() { this.setBackground(Color.BLUE); JButton btn = new
	 * JButton("Text"); this.add(btn);
	 * 
	 * }
	 */
	@Override
	public void paintComponent(Graphics g) {
		super.paintComponent(g);
		
		g.setColor(Color.RED);
		g.drawRect(50, 50, 100, 150);
		
		g.setColor(Color.BLUE);
		g.fillOval(160, 50, 70, 150);
		
		Font f = new Font("Arial",Font.BOLD,20);
		g.setFont(f);
		g.setColor(Color.magenta);
		g.drawString("Herzing", 240, 130);
		
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