/**
 *KeyLis.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 19, 2024
 *2024
 */
package Day6;

import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JTextArea;
import javax.swing.JTextField;

/**
 * 
 */
public class KeyLis extends JFrame {

	//Constructor
		public KeyLis() {
			this.setTitle("Key listners");
			this.setSize(500, 200);
			this.setLocationRelativeTo(null);
			
			//Panel 
			JPanel pan = new JPanel();
			
			JLabel label = new JLabel();
			JTextArea txtA = new JTextArea(5,15);
			
			txtA.addKeyListener(new KeyListener() {
				
				@Override
				public void keyTyped(KeyEvent e) {
					// TODO Auto-generated method stub
					
				}
				
				@Override
				public void keyReleased(KeyEvent e) {
					String text = txtA.getText();
					String[] words = text.split("\\s");
					label.setText("words: " + words.length + " Characters: " + text.length());
					
				}
				
				@Override
				public void keyPressed(KeyEvent e) {
					// TODO Auto-generated method stub
					
				}
			});
			
			//key listener
			//this.addKeyListener(new KeyBoardListener());
			pan.add(label);
			pan.add(txtA);
			
			//Add panel to the Frame
			this.setContentPane(pan);
			this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
			this.setVisible(true);
			
		}
		
		//adding an inner class that implements key listener
//		class KeyBoardListener implements KeyListener {
//
//			@Override
//			public void keyTyped(KeyEvent e) {
//				// TODO Auto-generated method stub
//				
//			}
//
//			@Override
//			public void keyPressed(KeyEvent e) {
//				// TODO Auto-generated method stub
//				
//			}
//
//			@Override
//			public void keyReleased(KeyEvent e) {
//				System.out.println("Key code: " + e.getKeyCode() + "\nKey character: " + e.getKeyChar());
//				
//			}
//			
//		}
		
		public static void main(String[] args) {
			new KeyLis();
		}
}
