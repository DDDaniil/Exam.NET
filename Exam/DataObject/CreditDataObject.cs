using System;
using System.ComponentModel.DataAnnotations;
using Exam.Enums;

namespace Exam.DataObject
{
    public class CreditDataObject
    {
        [MinLength(Variables.Variables.NameMinLength)]
        [MaxLength(Variables.Variables.NameMaxLength)]
        public string Name { get; set; }
    
        [MinLength(Variables.Variables.SurnameMinLength)]
        [MaxLength(Variables.Variables.SurnameMaxLength)]
        public string Surname { get; set; }
    
        [MinLength(Variables.Variables.PatronymicMinLength)]
        [MaxLength(Variables.Variables.PatronymicMaxLength)]
        public string Patronymic { get; set; }
    
        [MinLength(Variables.Variables.PassportSeriesLength)]
        [MaxLength(Variables.Variables.PassportSeriesLength)]
        public string PassportSeries { get; set; }
    
        [MinLength(Variables.Variables.PassportNumberLength)]
        [MaxLength(Variables.Variables.PassportNumberLength)]
        public string PassportNumber { get; set; }
    
        [MinLength(Variables.Variables.PassportIssuerMinLength)]
        [MaxLength(Variables.Variables.PassportIssuerMaxLength)]
        public string PassportIssuer { get; set; }
    
        public DateTime PassportIssueDate { get; set; }
    
        [MinLength(Variables.Variables.PassportRegInformationMinLength)]
        [MaxLength(Variables.Variables.PassportRegInformationMaxLength)]
        public string PassportRegInformation { get; set; }
    
        [Range(Variables.Variables.AdultMin, Variables.Variables.AdultMax)]
        public int Adult { get; set; }
    
        public bool IsJudged { get; set; }
    
        public Employment Employment { get; set; }
    
        public Purpose Purpose { get; set; }
    
        public Deposit Deposit { get; set; }
    
        [Range(Variables.Variables.CarAgeMin, Variables.Variables.CarAgeMax)]
        public int CarAge { get; set; }
    
        public bool HasOtherCredits { get; set; }
    
        [Range(Variables.Variables.AmountMin, Variables.Variables.AmountMax)]
        public int Amount { get; set; }
    }
}