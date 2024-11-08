package drawingPackage;

import java.awt.BasicStroke;
import java.awt.Color;
import java.awt.Font;
import java.awt.FontMetrics;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.Image;
import java.io.File;

import javax.imageio.ImageIO;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class drawing extends JPanel{

	// Image object
	private Image img;
	// drawing constructor to load image from src
	public drawing() {
		try {
			img = ImageIO.read(new File("src/charizard.jpg"));
		} catch (Exception error) {
			error.printStackTrace();
		}
	}
	
	// Customize and clears the drawing on the panel
	// then casting Graphics2D for enhanced drawing capabilities
	@Override
	protected void paintComponent(Graphics graphics) {
		super.paintComponent(graphics);
		Graphics2D graphics2d = (Graphics2D) graphics;
		
		
		// drawing the String with SWAG
		Font font = new Font("Serif", Font.BOLD | Font.ITALIC, 48);
        graphics2d.setFont(font);
		
        String text = "Rossler Boquiren";
		
        FontMetrics metrics = graphics2d.getFontMetrics(font);
        int stringWidth = metrics.stringWidth(text);
        int stringHeight = metrics.getHeight();
        
        int rectX = 200;
        int rectY = 200;
        int rectWidth = 400;
        int rectHeight = 100;
        
        int stringX = rectX + (rectWidth - stringWidth) / 2;
        int stringY = rectY + (rectHeight - stringHeight) / 2 + metrics.getAscent();
        
        int charX = stringX;
        for (int i = 0; i < text.length(); i++) {
            char ch = text.charAt(i);
            if (i % 2 == 0) {
                graphics2d.setColor(Color.BLUE);
            } else {
                graphics2d.setColor(Color.RED);
            }
            graphics2d.drawString(String.valueOf(ch), charX, stringY);
            charX += metrics.charWidth(ch);
        }
        
        
        // drawing the Rounded Rectangle
        graphics2d.setStroke(new BasicStroke(3));
        graphics2d.setColor(Color.BLACK);
        
        graphics2d.drawRoundRect(rectX, rectY, rectWidth, rectHeight, 30, 30);
        
        
        // drawing the Image
        if (img != null) {
            int imgX = 300; 
            int imgY = 305; 
            int imgSize = 200; 
            graphics2d.drawImage(img, imgX, imgY, imgSize, imgSize, this);
        }
        
        
        // drawing the Circle
        int frameSize = 800;
        int circleDiameter = 300;
        int circleX = (frameSize - circleDiameter) / 2;
        int circleY = (frameSize - circleDiameter) / 2;
        graphics2d.setColor(Color.GREEN);
        graphics2d.setStroke(new BasicStroke(2));
        graphics2d.drawOval(circleX, circleY, circleDiameter, circleDiameter);
        
        
        // drawing the Filled Oval
        int ovalX = 200; 
        int ovalY = 550; 
        int ovalWidth = 150; 
        int ovalHeight = 80; 
        graphics2d.setColor(Color.RED);
        graphics2d.fillOval(ovalX, ovalY, ovalWidth, ovalHeight);
        
        
        // drawing the Polygon
        int centerX = 600; 
        int centerY = 100; 
        int sides = 6; 
        int radius = 80; 
        int[] xPoints = new int[sides];
        int[] yPoints = new int[sides];

        for (int i = 0; i < sides; i++) {
            xPoints[i] = centerX + (int) (radius * Math.cos(i * 2 * Math.PI / sides));
            yPoints[i] = centerY + (int) (radius * Math.sin(i * 2 * Math.PI / sides));
        }

        graphics2d.setColor(Color.CYAN);
        graphics2d.drawPolygon(xPoints, yPoints, sides);
	}
	
	// setting frame size to 800x800px
	 public static void main(String[] args) {
		 JFrame frame = new JFrame("Drawing Practice");
	        frame.setSize(800, 800);
	        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	        frame.add(new drawing());
	        frame.setVisible(true);
	    }

}
