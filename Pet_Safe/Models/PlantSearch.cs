using System.Collections.Generic;
using System.IO;

namespace Pet_Safe.Models
{
    public class PlantSearch
    {
        public static bool IsPlantToxic(string plantName)
        {
            string filePath = @"C:\Users\ntnic\Desktop\LC101C#\Projects&Assignments\Pet_Safe\Pet_Safe\wwwroot\plants\plants.csv";

            // Check if the file exists before attempting to read it
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Plants CSV file not found.");
            }

            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Loop through each line in the CSV file
            foreach (string line in lines.Skip(1))
            {
                // Split the line into fields using a comma delimiter
                string[] fields = line.Split(',');

                // Check if the plant name matches the search term
                if (fields[0].Equals(plantName, StringComparison.OrdinalIgnoreCase))
                {
                    // Return true if the plant is toxic, false otherwise
                    return fields[1].Equals("toxic", StringComparison.OrdinalIgnoreCase);
                }
            }

            // If the plant name wasn't found, return false
            return false;
        }

        public static List<string> GetPlantNames()
        {
            string filePath = @"C:\Users\ntnic\Desktop\LC101C#\Projects&Assignments\Pet_Safe\Pet_Safe\wwwroot\plants\plants.csv";

            // Check if the file exists before attempting to read it
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Plants CSV file not found.");
            }

            // Read all lines from the CSV file
            string[] lines = File.ReadAllLines(filePath);

            // Create a list to hold the plant names
            List<string> plantNames = new List<string>();

            // Loop through each line in the CSV file
            foreach (string line in lines.Skip(1))
            {
                // Split the line into fields using a comma delimiter
                string[] fields = line.Split(',');

                // Add the plant name to the list
                plantNames.Add(fields[0]);
            }

            return plantNames;
        }
    }
}