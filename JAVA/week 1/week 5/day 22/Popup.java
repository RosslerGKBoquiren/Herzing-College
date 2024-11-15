/**
 *Popup.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 19, 2024
 *2024
 */
package Day6;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPopupMenu;
import javax.swing.MenuElement;

/**
 * 
 */
public class Popup extends JFrame implements MouseListener {

	  // java button
    static JButton btn;
 
    // java frame
    private JFrame frame;
    
    // java panel
    private JPanel pan;
 
    // popup menu
    private JPopupMenu popUpMenu;
 
    // default constructor
    Popup()
    {
    	// create a frame
    	JFrame frame = this;
        this.setTitle("Popup");
 
        // set the size of the frame
        this.setSize(400, 400);
 
        this.setLocationRelativeTo(null);
 
        // create anew panel
        pan = new JPanel();
 
         
        // create a button
        btn = new JButton("click");
 
        // addActionListener
        btn.addMouseListener(this);
        pan.add(btn);
        this.setContentPane(pan);
     // close the frame when close button is pressed
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setVisible(true);;
    }
 
    
 
    // main class
    public static void main(String[] args)
    {
        new Popup();
    }

	@Override
	public void mouseClicked(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mousePressed(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		//String s = e.getActionCommand();
        //if (s.equals("click")) {
            // create a popup menu
        	popUpMenu = new JPopupMenu("Message");
 
            // create a label
            JLabel label = new JLabel("this is the popup menu");
 
            // add the label to the popup
            popUpMenu.add(label);
 
            // add the popup to the frame
            popUpMenu.show(e.getComponent(), 50, 50);
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

	@Override
	public void mouseExited(MouseEvent e) {
		// TODO Auto-generated method stub
		
	}

}
