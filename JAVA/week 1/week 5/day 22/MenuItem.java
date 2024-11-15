/**
 *MenuItem.java
 *@author Nasrin Khodapanah <nkhodapanah@mtl.herzing.ca>
 *Created on Feb 19, 2024
 *2024
 */
package Day6;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JMenuItem;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JPopupMenu;

/**
 * 
 */
public class MenuItem extends JFrame {

	//Constructor
			public MenuItem() {
				this.setTitle("Menu PopUp");
				this.setSize(500, 200);
				this.setLocationRelativeTo(null);
				JFrame frame = this;
				
				JPanel pan = new JPanel();
				JButton btn = new JButton("Button");
				
				JPopupMenu contextMenu = new JPopupMenu();
				
				JMenuItem editItem = new JMenuItem("Edit");
				
				contextMenu.add(editItem);
				
				JMenuItem saveItem = new JMenuItem("Save");
				
				contextMenu.add(saveItem);
				saveItem.addActionListener(new ActionListener() {
					
					@Override
					public void actionPerformed(ActionEvent e) {
						JOptionPane.showConfirmDialog(
								frame, 
								"Are you going to save this file?",
								"Save",
								JOptionPane.YES_NO_OPTION);
						
					}
				});
				
				JMenuItem saveAsItem = new JMenuItem("Save As");
				
				contextMenu.add(saveAsItem);
				
				contextMenu.addSeparator();
				
				JMenuItem copyItem = new JMenuItem("Copy");
				
				contextMenu.add(copyItem);
				
				JMenuItem deleteItem = new JMenuItem("Delete");
				
				contextMenu.add(deleteItem);
				
				
				pan.setComponentPopupMenu(contextMenu);
				pan.add(btn);
				//Add panel to the Frame
				this.setContentPane(pan);
				this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
				this.setVisible(true);
			}
	public static void main(String[] args) {
		new MenuItem();

	}

}
