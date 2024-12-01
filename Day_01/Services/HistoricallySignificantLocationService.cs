﻿using Day_01.Entities;

namespace Day_01.Services
{
    public  class HistoricallySignificantLocationService
    {
        public Locations Locations { get; set; } = new();

        private const string NewLine = "\r\n";

        public void CreateTheHistoricallySiginificantLocationIDLists(string rawData)
        {
            string[] bothIDLists = rawData.Split(NewLine);

            // creating the location entities
            foreach (var pairOfIDs in bothIDLists)
            {
                string[] oneIDPair = pairOfIDs.Split("   ");

                Locations.FirstLocationIDList.Add(int.Parse(oneIDPair[0]));
                Locations.SecondLocationIDList.Add(int.Parse(oneIDPair[1]));
            }
        }

        public int GetCalculatedDistanceBetweenLocations()
        {
            // sorting the lists
            Locations.FirstLocationIDList.Sort();
            Locations.SecondLocationIDList.Sort();

            // calculate distance between lcoations
            for (int i = 0; i < Locations.FirstLocationIDList.Count; i++)
            {
                Locations.DistanceBetweenLocationIDs += Math.Abs(Locations.FirstLocationIDList[i] - Locations.SecondLocationIDList[i]);
            }

            return Locations.DistanceBetweenLocationIDs;
        }

        public int GetSimiliarityScore()
        {
            for (int i = 0; i < Locations.FirstLocationIDList.Count; i++)
            {
                int locationToCheck = Locations.FirstLocationIDList[i];

                int countInSecondLocationIDList = Locations.SecondLocationIDList.Where(x => x.Equals(locationToCheck)).Count();

                Locations.SimilarityScore += (locationToCheck * countInSecondLocationIDList);
            }

            return Locations.SimilarityScore;
        }
    }
}