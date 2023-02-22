using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Reflection;

namespace GXPEngine
{
    public class ArduinoInput
    {
        SerialPort port1 = new SerialPort();
        SerialPort port2 = new SerialPort();

        static float x1;
        static float x2;

        static float y1;
        static float y2;

        static float z1;
        static float z2;

        static float horizontal1;
        static float vertical1;

        static int B11;
        static int B21;
        static int B31;

        static float horizontal2;
        static float vertical2;

        static int B12;
        static int B22;
        static int B32;

        public ArduinoInput()
        {
            string[] names = SerialPort.GetPortNames();

            

            foreach (string name in names)
            {
                Console.WriteLine(name);
                if(!port1.IsOpen)
                {
                    port1.PortName = name;
                    port1.BaudRate = 9600;
                    port1.RtsEnable = true;
                    port1.DtrEnable = true;
                    try
                    {
                        port1.Open();
                        Console.WriteLine("Found open port at: " + port1.PortName);
                    }
                    catch { return; }
                }
                else if(!port2.IsOpen)
                {
                    port2.PortName = name;
                    port2.BaudRate = 9600;
                    port2.RtsEnable = true;
                    port2.DtrEnable = true;
                    try
                    {
                        port2.Open();
                        Console.WriteLine("Found open port at: " + port2.PortName);
                        break;
                    }
                    catch { }
                }


            }



            Game.main.OnBeforeStep += Step;
        }

        public void Step()
        {
            if (!port1.IsOpen)
                return;
            string line = port1.ReadLine(); // read separated values
            //string line = port.ReadExisting(); // when using characters
            if (line != "")
            {
                Console.WriteLine(line);
                string[] values = line.Split(',');
                x1 = float.Parse(values[0]);
                y1 = float.Parse(values[1]);
                z1 = float.Parse(values[2]);
                horizontal1 = float.Parse(values[3]);
                vertical1 = float.Parse(values[4]);
                B11 = int.Parse(values[5]);
                B21 = int.Parse(values[6]);
                B31 = int.Parse(values[7]);
            }
            if (!port2.IsOpen)
                return;
            line = port2.ReadLine();
            if (line != "")
            {
                Console.WriteLine(line);
                string[] values = line.Split(',');
                x2 = float.Parse(values[0]);
                y2 = float.Parse(values[1]);
                z2 = float.Parse(values[2]);
                horizontal2 = float.Parse(values[3]);
                vertical2 = float.Parse(values[4]);
                B12 = int.Parse(values[5]);
                B22 = int.Parse(values[6]);
                B32 = int.Parse(values[7]);
            }
        }

        public static float GetAxisHorizontal(Enums.players player)
        {
            return player == Enums.players.player1 ? horizontal1 : horizontal2;
        }

        public static float GetAxisVertical(Enums.players player)
        {
            return player == Enums.players.player1 ? vertical1 : vertical2;
        }

        public static bool GetButtonDown(string name, Enums.players player)
        {
            switch (player)
            {
                case Enums.players.player1:
                    if (string.Equals(name, "B1"))
                    {
                        if (B11 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B2"))
                    {
                        if (B21 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B3"))
                    {
                        if (B31 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                    {
                        Console.WriteLine("Button " + name + " not found");
                        return false;
                    }

                case Enums.players.player2:
                    if (string.Equals(name, "B1"))
                    {
                        if (B12 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B2"))
                    {
                        if (B22 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B3"))
                    {
                        if (B32 == 0)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else
                    {
                        Console.WriteLine("Button " + name + " not found");
                        return false;
                    }
                default:
                    return false;
            }
            

        }

        public static bool GoingFast(Enums.players player)
        {
            switch (player)
            {
                case Enums.players.player1:
                    if(x1 > 2 || x1 < -2)
                    {
                        return true;
                    }
                    else if(y1 > 2 || y1 < -2)
                    {
                        return true;
                    }
                    else if(z1 > 2 || z1 < -2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Enums.players.player2:
                    if (x2 > 2 || x2 < -2)
                    {
                        return true;
                    }
                    else if (y2 > 2 || y2 < -2)
                    {
                        return true;
                    }
                    else if (z2 > 2 || z2 < -2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                default: return false;
            }
        } 
    }
}
