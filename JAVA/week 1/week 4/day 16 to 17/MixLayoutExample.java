package lecture;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.FlowLayout;
import java.awt.GridLayout;

import javax.swing.BorderFactory;
import javax.swing.JFrame;
import javax.swing.JPanel;

public class MixLayoutExample {

	public static void main(String[] args) {
		JFrame frame = new JFrame();
		frame.setTitle("This is my first frame");
		frame.setSize(800,1000);
		frame.setResizable(false);
		frame.setAlwaysOnTop(true);
		
		JPanel topPan = new JPanel();
		topPan.setPreferredSize(new Dimension(0, 200));
		topPan.setLayout(new FlowLayout(FlowLayout.CENTER));
		topPan.setBorder(BorderFactory.createEmptyBorder(40, 0 , 0 , 0));
		//topPan.setBackground(Color.red);
		frame.add(topPan, BorderLayout.NORTH);
		
		JPanel toptopPan = new JPanel();
		toptopPan.setPreferredSize(new Dimension(500, 100));
		toptopPan.setBorder(BorderFactory.createLineBorder(Color.BLACK));
		topPan.add(toptopPan);
		
		JPanel eastPan = new JPanel(new FlowLayout(FlowLayout.CENTER));
		eastPan.setPreferredSize(new Dimension(400, 0));
		eastPan.setBorder(BorderFactory.createEmptyBorder(0, 0, 0, 20));
		//eastPan.setBackground(Color.yellow);
		frame.add(eastPan, BorderLayout.EAST);
		
		JPanel eastPan1 = new JPanel(new GridLayout(2, 1, 5, 5));
		eastPan1.setPreferredSize(new Dimension(380, 200));
		
		JPanel eastPan11 = new JPanel();
		JPanel eastPan12 = new JPanel();
		
		eastPan11.setBorder(BorderFactory.createLineBorder(Color.black));
		eastPan12.setBorder(BorderFactory.createLineBorder(Color.black));
		
		eastPan1.add(eastPan11);
		eastPan1.add(eastPan12);
		
		eastPan.add(eastPan1);
		
		JPanel eastPan2 = new JPanel();
		eastPan2.setPreferredSize(new Dimension(380, 245));
		eastPan2.setBorder(BorderFactory.createLineBorder(Color.black));
		eastPan.add(eastPan2);
		
		JPanel westPan = new JPanel();
		westPan.setPreferredSize(new Dimension(380, 0));
		//westPan.setBackground(Color.orange);
		frame.add(westPan, BorderLayout.WEST);
		
		JPanel westPanContainer = new JPanel();
		westPanContainer.setPreferredSize(new Dimension(350, 450));
		westPanContainer.setBorder(BorderFactory.createLineBorder(Color.black));
		westPan.add(westPanContainer);
		
		JPanel botPan = new JPanel();
		botPan.setPreferredSize(new Dimension(0, 300));
		//botPan.setBackground(Color.BLUE);
		frame.add(botPan, BorderLayout.SOUTH);
		
		JPanel botPan1 = new JPanel(new GridLayout(1, 2, 5, 5));
		botPan1.setPreferredSize(new Dimension(250, 280));
		
		JPanel botPan11 = new JPanel();
		JPanel botPan12 = new JPanel();
		
		botPan11.setBorder(BorderFactory.createLineBorder(Color.black));
		botPan12.setBorder(BorderFactory.createLineBorder(Color.black));
		
		botPan1.add(botPan11);
		botPan1.add(botPan12);
		
		botPan.add(botPan1);
		
		JPanel botPan2 = new JPanel();
		botPan2.setPreferredSize(new Dimension(500, 280));
		botPan2.setBorder(BorderFactory.createLineBorder(Color.black));
		botPan.add(botPan2);		
		
		frame.setLocationRelativeTo(null);  //place frame in the middle of screen
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); //close application when frame closes
		frame.setVisible(true); //display frame
		
	}

}
