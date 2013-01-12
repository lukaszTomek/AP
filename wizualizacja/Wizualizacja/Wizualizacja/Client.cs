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
        
        string ip;
        int port;

        public Client()
        {
            socket = new TcpClient();
        }

        public bool Connect(string IP, int port)
        {
            ip = IP;
            this.port = port;

            try{
            socket.Connect(IP, port);
            } 
            catch (SocketException e) 
            {
                //System.Windows.Forms.MessageBox.Show("Problem connecting to host");
                Console.WriteLine(e.ToString());
                return true;
            }
            return false;
        }
        public string SendRequest(string data)
        {

            try
            {
                if(port==5678)
                    Console.WriteLine(data);
                NetworkStream serverStream = socket.GetStream();
                byte[] outStream = System.Text.Encoding.ASCII.GetBytes(data);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                byte[] inStream = new byte[10025];
                serverStream.Read(inStream, 0, (int)socket.ReceiveBufferSize);
                string returndata = System.Text.Encoding.ASCII.GetString(inStream);

                return returndata;

                
            }
            catch (Exception)
            {

                System.Windows.Forms.MessageBox.Show("Problems with connection");
                return "";
            }
            
            
        }

        public string Serialize(MessageInfo msgInfo)
        {
            string msg="";
            switch(msgInfo.reqType)
            {
                case RequestType.addSuitcase:
                {
                    msg += "0";
                    msg += msgInfo.suitcasesArray[0].toString();

                    break;
                }

                case RequestType.addPlane:
                {
                    msg += "1";
                    msg += msgInfo.planesArray[0].toString();
                    Console.WriteLine(msg);
                    break;
                }

                case RequestType.dropSuitcaseFromConveyor:
                {
                    msg += "2";
                    
                    //dopisac numer ktory zepsuc
                    break;
                }
                case RequestType.hurtConveyor:
                {
                    msg += "3";
                    //dopisac numer ktory wyrzucic
                    break;
                }
                case RequestType.getFullState:
                {
                    msg += "4";
                    break;
                }
                case RequestType.getState:
                {
                    msg += "5";
                    break;
                }
            }
            return msg;
        }


        public MessageInfo Deserialize(string msg)
        {
            MessageInfo msgInfo = new MessageInfo();
            //if (port == 5678) 
            //    Console.WriteLine("dostalem " + msg);
            if (msg == "")
            {
                System.Windows.Forms.MessageBox.Show(port.ToString());

                return msgInfo;
            }
            switch (((int)msg[0] - (int)'0'))
            {
                case 0:
                    {
                        msgInfo.problems = true;
                        break;
                    }
                case 1:
                    {
                        msgInfo.problems = false;
                        break;
                    }
                case 2:
                    {
                        msgInfo.problems = true;
                        break;
                    }
                case 3:
                    {
                        msgInfo.problems = true;
                        break;
                    }
                case 4:
                    {
                        msgInfo = getFullState(msg);
                        break;
                    }
                case 5:
                    {
                        msgInfo = getState(msg);
                        break;
                    }
                default:
                    {
                        //Console.WriteLine("Error of deserialization. Unknown request type");
                        break;
                    }
            }

            return msgInfo;
        }

        public static MessageInfo getFullState(string msg)
        {
            MessageInfo MI = new MessageInfo();
            int i = 0;
            int step = 0;
            int start = 1;
            int suitcase_id = 0, plane_id = 0, weight = 0, c_id = 0, progress = 0;
            int comp_id = 0, state = 0;
            int p_id = 0, time = 0, sleeve = 0;
            selectedDangerous danger=selectedDangerous.NONE;
            Suitcase s;
            StateInfo c;
            Plane p;
            
            string val;

            MI.maxPlaneId = -1;
            MI.maxSuitcaseId = -1;
            //string msg = "014,43222,33,n,1043,50,;14324,22,33,n,1990,50,;/15190,22,;17,12,;/152,215,1,;8099,151,2,;151,122,3,;/152,215,;8099,151,;/0/1/12/10/";
            /*suitcaseinfo*/
            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        suitcase_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 1)
                    {
                        plane_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 2)
                    {
                        weight = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }

                    if (step == 3)
                    {
                        val = msg.Substring(start, i - start);
                        if (val == "n")
                        { danger = selectedDangerous.DRUGS; }
                        else if (val == "w")
                        { danger= selectedDangerous.EXPLOSIVES;}
                        else if (val == "0")
                        { danger = selectedDangerous.NONE; }
                        else
                        { /*Console.WriteLine("Error of drug/bomb value"); */}
                        start = i + 1;
                        step++;


                        continue;
                    }
                    if (step == 4)
                    {
                        c_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 5)
                    {
                        progress = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }

                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    if (suitcase_id > MI.maxSuitcaseId)
                        MI.maxSuitcaseId = suitcase_id;
                    s=new Suitcase(danger, suitcase_id, weight, plane_id, c_id, progress);
                    MI.suitcasesArray.Add(s);
                    
                    //Console.WriteLine("NEXT ITEM");
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }
            }

           // Console.WriteLine("Components");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        comp_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 1)
                    {
                        state = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    c = new StateInfo(comp_id,state);
                    MI.statesArray.Add(c);
                    /*Console.WriteLine(comp_id);
                    Console.WriteLine(state);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                   // Console.WriteLine("END");
                    break;
                }

            }


            //Console.WriteLine("Planes");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        p_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 1)
                    {
                        time = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 2)
                    {
                        sleeve = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    if (p_id > MI.maxPlaneId)
                        MI.maxPlaneId = p_id;
                    p = new Plane(p_id, time, sleeve);
                    MI.planesArray.Add(p);

                    /*Console.WriteLine(p_id);
                    Console.WriteLine(time);
                    Console.WriteLine(sleeve);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }

            }

            //Console.WriteLine("Planes Array");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        p_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;
                        continue;
                    }
                    if (step == 1)
                    {
                        time = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;
                        continue;
                    }

                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    if (p_id > MI.maxPlaneId)
                        MI.maxPlaneId = p_id;
                    p = new Plane(p_id, time);
                    MI.planesWaitingArray.Add(p);
                    /*Console.WriteLine(p_id);
                    Console.WriteLine(time);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }
            }

            //Console.WriteLine("Drugs and bombs");

            while (true)
            {
                i++;
                if (msg[i] == '/' & step == 0)
                {
                    if ((msg.Substring(start, i - start)) == "1")
                        MI.detected_drug=true;
                    else
                        MI.detected_drug=false;
                    start = i + 1;
                    step++;

                    continue;
                }

                if (msg[i] == '/' & step == 1)
                {
                    if ((msg.Substring(start, i - start)) == "1")
                        MI.detected_bomb = true;
                        
                    else
                        MI.detected_bomb=false;
                    start = i + 1;
                    step++;

                    continue;
                }

                if (msg[i] == '/' & step == 2)
                {
                    MI.number_drugs = Convert.ToInt32(msg.Substring(start, i - start));
                    start = i + 1;
                    step++;

                    continue;
                }

                if (msg[i] == '/' & step == 3)
                {
                    MI.number_bombs = Convert.ToInt32(msg.Substring(start, i - start));
                    start = i + 1;
                    step++;
                    break; //TUTAJ KONIEC DESERIALIZACJI!!
                }
            }

            return MI;
        }

        
        public static MessageInfo getState(string msg)
        {
            MessageInfo MI = new MessageInfo();
            int i = 0;
            int step = 0;
            int start = 1;
            int suitcase_id = 0, c_id = 0, progress = 0;
            int comp_id = 0, state = 0;
            int p_id = 0, time = 0, sleeve = 0;

            Suitcase s;
            StateInfo c;
            Plane p;

            //string msg = "014,43222,33,n,1043,50,;14324,22,33,n,1990,50,;/15190,22,;17,12,;/152,215,1,;8099,151,2,;151,122,3,;/152,215,;8099,151,;/0/1/12/10/";
            
            /*suitcaseinfo*/

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        string a = msg.Substring(start, i - start);
                        Console.WriteLine(a);
                        suitcase_id = Convert.ToInt32(a);
                        start = i + 1;
                        step++;

                        continue;
                    } 
                 
                    if (step == 1)
                    {
                        c_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 2)
                    {
                        progress = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }

                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    s = new Suitcase(suitcase_id, c_id, progress);
                    MI.suitcasesArray.Add(s);

                    //Console.WriteLine("NEXT ITEM");
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }
            }

            // Console.WriteLine("Components");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        comp_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 1)
                    {
                        state = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    c = new StateInfo(comp_id, state);
                    MI.statesArray.Add(c);
                    /*Console.WriteLine(comp_id);
                    Console.WriteLine(state);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                    // Console.WriteLine("END");
                    break;
                }

            }


            //Console.WriteLine("Planes");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        p_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 1)
                    {
                        time = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                    if (step == 2)
                    {
                        sleeve = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;

                        continue;
                    }
                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    p = new Plane(p_id, time, sleeve);
                    MI.planesArray.Add(p);
                    /*Console.WriteLine(p_id);
                    Console.WriteLine(time);
                    Console.WriteLine(sleeve);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }

            }

            //Console.WriteLine("Planes Array");

            while (true)
            {
                i++;
                if (msg[i] == ',')
                {
                    if (step == 0)
                    {
                        p_id = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;
                        continue;
                    }
                    if (step == 1)
                    {
                        time = Convert.ToInt32(msg.Substring(start, i - start));
                        start = i + 1;
                        step++;
                        continue;
                    }

                }
                if (msg[i] == ';')
                {
                    step = 0;
                    start++;
                    p = new Plane(p_id, time);
                    MI.planesWaitingArray.Add(p);
                    /*Console.WriteLine(p_id);
                    Console.WriteLine(time);
                    Console.WriteLine("NEXT ITEM");*/
                }
                if (msg[i] == '/')
                {
                    start++;
                    //Console.WriteLine("END");
                    break;
                }
            }

            //Console.WriteLine("Drugs and bombs");

            while (true)
            {
                i++;
                if (msg[i] == '/' & step == 0)
                {
                    if ((msg.Substring(start, i - start)) == "1")
                        MI.detected_drug = true;
                    else
                        MI.detected_drug = false;
                    start = i + 1;
                    step++;

                    continue;
                }

                if (msg[i] == '/' & step == 1)
                {
                    if ((msg.Substring(start, i - start)) == "1")
                        MI.detected_bomb = true;

                    else
                        MI.detected_bomb = false;
                    start = i + 1;
                    step++;
                    break; //TUTAJ KONIEC DESERIALIZACJI!!
                }

                
            }

            return MI;
        }
    }
}
