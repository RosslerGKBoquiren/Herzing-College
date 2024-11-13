package sendingACommentPackage;

import java.util.HashMap;

import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.JTextArea;

public class SendingAComment extends JFrame {
	// to store username and passwords
	private HashMap<String, String> users; 
	
	
	public SendingAComment() {
		// initialize user data username and password
		users = new HashMap<>();
		users.put("Ross", "pass0806");
		users.put("John", "pass3228");
		
		
		// setup main frame
		setTitle("Write a Comment");
		setSize(300, 200);
		setLocationRelativeTo(null);
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		
		
		// button to start writing a comment
		JButton writeCommentButton = new JButton("Write a comment");
		writeCommentButton.addActionListener(event -> startCommentProcess());
		
		
		// add button to frame
		add(writeCommentButton);
		setVisible(true);
	}
	
	
	private void startCommentProcess() {
		int choice = JOptionPane.showConfirmDialog(this, "Do you want to write a comment?", "Confirmation", JOptionPane.YES_NO_OPTION);
		if (choice == JOptionPane.YES_OPTION) {
			login();
		}
	}
	
	
	
	private void login() {
		String username;
		String password;
		
		
		// username prompt
		while (true) {
	        username = JOptionPane.showInputDialog(this, "Enter your username:");
	        
	        if (username == null) {  
	            JOptionPane.showMessageDialog(this, "Login canceled.");
	            return;
	        }

	        if (users.containsKey(username)) {  
	            break;
	        } else { 
	            JOptionPane.showMessageDialog(this, "Invalid username, please try again.");
	        }
	    }
		
		
		// password prompt
		while (true) {
	        password = JOptionPane.showInputDialog(this, "Enter your password:");
	        
	        if (password == null) {  
	            JOptionPane.showMessageDialog(this, "Login canceled.");
	            return;
	        }

	        if (password.equals(users.get(username))) {  
	        	// Successful login
	            JOptionPane.showMessageDialog(this, "          Welcome " + username + "!");
	            openCommentWindow(username);
	            break;
	        } else {  
	            JOptionPane.showMessageDialog(this, "Incorrect password, please try again.");
	        }
	    }
	}
	
	
	private void openCommentWindow(String username) {
		JFrame commentFrame = new JFrame("Comment Area");
		commentFrame.setSize(380, 245);
		commentFrame.setLocationRelativeTo(null);
		
		
		JTextArea commentArea = new JTextArea(10, 30);
		JButton sendButton = new JButton("Send");
		JButton logoutButton = new JButton("Log out");
		
		
		sendButton.addActionListener(event -> {
			String comment = commentArea.getText();
			if(!comment.trim().isEmpty()) {
				JOptionPane.showMessageDialog(commentFrame, "Comment: " + comment);
			} else {
				JOptionPane.showMessageDialog(commentFrame, "Comment cannot be blank.");
			}
		});
		
		
		logoutButton.addActionListener(event -> {
			commentFrame.dispose();
			JOptionPane.showMessageDialog(this, "          Goodbye " + username + "!");
		});
		
		JPanel panel = new JPanel();
        panel.add(new JScrollPane(commentArea));
        panel.add(sendButton);
        panel.add(logoutButton);

        commentFrame.add(panel);
        commentFrame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        commentFrame.setVisible(true);
	}
	
	public static void main(String[] args) {
		new SendingAComment();
	}

}
