using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01.Entities
{
    public class Locations
    {
        public List<int> FirstLocationIDList { get; set; } = [];

        public List<int> SecondLocationIDList { get; set; } = [];

        public int DistanceBetweenLocationIDs { get; set; } = 0;

        public int SimilarityScore { get; set; } = 0;
    }
}
