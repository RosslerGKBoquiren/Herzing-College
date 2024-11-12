package lecture;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.util.Random;

import javax.swing.BoxLayout;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class BoxLayoutSample {

	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("BoxLayout Example");
		frame.setSize(800, 800);
		frame.setAlwaysOnTop(true);
		//frame.setResizable(false);
		
		JPanel pan1 = new JPanel();
		pan1.setLayout(new BoxLayout(pan1, BoxLayout.PAGE_AXIS));
		pan1.setBackground(Color.BLUE);
		pan1.setPreferredSize(new Dimension(400, 0));

		Random r = new Random();
		JButton btns1[] = new JButton[15];
		
		for(int i = 0; i < btns1.length; i++) {
			btns1[i] = new JButton(i + 1 + "");
			btns1[i].setMaximumSize( new Dimension(r.nextInt(75)+25, r.nextInt(75)+25));
			pan1.add(btns1[i]);
		}
		
		JPanel pan2 = new JPanel();
		pan2.setLayout(new BoxLayout(pan2, BoxLayout.LINE_AXIS));
		pan2.setBackground(Color.CYAN);
		pan2.setPreferredSize(new Dimension(400, 0));
		
		JButton btns2[] = new JButton[10];
		
		for(int i = 0; i < btns2.length; i++) {
			btns2[i] = new JButton(i + 1 + "");
			btns2[i].setMaximumSize(new Dimension(r.nextInt(75)+25, r.nextInt(75)+25));
			pan2.add(btns2[i]);
		}
		
		frame.add(pan1, BorderLayout.WEST);
		frame.add(pan2, BorderLayout.EAST);
		
		frame.setLocationRelativeTo(null); // Place the frame in the center of the screen
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true); //Display the frame

	}

}
