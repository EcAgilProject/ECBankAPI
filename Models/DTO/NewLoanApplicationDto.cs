using ECBank.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECBank.Models.DTO
{
    public class NewLoanApplicationDto
    {
        public int Amount { get; set; }
        public int PayBackPeriod { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string MaritalStatusType { get; set; }
        public int Children { get; set; }
        public string ResidenceType { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal ResidenceCost { get; set; }
        public string EmploymentType { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedSince { get; set; }
        public string EmployerName { get; set; }
    }
}
