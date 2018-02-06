using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrossOutCommunity.Models
{
    public class Quiz
    {
        public List<string> Questions
        {
            get
            {
                return new List<string> {
            "What Faction is Psycho Pete?",
            "Which factions cars are hybrid designs combining features of airplanes and vintage cars?",
            "What is the default Faction?",
            "Which faction has access to resources and technology of the Brotherhood?",
            "Which faction provides other factions with artifacts of the old world?" };
            }
        }
        public List<string> Answers { get { return new List<string> { "Lunatics", "Nomads", "Engineers", "Steppenwolfs", "Scavengers" }; } }
         public int QuestionNum { get; set; }
        public bool LastCorrect { get; set; }
        public string Answer { get; set; }
        public int NumCorrect { get; set; }
        public String[] AnsCheck { get; set; }

    }
}
