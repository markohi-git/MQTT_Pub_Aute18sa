using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;

namespace MQTT_Pub_Aute18sa
{
    class Program
    {
        static void Main(string[] args)
        {
            MqttClient client = new MqttClient("127.0.0.1");
            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            while (true)
            {
                Random rnd = new Random();
                int r = rnd.Next(18, 22);
                string str = r.ToString();
                Console.WriteLine("lähetetiin: " + str);
                Console.WriteLine("kuitattiin: "+client.Publish("/A140.2/lampo",Encoding.UTF8.GetBytes(str),1,false));

                Thread.Sleep(2000);
            }
        }
    }
}
