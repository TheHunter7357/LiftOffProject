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

        static float horizontal1;
        static float vertical1;

        static int B11;
        static int B21;
        static int B31;
        static int B41;

        static float horizontal2;
        static float vertical2;

        static int B12;
        static int B22;
        static int B32;
        static int B42;

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
            string line = port1.ReadLine(); // read separated values
            //string line = port.ReadExisting(); // when using characters
            if (line != "")
            {
                string[] values = line.Split(',');
                horizontal1 = float.Parse(values[3]);
                vertical1 = float.Parse(values[4]);
                B11 = int.Parse(values[5]);
                B21 = int.Parse(values[6]);
                B31 = int.Parse(values[7]);
                B41 = int.Parse(values[8]);
            }
            line = port2.ReadLine();
            if (line != "")
            {
                string[] values = line.Split(',');
                horizontal2 = float.Parse(values[3]);
                vertical2 = float.Parse(values[4]);
                B12 = int.Parse(values[5]);
                B22 = int.Parse(values[6]);
                B32 = int.Parse(values[7]);
                B42 = int.Parse(values[8]);
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
                        if (B11 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B2"))
                    {
                        if (B21 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B3"))
                    {
                        if (B31 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B4"))
                    {
                        if (B41 == 1)
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
                        if (B12 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B2"))
                    {
                        if (B22 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B3"))
                    {
                        if (B32 == 1)
                        {
                            return false;
                        }
                        else
                            return true;
                    }
                    else if (string.Equals(name, "B4"))
                    {
                        if (B42 == 1)
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
    }
}
