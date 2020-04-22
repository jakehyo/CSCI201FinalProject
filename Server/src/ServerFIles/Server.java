package ServerFIles;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;


public class Server {
	public ServerSocket serverSocket;

	public Server(int port) {
		// to do --> implement your constructor
			
			try {
				serverSocket = new ServerSocket(port);
			
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
	}
	public static void main(String[] args) {
		// TODO Auto-generated method stub
		Server server= new Server(9999);
		
		System.out.println("Server is running");
		
		while(true) {
			Socket socket;
			try {
				socket = server.serverSocket.accept();
			
				ServerThread serverThread = new ServerThread(socket);
				System.out.println("Given a Thread");
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		
		}
	}

}
