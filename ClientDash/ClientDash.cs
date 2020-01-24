using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace ClientDash
{


    public partial class ClientDash : Form
    {
        RSAService RSAService = new RSAService();
        //Public SERVER RSA KEY
        RSAParameters ServerPublicRSAKey;
        private Socket sender = null;
        int chatLogItemIndex = 0;
        public ClientDash()
        {
            InitializeComponent();
        }

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

        public T FromByteArray<T>(byte[] data)
        {
            if (data == null)
                return default(T);
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream ms = new MemoryStream(data))
            {
                object obj = bf.Deserialize(ms);
                return (T)obj;
            }
        }

        private void partners_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chat_name_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(this.chat_name.Text))
            {
                this.msg.Enabled = true;
            }
        }



        private void send_button_Click(object sender, EventArgs e)
        {
            SendMsg();
        }



        private void ClientDash_Load(object sender, EventArgs e)
        {
            Lists_Rendering(chat_log);

            Connect();
        }

        private void RecieveMsg()
        {
            byte[] messageReceived = new byte[1024];

            // We receive the messagge using  
            // the method Receive(). This  
            // method returns number of bytes 
            // received, that we'll use to  
            // convert them to string 
            int byteRecv = sender.Receive(messageReceived);
            String msg = Encoding.ASCII.GetString(messageReceived,
                                             0, byteRecv);
            Console.WriteLine("Message from Server -> {0}", msg);
            chat_log.Items.Add(new ListViewItem(msg, this.chatLogItemIndex));
            this.chatLogItemIndex++;
        }

        public void RecieveRSAKey()
        {
            byte[] messageReceived = new byte[1024];

            // We receive the messagge using  
            // the method Receive(). This  
            // method returns number of bytes 
            // received, that we'll use to  
            // convert them to string 
            int byteRecv = sender.Receive(messageReceived);
            Console.WriteLine("Received RSA KEY:{0}" + DisplayBytes(messageReceived));
            this.ServerPublicRSAKey = (RSAParameters)FromByteArray<RSAParameters>(messageReceived);
            chat_log.Items.Add(new ListViewItem("SERVER RSA KEY RECIEVED", this.chatLogItemIndex));
            this.chatLogItemIndex++;
        }

        private void SendMsg()
        {
            byte[] plainMessage = Encoding.ASCII.GetBytes(this.chat_name.Text + ':' + msg.Text);
            // Encrypt the msg with the server  PUBLIC RSA KEY
            byte[] encryptedMessage = this.RSAService.Encryption(plainMessage, ServerPublicRSAKey, false);
            int byteSent = sender.Send(encryptedMessage);

        }
        private void Connect()
        {

            try
            {

                // Establish the remote endpoint  
                // for the socket. This example  
                // uses port 33333 on the local  
                // computer. 
                IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint localEndPoint = new IPEndPoint(ipAddr, 33333);
                //Console.WriteLine("IP-ENDPOINT:" ,localEndPoint.ToString());

                // Creation TCP/IP Socket using  
                // Socket Class Costructor 
                this.sender = new Socket(ipAddr.AddressFamily,
                           SocketType.Stream, ProtocolType.Tcp);


                // Connect Socket to the remote  
                // endpoint using method Connect() 
                sender.Connect(localEndPoint);

                // We print EndPoint information  
                // that we are connected 
                Console.WriteLine("Socket connected to -> {0} ",
                              sender.RemoteEndPoint.ToString());
                int itemIndex = 0;
                chat_log.Items.Add(new ListViewItem("Socket connected to -> {0} " +
                              sender.RemoteEndPoint.ToString(), itemIndex));
                itemIndex++;
                // Generate client RSA KEYS

                //Welcome Msg
                RecieveMsg();
                this.RSAService.GenerateKeys();
                RecieveRSAKey();
                // Manage of Socket's Exceptions 
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

        private void SendDisconnectMsg()
        {
            byte[] plainMessage = Encoding.ASCII.GetBytes(this.chat_name.Text + ':' + "<EOF>");
            // Encrypt the msg with the server  PUBLIC RSA KEY
            byte[] encryptedMessage = this.RSAService.Encryption(plainMessage, ServerPublicRSAKey, false);
            int byteSent = sender.Send(encryptedMessage);
        }


        private void ClientDash_Closed(object sender, FormClosedEventArgs e)
        {
            SendDisconnectMsg();
            try
            {
                this.sender.Shutdown(SocketShutdown.Both);
                this.sender.Close();
            }
            catch (Exception exc)
            {
                Console.WriteLine("Could not close client socket!", exc.ToString());
            }
        }
    }
}
