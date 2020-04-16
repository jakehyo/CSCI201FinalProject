using System;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.Net.Sockets;
using System.Text;
//using System.Text.Json;
//using System.Text.Json.Serialization;

namespace Final_Project_Client
{
    public class Client
    {
        // constructor for the client
        private Player player;
		public Socket Socket { get => socket; set => socket = value; }

		static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            bool finishedGame = false;
            Client client = new Client(9999);
            // if log in option is chosen
            //client.logIn();
            // else if the register option is chosen
            //client.registerUser();

            //client.beginGame();

            if (finishedGame)
            {
                client.updateJSON();
            }
            return 0;
        }

        public Client(int port)
        {
            // create network client
            try
            {
                IPEndPoint localendpoint = new IPEndPoint("localhost", port);
                this.Socket = new Socket(ipAddr.AddressFamily,
                   SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    Console.WriteLine("Attempting to connect to port 9999");
                    this.Socket.Connect(localendpoint);
                    Console.WriteLine("Connected to port " + port);

                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }
            }
            catch (Exception e) { 
          
                Console.WriteLine(e.ToString()); 
            }
        }

        public void logIn()
        {
            bool validLogIn = false;
            string username;
            string password;

            while (true)
            {
                // read in username
                // username = read in from menu
                // password = read in from menu

                // send two strings of the username and the password
                byte[] messageSent = Encoding.ASCII.GetBytes(username);
                int byteSent = Socket.Send(messageSent);

                messageSent = Encoding.ASCII.GetBytes(password);
                byteSent = Socket.Send(messageSent);

                // read in response from the server
                byte[] messageReceived = new byte[1024];

                int byteRecv = this.Socket.Receive(messageReceived);
                string response = Encoding.ASCII.GetString(messageReceived,
                                                 0, byteRecv);
                Console.WriteLine("Message from Server -> {0}",
                      Encoding.ASCII.GetString(messageReceived,
                                                 0, byteRecv));

                if (response.Contains("Succesfully Found Your Profile")) {
                    // read JSON object back in
                        // read object for the response to autofill player info
                    // store the object to the client (in player)
                    break;
                }
                else if (response.Contains("No Username Found")) { // make sure to change 
                    // print statement: try again or register
                    // if cancel is chosen
                    // break;

                    // if try again is chosen
                    // loop

                    // if register is chosen
                    registerUser();
                }
                else // incorrect password to the username
				{
                    // if try again
                        // loop

                    // if cancel
                        // break (terminate)
				}
            }
        }

        public void registerUser()
        {
            // reading a new username and password
            // send the two strings to the server

            // if(valid registration)
                // read in the new JSON object
                // assign to the new player 
            // if(username already exists)
                // try again
                // cancel
                // log in
        }

        public void updateJSON()
		{
            // update high-score if it is the new highest
            // update vector of total scores
            // update new game plus if necessary
            // update cosmetics if applicable
            // update weaponid
            // update money (does money get reset if you do not win the game)

            // create an object writer
            // write to the server
            // flush()
		}
    }
}
