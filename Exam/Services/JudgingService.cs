using System;
using Exam.Enums;

namespace Exam.Services
{
    public class JudgingService
    {
        public bool IsJudged(string name,
            string surname,
            string patronymic,
            string passportSeries,
            string passportNumber,
            string passportIssuer,
            DateTime passportIssueDate, 
            string passportRegInformation,
            int adult, 
            Employment employmentEnum,
            bool hasOtherCredits)
        {
            var random = new Random();
            return random.Next(0, 100) < 30;
        }
    }
}