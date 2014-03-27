namespace PMI21_TeachingPractice
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;

    public class Program
    {
        public static void Main(string[] args)
        {
            string[] buf = File.ReadAllLines("Data.txt");
            int size = buf.Length;
            List<Order> orders = new List<Order>();
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = buf[i].PadRight(buf[i].Length + 1, ' ');
                Order temp = new Order();
                temp.MakeOrder(buf[i]);
                orders.Add(temp);
            }

            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].Write();
            }

            XmlWriter fs = XmlWriter.Create("Result.xml");
            fs.WriteStartElement("head");
            fs.WriteFullEndElement();
            fs.Close();
            XmlDocument document = new XmlDocument();
            document.Load("Result.xml");
            XmlElement root = document.DocumentElement;
            for (int i = 0; i < orders.Count; i++)
            {
                orders[i].Write(document);
            }

            document.Save("Result.xml");
            Console.ReadKey();
        }
    }
}
