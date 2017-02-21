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
            string closestDefib = "";
            double closestDistance =  0;
            for (int i = 0; i < N; i++)
            {
                string DEFIB = Console.ReadLine();
                string address = getAddress(DEFIB);
                double distance = getDistance(Longitude, Latitude, DEFIB);
                if (i == 0)
                {
                    closestDistance = distance;
                    closestDefib = address;
                }
                else if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestDefib = address;
                }
                
            }

            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");

            Console.WriteLine("{0}", closestDefib);
        }
        
        public static string getAddress(string s)
        {
            string[] splitCodes = s.Split(';');
            string address = splitCodes[1];
            return address;
        }

        public static double getDistance(double ALongitude, double ALatitude, string s)
        {
            string[] splitCodes = s.Split(';');
            double BLongitude = Convert.ToDouble(splitCodes[splitCodes.Length - 2].Replace(',', '.'));
            double BLatitude = Convert.ToDouble(splitCodes[splitCodes.Length - 1].Replace(',', '.'));
            double distance = calcDistance(ALongitude, ALatitude, BLongitude, BLatitude);
            return distance;
        }

        public static double calcDistance(double ALongitude, double ALatitude, double BLongitude, double BLatitude)
        {
            double x = (BLongitude - ALongitude) * Math.Cos((ALatitude + BLatitude) / 2);
            double y = (BLatitude - ALatitude);
            double d = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2)) * 6371;
            return d;
        }
}