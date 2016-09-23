using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class Session
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public List<Team> TeamList { get; set; }
        public List<Round> RoundList { get; set; }
        public List<Score> ScoreList { get; set; }
    }
}
