using ECBank.Constants;

namespace ECBank.Models.DTO
{
    public class LoanApplicationDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public int ApprovedAmount { get; set; }
        public int ApprovedPayBackPeriod { get; set; }
    }
}
