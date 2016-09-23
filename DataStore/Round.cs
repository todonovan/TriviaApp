using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class Round
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int RoundOrderingNumber { get; set; }
        public int NumQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public int PointValue { get; set; }
    }
}
