using ECBank.Constants;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECBank.Models.Domain;

public class LoanApplication
{
    public int Id { get; set; }
    public int Amount { get; set; }
    public int PayBackPeriod { get; set; }
    public string SocialSecurityNumber { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public MaritalStatusType MaritalStatusType { get; set; }
    public int Children { get; set; }
    public ResidenceType ResidenceType { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal ResidenceCost { get; set; }
    public EmploymentType EmploymentType { get; set; }
    public int Salary { get; set; }
    public DateTime EmployedSince { get; set; }
    public string EmployerName { get; set; }
    public LoanStatus Status { get; set; }
    public int ApprovedAmount { get; set; }
    public int ApprovedPayBackPeriod { get; set; }
}
