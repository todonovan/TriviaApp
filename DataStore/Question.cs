using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStore
{
    public class Question
    {
        public int Id { get; set; }
        public List<Round> Rounds { get; set; }
        public string QuestionText { get; set; }
        public string AnswerText { get; set; }
        public Category Category { get; set; }
    }
}
