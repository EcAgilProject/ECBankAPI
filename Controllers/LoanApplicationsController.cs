using ECBank.Constants;
using ECBank.Data;
using ECBank.Models.Domain;
using ECBank.Models.DTO;
using ECBank.Processors;
using ECBank.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ECBank.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanApplicationsController : ControllerBase
    {

        private readonly ApplicationDbContext context;

        public LoanApplicationsController(ApplicationDbContext context)
        {
            this.context = context;
        }


        [HttpGet(Name = "GetAllLoanApplications")]
        public IEnumerable<LoanApplicationDto> GetAllLoanApplications()
        {
            var applications = new List<LoanApplication>();
            applications = context.LoanApplication.ToList();

            var applicationDtos = applications.Select(x => new LoanApplicationDto()
            {
                Id = x.Id,
                ApprovedAmount = x.ApprovedAmount,
                ApprovedPayBackPeriod = x.ApprovedPayBackPeriod,
                Status = x.Status.ToString(),
            });


            return applicationDtos;
        }


        [HttpPost]
        public IActionResult CreateApplication(NewLoanApplicationDto newApplicationDto)
        {
            LoanApplicationValuesValidator validator = new LoanApplicationValuesValidator();

            bool validAmount = validator.IsAmountInRange(newApplicationDto);
            bool validPayBackPeriod = validator.IsPayBackPeriodInRange(newApplicationDto);
            bool validSocialSecurityNumber = validator.IsValidSocialSecurityNumber(newApplicationDto);
            bool validEmail = validator.IsValidEmail(newApplicationDto);

            if (!(validAmount && validPayBackPeriod && validSocialSecurityNumber && validEmail))
            {
                return BadRequest(newApplicationDto);
            }

            LoanApplication application = new LoanApplication()
            {
                Amount = newApplicationDto.Amount,
                PayBackPeriod = newApplicationDto.PayBackPeriod,
                SocialSecurityNumber = newApplicationDto.SocialSecurityNumber,
                Email = newApplicationDto.Email,
                PhoneNumber = newApplicationDto.PhoneNumber,
                MaritalStatusType = (MaritalStatusType)Enum.Parse(typeof(MaritalStatusType), newApplicationDto.MaritalStatusType),
                Children = newApplicationDto.Children,
                ResidenceType = (ResidenceType)Enum.Parse(typeof(ResidenceType), newApplicationDto.ResidenceType) ,
                ResidenceCost = newApplicationDto.ResidenceCost,
                EmploymentType = (EmploymentType)Enum.Parse(typeof(EmploymentType), newApplicationDto.EmploymentType),
                Salary = newApplicationDto.Salary,
                EmployedSince = newApplicationDto.EmployedSince,
                EmployerName = newApplicationDto.EmployerName,
            };

            LoanApplicationProcessor processor = new LoanApplicationProcessor();

            application.Status = processor.GetLoanStatus(application);
            application.ApprovedAmount = processor.GetLoanAmount(application);
            application.ApprovedPayBackPeriod = 10;

            context.LoanApplication.Add(application);
            context.SaveChanges();

            LoanApplicationDto applicationDto = new LoanApplicationDto()
            {
                Id = application.Id,
                ApprovedAmount = application.ApprovedAmount,
                ApprovedPayBackPeriod= application.ApprovedPayBackPeriod,
                Status =  application.Status.ToString(),
            };



            return Created("", applicationDto);

        }
    }
}