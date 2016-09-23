using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore.Factories
{
    public class SessionFactory
    {
        public static Session BuildSessionFromId(int id, int year, string teamIdList, string roundIdList, string scoreIdList, SQLiteConnection dbConn)
        {            
            // Build list of teams.
            List<Team> teamList = new List<Team>();
            int[] teamIds = Array.ConvertAll(teamIdList.Split(','), x => int.Parse(x));
            foreach (var t in teamIds)
            {
                Team team = TeamRepository.GetTeamById(t, dbConn);
                teamList.Add(team);
            }

            // Build list of rounds.
            List<Round> roundList = new List<Round>();
            int[] roundIds = Array.ConvertAll(roundIdList.Split(','), y => int.Parse(y));
            foreach (var r in roundIds)
            {
                Round round = RoundRepository.GetRoundById(r, dbConn);
                roundList.Add(round);
            }

            // Build list of scores.
            List<Score> scoreList = new List<Score>();
            int[] scoreIds = Array.ConvertAll(scoreIdList.Split(','), z => int.Parse(z));
            foreach (var sc in scoreIds)
            {
                Score score = ScoreRepository.GetScoreById(sc, dbConn);
                scoreList.Add(score);
            }

            Session s = new Session()
            {
                Id = id,
                Year = year,
                TeamList = teamList,
                RoundList = roundList,
                ScoreList = scoreList
            };

            return s;
        }

        
    }
}
