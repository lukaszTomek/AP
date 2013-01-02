using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace Wizualizacja
{
    
    class Client
    {
        System.Net.Sockets.TcpClient socket;

        public Client()
        {
            socket = new TcpClient();
        }

        public bool Connect(string IP, int port)
        {
            try{
            socket.Connect(IP, port);
            } 
            catch (SocketException e) 
            {
                System.Windows.Forms.MessageBox.Show("Problem connecting to host");
                Console.WriteLine(e.ToString());
                return true;
            }

            return false;
        }
        public string SendRequest(string data)
        {
            NetworkStream serverStream = socket.GetStream();
            byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
            serverStream.Write(outStream, 0, outStream.Length);
            serverStream.Flush();

            byte[] inStream = new byte[10025];
            serverStream.Read(inStream, 0, (int)socket.ReceiveBufferSize);
            string returndata = System.Text.Encoding.ASCII.GetString(inStream);
            
            return returndata;
        }

        public static string Serialize(MessageInfo msgInfo)
        {
            string msg="";

            return msg;
        }
        public static MessageInfo Deserialize(string msg)
        {
            MessageInfo msgInfo = new MessageInfo();
            // TODO
            return msgInfo;
        }
    }
}
