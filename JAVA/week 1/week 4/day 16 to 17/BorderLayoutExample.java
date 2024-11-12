package lecture;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;

import javax.swing.JFrame;
import javax.swing.JPanel;

public class BorderLayoutExample {

	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("Border Layout Example");
		frame.setSize(400, 300);
		frame.setAlwaysOnTop(true);
		frame.setResizable(false);
		
		//5 Panels
		JPanel pans[] = new JPanel[5];
		
		pans[0] = new JPanel();
		pans[0].setBackground(Color.red);
		frame.add(pans[0], BorderLayout.NORTH );
		pans[0].setPreferredSize(new Dimension(0, 50));
		
		
		pans[1] = new JPanel();
		pans[1].setBackground(Color.GREEN);
		frame.add(pans[1], BorderLayout.SOUTH );
		pans[1].setPreferredSize(new Dimension(0, 50));
		
		pans[2] = new JPanel();
		pans[2].setBackground(Color.BLUE);
		frame.add(pans[2], BorderLayout.EAST );
		pans[2].setPreferredSize(new Dimension(40, 0));

		pans[3] = new JPanel();
		pans[3].setBackground(Color.ORANGE);
		frame.add(pans[3], BorderLayout.WEST );
		pans[3].setPreferredSize(new Dimension(40, 0));
		
		pans[4] = new JPanel();
		pans[4].setBackground(Color.MAGENTA);
		frame.add(pans[4], BorderLayout.CENTER );
		
		/*
		 * Note:
		 * 1. Default Layout of a Frame is ...BorderLayout
		 * 2. Default Layout of a Panel is FlowLayout
		 * 3. NORTH/SOUTH respects the height
		 * 4. EAST/WEST respects the Width
		 * 5. CENTER respects no one!
		 */
		
		
		
		frame.setLocationRelativeTo(null); // Place the frame in the center of the screen
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); //Display the frame

	}

}
