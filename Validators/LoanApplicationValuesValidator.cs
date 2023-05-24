using ECBank.Models.Domain;
using ECBank.Models.DTO;
using System.Text.RegularExpressions;

namespace ECBank.Validators;

public class LoanApplicationValuesValidator
{
    public bool IsAmountInRange(NewLoanApplicationDto newLoanApplicationDto)
    {
        int minAmount = 10000;
        int maxAmount = 600000;


        if (newLoanApplicationDto == null)
        {
            throw new ArgumentNullException(nameof(newLoanApplicationDto));
        }

        if (newLoanApplicationDto.Amount > maxAmount || newLoanApplicationDto.Amount < minAmount)
        {
            return false;
        }

        return true;
    }

    public bool IsPayBackPeriodInRange(NewLoanApplicationDto newLoanApplicationDto)
    {
        int minPaybackPeriod = 1;
        int maxPaybackPeriod = 12;

        if (newLoanApplicationDto == null)
        {
            throw new ArgumentNullException(nameof(newLoanApplicationDto));
        }

        if (newLoanApplicationDto.PayBackPeriod < minPaybackPeriod
            || newLoanApplicationDto.PayBackPeriod > maxPaybackPeriod
            )
        {
            return false;
        }
        return true;
    }

    public bool IsValidSocialSecurityNumber(NewLoanApplicationDto newLoanApplicationDto)
    {

        string pattern = @"^\d{8}-\d{4}$";
        Regex regex = new Regex(pattern);
        bool validLengthAndType = regex.IsMatch(newLoanApplicationDto.SocialSecurityNumber);


        int century = int.Parse(newLoanApplicationDto.SocialSecurityNumber.Substring(0, 2));
        bool validCentury = century == 19 || century == 20;

        return (validLengthAndType && validCentury);

    }

    public bool IsValidEmail(NewLoanApplicationDto newLoanApplicationDto)
    {
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(newLoanApplicationDto.Email);
    }
}
