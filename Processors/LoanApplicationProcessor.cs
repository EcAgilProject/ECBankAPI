using ECBank.Constants;
using ECBank.Models.Domain;

namespace ECBank.Processors
{
    public class LoanApplicationProcessor
    {
        public LoanStatus GetLoanStatus(LoanApplication application)
        {

            if (application == null)
            {
                throw new ArgumentNullException(nameof(application));
            }

            if (application.EmploymentType == EmploymentType.Unemployed
                || application.EmploymentType == EmploymentType.Pensioner)
            {
                return LoanStatus.NotApproved;
            }

            if (application.EmploymentType == EmploymentType.Student &&
                                           (application.Children > 1 ||
                                           application.ResidenceType == ResidenceType.Tenancy))
            {
                return LoanStatus.NotApproved;
            }

            if (application.EmploymentType == EmploymentType.Student)
            {
                return LoanStatus.Approved;
            }

            if (application.EmploymentType == EmploymentType.PartTime &&
                                             (application.Children > 2 ||
                                             application.ResidenceType == ResidenceType.Tenancy))
            {
                return LoanStatus.NotApproved;
            }

            if (application.EmploymentType == EmploymentType.PartTime)
            {
                return LoanStatus.Approved;
            }

            if (application.EmploymentType == EmploymentType.Permanent && application.Children > 2)
            {
                return LoanStatus.ManualProcessing;
            }
            if (application.EmploymentType == EmploymentType.Permanent)
            {
                return LoanStatus.Approved;
            }

            return LoanStatus.NotApproved;
        }

        public int GetLoanAmount(LoanApplication application)
        {
            LoanApplicationProcessor processor = new LoanApplicationProcessor();

            if (processor.GetLoanStatus(application) == LoanStatus.Approved)
            {
                int amount = 0;

                if (application == null)
                {
                    throw new ArgumentNullException(nameof(application));

                }

                if (application.EmploymentType == EmploymentType.Student)
                {
                    amount = 100000;
                    return amount;
                }

                if (application.EmploymentType == EmploymentType.PartTime)
                {
                    amount = 200000;
                    return amount;
                }

                if (application.EmploymentType == EmploymentType.Permanent)
                {
                    amount = 600000;
                    return amount;
                }

                return amount;
            }
            else
            {
                return 0;
            }
        }
    }
}
