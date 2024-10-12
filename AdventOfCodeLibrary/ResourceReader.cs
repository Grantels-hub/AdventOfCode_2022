﻿namespace AdventOfCodeLibrary
{
    public class ResourceReader
    {
        private const string RESOURCEPATH = "../../../../resources";
        public string GetResource(int day)
        {
            if (!File.Exists(RESOURCEPATH + $"/day_{day.ToString()}.txt"))
            {
                throw new NotSupportedException("Resource file not found.");
            }

            string readText = File.ReadAllText(RESOURCEPATH + $"day_{day.ToString()}.txt");

            return readText;
        }
    }
}