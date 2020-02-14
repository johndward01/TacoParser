using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";
        const double metersToMiles = 0.00062137;

        // Grab the path from the name of your file

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            // use File.ReadAllLines(path) to grab all the lines from your csv file
            var lines = File.ReadAllLines(csvPath);

            // Log and error if you get 0 lines and a warning if you get 1 line
            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();



            // DON'T FORGET TO LOG YOUR STEPS
            // Now, here's the new code
            // Create two `ITrackable` variables with initial values of `null`. These will be used to store your two taco bells that are the furthest from each other.
            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;


            // Create a `double` variable to store the distance
            double finalDistance = 0;


            // Include the Geolocation toolbox, so you can compare locations: `using GeoCoordinatePortable;`
            GeoCoordinate geo1 = new GeoCoordinate();
            GeoCoordinate geo2 = new GeoCoordinate();


            // Do a loop for your locations to grab each location as the origin (perhaps: `locA`)
            // Create a new corA Coordinate with your locA's lat and long
            // Now, do another loop on the locations with the scope of your first loop, so you can grab the "destination" location (perhaps: `locB`)
            // Create a new Coordinate with your locB's lat and long
            for (int i = 0; i < locations.Length; i++)
            {
                var locA = locations[i];
                var corA = locA.Location;
                geo1.Latitude = corA.Latitude;
                geo1.Longitude = corA.Longitude;

                for (int j = 0; j < locations.Length; j++)
                {
                    var locB = locations[j];
                    var corB = locB.Location;
                    geo2.Latitude = corB.Latitude;
                    geo2.Longitude = corB.Longitude;
                    var testDistance = geo2.GetDistanceTo(geo1);

                    if (finalDistance < testDistance)
                    {
                        finalDistance = testDistance;
                        tacoBell2 = locB;
                        tacoBell1 = locA; 
                    }
                }
            }
            Console.WriteLine($"The 2 furthest Taco Bell's in Alabama are {tacoBell1} and {tacoBell2}.");
            Console.WriteLine($"The total distance is {Math.Round((finalDistance * metersToMiles), 2)} miles.");

            // Now, compare the two using `.GetDistanceTo()`, which returns a double
            // If the distance is greater than the currently saved distance, update the distance and the two `ITrackable` variables you set above
            // Once you've looped through everything, you've found the two Taco Bells furthest away from each other.
            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops.
        }
    }
}