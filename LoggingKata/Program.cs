﻿using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "CSV_Files/TacoBell-US-AL.csv";
        const double metersToMiles = 0.00062137;

        static void Main(string[] args)
        {
            // logger.LogInfo("Log initialized");
            // logger.LogInfo($"Lines: {lines[0]}");

            var lines = File.ReadAllLines(csvPath);

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;
            double finalDistance = 0;
            double testDistance = 0;
            GeoCoordinate geo1 = new GeoCoordinate();
            GeoCoordinate geo2 = new GeoCoordinate();

            var locations = lines.Select(TacoParser.Parse).ToArray();

            for (int i = 0; i < locations.Length; i++)
            {
                geo1.Latitude = locations[i].Location.Latitude;
                geo1.Longitude = locations[i].Location.Longitude;               

                for (int j = 1; j < locations.Length; j++)
                {
                    geo2.Latitude = locations[j].Location.Latitude;
                    geo2.Longitude = locations[j].Location.Longitude;

                    testDistance = geo1.GetDistanceTo(geo2);                   
                  
                    if (finalDistance < testDistance)
                    {
                        finalDistance = testDistance;
                        tacoBell1 = locations[i];
                        tacoBell2 = locations[j];
                    }                   
                }
            }

            Console.WriteLine($"The 2 furthest Taco Bell's in Alabama are {tacoBell1.Name} and {tacoBell2.Name}.");
            Console.WriteLine($"The total distance is {Math.Round((finalDistance * metersToMiles), 2)} miles.");
        }
    }
}