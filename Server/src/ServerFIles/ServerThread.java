package ServerFIles;

import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.FileNotFoundException;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.PrintStream;
import java.net.Socket;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.List;
import java.util.Vector;

import com.google.gson.Gson;
import com.google.gson.JsonObject;

public class ServerThread extends Thread{

	Socket socket;
	ObjectOutputStream os;
	ObjectInputStream is;
	Connection conn = null;
	Statement st = null;
	Statement tt = null;
	PreparedStatement ps = null;
	PreparedStatement tp = null;
	ResultSet rs = null;
	ResultSet ts = null;
	Example PlayersData;
	Player player;
	int player_id;
	int cosmetic_id;
	public ServerThread(Socket s) {
		try {
			// to do --> store them somewhere, you will need them later 
			is = new ObjectInputStream(s.getInputStream());
			os = new ObjectOutputStream (s.getOutputStream());
			conn = DriverManager.getConnection("jdbc:mysql://localhost/PoppinRobots?user=root&password=1216&serverTimezone=UTC");
			st = conn.createStatement();
			
			// rs = st.executeQuery("SELECT * from Student where fname='" + name + "'");
			
			socket = s;
			
			this.start();
			
			// to do --> complete the implementation for the constructor
			
			
			
			
			
			
		}catch(FileNotFoundException e) {
			System.out.println("No such file exists.");
		}catch (IOException ioe) {
			System.out.println("ioe in ServerThread constructor: " + ioe.getMessage());
		} catch (SQLException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		
	
	}
	public void run() {
		Gson gson = new Gson();
		while (true) {
			try {
				
			//grab the jsonObjects from the finished game mode
			
				String command = (String)is.readObject();
				if (command.contentEquals("Login")){ //read in that we are logging in from client.
					JsonObject json = (JsonObject) is.readObject();
					player = gson.fromJson(json, Player.class);
					String player_name = player.getNAME();
					ps = conn.prepareStatement("SELECT g.*, s.* IF(g.NAME = "+ player_name + ",'true','false') AS FLAG, FROM Player g inner join Cosmetics s on g.CosmeticID = s.ID" ); //Select the skin and highscore for the client to use and send over as a jsonObject.
					rs = ps.executeQuery();
					boolean found_player = false;
					List<Integer> high_scores = null;
					List<Boolean> Cosmetics = null;
					while(rs.next()) {
						boolean flag = rs.getBoolean("FLAG");
						int hs = rs.getInt("HighScore");
						if(flag) {
							cosmetic_id = rs.getInt("CosmeticID");
							player.setHighScore(hs);
							player.setMoney(rs.getInt("Money"));
							player.setPlayerID(rs.getInt("PlayerID"));
							player.setNewGamePlus(rs.getBoolean("NewGamePlus"));
							player.setWeaponID(rs.getInt("WeaponID"));
							Cosmetics.add(rs.getBoolean("GoldFit"));
							Cosmetics.add(rs.getBoolean("RedFit"));
							Cosmetics.add(rs.getBoolean("BlueFit"));
							Cosmetics.add(rs.getBoolean("BlackFit"));
							player.setCosmetic(Cosmetics);
							found_player = true;
						}
						high_scores.add(hs);
					}
					player.setAllHighScore(high_scores);
					String response;
					if ( found_player) {
						response = "Successfully Found Your Profile!";
						os.writeObject(response);
						os.flush();
						response = gson.toJson(player,Player.class);
						os.writeObject(response);
						os.flush();
					}
					else {
						response = "No Player ID Found. Please Try Again";
						os.writeObject(response);
						os.flush();
					}
				}
				if ( command.contentEquals("Create New")) {
					JsonObject json = (JsonObject) is.readObject();
					player = gson.fromJson(json, Player.class);
//					player_id = player.getPlayerID();
					String NAME = player.getNAME();
					ps = conn.prepareStatement("INSERT INTO Cosmetics ( GoldFit, RedFit,BlueFit,BlackFit) values (0,0,0,0);" );
					rs = ps.executeQuery();
					ps = conn.prepareStatement("INSERT INTO Player (NAME,HighScore, NewGamePlus,WeaponID,Money) values ( "+ NAME+", 0,false,0, 0);");
					rs = ps.executeQuery();
					String response = "Created New Player!";
					os.writeObject(response);
					os.flush();
				
				}
				if ( command.contentEquals("Mission Completed")) {
					JsonObject json = (JsonObject) is.readObject();
					player = gson.fromJson(json, Player.class);
					player_id = player.getPlayerID();
					String Name = "NAME = '"+player.getNAME()+"',";
					String HighScore = "HighScore = "+player.getHighScore()+",";
					String NewGamePlus = "NewGamePlus = " + player.getNewGamePlus()+",";
					String WeaponID = "WeaponID = " + player.getWeaponID()+ ",";
					String Money = "Money = " + player.getMoney();
					
					ps=conn.prepareStatement("UPDATE Player SET "+Name+ HighScore + NewGamePlus + WeaponID + Money + "WHERE PlayerID = "+player_id+ ";");
					rs= ps.executeQuery();
					List<Boolean> Cosmos = player.getCosmetic();
					String White = "WhiteFit = '" + Cosmos.get(0) + "',";
					String Red = "RedFit = '" + Cosmos.get(1) + "',";
					String Blue = "BlueFit = '" + Cosmos.get(2) + "',";
					String Black = "BlackFit = '" + Cosmos.get(3) + "'";
					ps = conn.prepareStatement("UPDATE Cosmetics SET "+White + Red +Blue +Black+ "WHERE ID = "+cosmetic_id +";");
					rs = ps.executeQuery();
					
					String response = "Succesfully Saved!";
					os.writeObject(response);
					os.flush();
					
				}
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (ClassNotFoundException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
		}
	}

}
