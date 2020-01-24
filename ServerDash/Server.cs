using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ServerDash
{
    public partial class ServerDash : Form
    {

        // Tests the server whether is connected or not
        bool state = false;
        Socket listener = null;
        List<Socket> clientSockets = new List<Socket>();
        List<String> clientsNames = new List<String>();
        int connectedClientsIndex = 0;
        Thread recieveThread = null;
        // Recieves clients public keys for futher sends operations
        // dynamic clientsPublicKeys = null;
        int itemIndex = 0;
        RSAService RSAService = new RSAService();
        int currentClientIndex = -1;


        public String DisplayBytes(byte[] msg)
        {
            String str = "";
            foreach (var b in msg)
            {
                str += (char)b;
            }
            return str;
        }

        public void Lists_Rendering(dynamic list)
        {
            list.View = View.List;
            list.GridLines = true;
        }


        //Converts instance to a byte[] to send via the TCP Socket
        byte[] ObjectToByteArray(object obj)
        {
            if (obj == null)
                return null;
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }





        private void Connect()
        {
            // Establish the local endpoint  
            // for the socket. Dns.GetHostName 
            // returns the name of the host  
            // running the application. 
            IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 33333);
            Console.WriteLine("IP-ENDPOINT:", localEndPoint.ToString());

            // Creation TCP/IP Socket using  
            // Socket Class Costructor 
            this.listener = new Socket(ipAddr.AddressFamily,
                         SocketType.Stream, ProtocolType.Tcp);

            try
            {

                // Using Bind() method we associate a 
                // network address to the Server Socket 
                // All client that will connect to this  
                // Server Socket must know this network 
                // Address 
                listener.Bind(localEndPoint);

                // Using Listen() method we create  
                // the Client list that will want 
                // to connect to Server 
                listener.Listen(10);

                logs_list.Items.Add(new ListViewItem("Connection Established !", itemIndex));
                this.itemIndex++;

                RSAService.GenerateKeys();
                logs_list.Items.Add(new ListViewItem("RSA keys generated !", itemIndex));
                this.itemIndex++;

                logs_list.Items.Add("Waiting for connections ...");
                this.itemIndex++;
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }
        }

        public void SendMsg(Socket clientSocket, byte[] msg)
        {
            clientSocket.Send(msg);
        }




        public void AcceptClients()
        {

            this.recieveThread = new Thread(RecieveMsg);
            while (true)
            {
                // Suspend while waiting for 
                // incoming connection Using  
                // Accept() method the server  
                // will accept connection of client 
                try
                {
                    Socket clientSocket = listener.Accept();
                    clientSockets.Add(clientSocket);
                    currentClientIndex++;
                    // Data buffer 


                    // Start recieving msgs from the client
                    recieveThread.Start();




                    byte[] message = Encoding.ASCII.GetBytes("You are connected to the server !!!");
                    // Console.WriteLine(DisplayBytes(encryptedtext));
                    // Send a message to Client  
                    // using Send() method 
                    SendMsg(clientSocket, message);

                    byte[] RSAKey = ObjectToByteArray(this.RSAService.RSAParamsPublic);
                    Console.WriteLine("Sent RSA key:" + DisplayBytes(RSAKey));
                    SendMsg(clientSocket, RSAKey);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Client disconnected !");
                }





            }
        }

        //Recieve Wheel Method
        private void RecieveMsg()
        {
            while (true)
            {
                byte[] encryptedMsg = new Byte[128];
                byte[] decryptedMsg = new Byte[128];



                int numByte = clientSockets[currentClientIndex].Receive(encryptedMsg);

                Console.WriteLine("Recieved encrypted msg from client" + DisplayBytes(encryptedMsg));
                decryptedMsg = this.RSAService.Decryption(encryptedMsg, this.RSAService.RSAParamsPrivate, false);
                Console.WriteLine("Decrypted msg from client" + decryptedMsg);

                try
                {
                    String msg = Encoding.ASCII.GetString(decryptedMsg);
                    String[] msgArray = msg.Split(':');
                    // Managing connected clients list

                    bool existant = clientsNames.Contains(msgArray[0]);
                    Console.WriteLine("Existance test:" + existant);
                    if (existant == false) // client name not in connected clients name
                    {
                        if (!msgArray[1].Equals("<EOF>"))
                        {

                            clientsNames.Add(msgArray[0]);
                            int index = clientsNames.IndexOf(msgArray[0]);
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { connected_clients_list.Items.Add(new ListViewItem(msgArray[0], index)); });
                        }
                    }
                    else //Found 
                    {
                        if (msgArray[1].Equals("<EOF>"))
                        { //Disconnect msg recieved

                            int index = clientsNames.IndexOf(msgArray[0]);
                            clientsNames.Remove(msgArray[0]);
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { connected_clients_list.Items.RemoveAt(index); });
                        }
                    }
                    this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { logs_list.Items.Add(new ListViewItem(msg, itemIndex)); });
                    itemIndex++;
                }
                catch (Exception e)
                {
                    Console.WriteLine("No Msgs Recieved ...");
                }
            }
        }

        public void ExecuteServer()
        {

            Connect();
            //Server is connected
            state = true;
            Lists_Rendering(logs_list);

            Thread th = new Thread(AcceptClients);
            th.Start();
        }


        public ServerDash()
        {
            InitializeComponent();

        }


        private void ServerDash_Load(object sender, EventArgs e)
        {

        }




        private void connect_button_clicked(object sender, EventArgs e)
        {

            ExecuteServer();
        }

        private void ServerDash_Closing(object sender, FormClosingEventArgs e)
        {
            if (state == true)
            {
                // Stop the recieving thread to stop recieving from clients in the background
                this.recieveThread.Abort();
                try
                {
                    listener.Close();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Failed closing server socket" + exc.Message);
                }
                //Closing clients sockets
                clientSockets.ForEach((s) =>
                {
                    s.Shutdown(SocketShutdown.Both);
                    s.Close();
                });
            }
        }
    }
}
