using Exam.DataObject;
using Exam.Enums;

namespace Exam.Services
{
    public class CreditService
    {
        private readonly JudgingService _JudgingService;

        public CreditService(JudgingService JudgingService)
        {
            _JudgingService = JudgingService;
        }
        private int GetScoredFromAdult(int adult, int amount, Deposit deposit) =>
            adult switch
            {
                >= 21 and <= 28 => amount switch
                {
                    < 1000000 => 12,
                    >= 1000000 and <= 3000000 => 9,
                    _ => 0
                },
                >= 29 and <= 59 => 14,
                >= 60 and <= 72 => deposit == Deposit.None ? 0 : 8,
                _ => 0
            };
    
        private int GetScoredFromJudging(bool isReallyJudged) => 
            isReallyJudged ? 0 : 15;
    
        private int GetScoredFromEmployment(Employment employment, int adult)
        {
            
            return employment switch
            {
                Employment.ContractLaborCodeRusFed => 14,
                Employment.IndividualEntrepreneur => 12,
                Employment.Freelancer => 8,
                Employment.Retiree => adult < 70 ? 5 : 0,
                _ => 0
            };
        }

        private int GetScoresFromPurpose(Purpose purpose) =>
            purpose switch
            {
                Purpose.Consumer => 14,
                Purpose.Realty => 8,
                Purpose.Recrediting => 12,
                _ => 0
            };

        private int GetScoresFromDeposit(Deposit deposit, int carAge) =>
            deposit switch
            {
                Deposit.Retiree => 14,
                Deposit.Car => carAge <= 3 ? 8 : 3,
                Deposit.Guarantee => 12,
                _ => 0
            };
    
        private int GetScoresFromOtherCredits(bool otherCredits, Purpose purpose)
        {
            if (otherCredits) return 0;
            return purpose == Purpose.Recrediting ? 0 : 15;
        }
    
        private int GetScoresFromAmount(int amount) =>
            amount switch
            {
                >= 0 and < 1000000 => 12,
                >= 1000000 and < 5000000 => 14,
                >= 5000000 and < 10000000 => 8,
                _ => 0
            };
        
        public string GetCreditResult(CreditDataObject creditData)
        {
            var isReallyJudged = _JudgingService.IsJudged(creditData.Name, creditData.Surname, creditData.Patronymic,
                creditData.PassportSeries, creditData.PassportNumber, creditData.PassportIssuer, creditData.PassportIssueDate,
                creditData.PassportRegInformation, creditData.Adult, creditData.Employment, creditData.HasOtherCredits);
    
            var message = "";
            if (!creditData.IsJudged && isReallyJudged)
            {
                creditData.IsJudged = isReallyJudged;
                message = "Была судимость.";
            }
            
            var result = GetScoredFromAdult(creditData.Adult, creditData.Amount, creditData.Deposit) +
                         GetScoredFromJudging(creditData.IsJudged) +
                         GetScoredFromEmployment(creditData.Employment, creditData.Adult) +
                         GetScoresFromPurpose(creditData.Purpose) +
                         GetScoresFromDeposit(creditData.Deposit, creditData.CarAge) +
                         GetScoresFromOtherCredits(creditData.HasOtherCredits, creditData.Purpose) +
                         GetScoresFromAmount(creditData.Amount);
            return result switch
            {
                < 80 => $"{message}Отказ в заявке, так как ваш кредитный балл равен {result}",
                >= 80 and < 84 =>
                    $"{message}Заявка одобрена с процентной ставкой 30%, кредитный балл равен {result}",
                >= 84 and < 88 =>
                    $"{message}Заявка одобрена с процентной ставкой 26%, кредитный балл равен {result}",
                >= 88 and < 92 =>
                    $"{message}Заявка одобрена с процентной ставкой 22%, кредитный балл равен {result}",
                >= 92 and < 96 =>
                    $"{message}Заявка одобрена с процентной ставкой 19%, кредитный балл равен {result}",
                >= 96 and < 100 =>
                    $"{message}Заявка одобрена с процентной ставкой 15%, так как ваш кредитный балл равен {result}",
                100 => $"Вы можете получить кредит с процентной ставкой 12,5%, так как ваш кредитный балл равен {result}",
                _ => $"{message}Кредитный балл = 100"
            };
        }
        
    }
    
}