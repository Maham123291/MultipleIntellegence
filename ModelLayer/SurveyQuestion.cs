using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    // SurveyQuestion.cs
    public class SurveyQuestion
    {
        public string Question { get; set; }
        public string Category { get; set; }

        public string UrduQuestion {  get; set; }
        public List<SurveyResponseOption> ResponseOptions { get; set; } = new List<SurveyResponseOption>();

        public List<SurveyResponseOption> UserSurveyResponse { get; set; } = new List<SurveyResponseOption>();
    }

    public class SurveyResponseOption
    {
        public string OptionText { get; set; }
        public int Score { get; set; }
        public bool IsSelected { get; set; }
    }

    public class SurveyResponse
    {
        public string userid { get; set; }
        public string quesno { get; set; }
        public int responsevalue { get; set; }
    }
}