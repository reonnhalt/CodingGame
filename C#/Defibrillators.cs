using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
     static void Main(string[] args)
     {
            string LON = Console.ReadLine();
            double Longitude = Convert.ToDouble(LON.Replace(',', '.'));
            string LAT = Console.ReadLine();
            double Latitude = Convert.ToDouble(LAT.Replace(',', '.'));
            int N = int.Parse(Console.ReadLine());
            
            List<Defibrillator> defibs = new List<Defibrillator>();
            
            for (int i = 0; i < N; i++)
            {
                string DEFIB = Console.ReadLine();
                var splitCodes = DEFIB.Split(';');
                var DefAddress = splitCodes[1];
                var DefLongitude = Convert.ToDouble(splitCodes[splitCodes.Length - 2].Replace(',', '.'));
                var DefLatitude = Convert.ToDouble(splitCodes[splitCodes.Length - 1].Replace(',', '.'));
                defibs.Add(new Defibrillator(DefAddress,DefLongitude,DefLatitude));
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");
            defibs.Sort((a, b) => Convert.ToInt32( a.calcDistance(Longitude,Latitude) - b.calcDistance(Longitude,Latitude) ));
            Console.WriteLine("{0}",defibs[0].getAddress());
    }
    //AEDのクラス
    public class Defibrillator
    {
        private string Address;
        private double Longitude;
        private double Latitude;

        public Defibrillator(string Address, double Longitude, double Latitude)
        {
            this.Address = Address;
            this.Longitude = Longitude;
            this.Latitude  = Latitude;
        }
        public string getAddress()
        {
            return Address;
        }
        public double calcDistance(double OpponentLongitude, double OpponentLatitude)
        {
            double x = (Longitude - OpponentLongitude) * Math.Cos((OpponentLatitude + Latitude) / 2);
            double y = (Latitude - OpponentLatitude);
            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            return d;
        }
    }
}