using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using SEWAEContractor.ServiceLayer;
using SEWAEContractorApplication.Interfaces;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;
using SEWAEContractorCore.ViewModels;

namespace SEWAEContractor.Controllers
{
	public class CustomController : Controller
	{
		private readonly ILogger<CustomController> _logger;
		private readonly IUnitOfWork unitOfWork;
		private readonly IConfiguration _configuration;
		UserLayer userLayer;
		BPLayer BPLayer;
		ExternalLayer externalLayer;
		public CustomController(ILogger<CustomController> logger, IUnitOfWork unitOfWork, IConfiguration configuration)
		{
			_logger = logger;
			this.unitOfWork = unitOfWork;
			_configuration = configuration;
			userLayer = new UserLayer(_configuration);
			BPLayer = new BPLayer(_configuration);
			externalLayer = new ExternalLayer(_configuration);	
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult SendEmail(int id=0)
		{
			return View();
		}
		[HttpPost]
		public IActionResult SendEmail()
		{
			try
			{
				List<BulkEmailOutput> bulkEmailOutputs = new List<BulkEmailOutput>();
				bulkEmailOutputs = userLayer.GetBulkEmailList();
				if (bulkEmailOutputs != null && bulkEmailOutputs.Count > 0)
				{
					foreach (var user in bulkEmailOutputs)
					{
						string Email = "";
						List<GetBusinessPartnerTechnicalDataInput> _GetBusinessPartnerTechnicalDataInputList = new List<GetBusinessPartnerTechnicalDataInput>();
						GetBusinessPartnerTechnicalDataInput _GetBusinessPartnerTechnicalDataInput = new GetBusinessPartnerTechnicalDataInput();

						_GetBusinessPartnerTechnicalDataInput.FilterType = "BusinessPartner";
						_GetBusinessPartnerTechnicalDataInput.FilterValue = user.BPNo;
						_GetBusinessPartnerTechnicalDataInputList.Add(_GetBusinessPartnerTechnicalDataInput);
						GetBusinessPartnerTechnicalDataOutput _GetBusinessPartnerTechnicalDataOutput = BPLayer.GetBusinessPartnerData(_GetBusinessPartnerTechnicalDataInputList);
						if (_GetBusinessPartnerTechnicalDataOutput != null)
						{
							if (_GetBusinessPartnerTechnicalDataOutput.Status == true)
							{

								Email = _GetBusinessPartnerTechnicalDataOutput.EmailAddress;
								if (!String.IsNullOrEmpty(Email))
								{
									//user.Email = Email;
									Random random = new Random();
									string alpha = "0123456789";

									string Code = new string(
									Enumerable.Repeat(alpha, 5)
									.Select(s => s[random.Next(alpha.Length)])
									.ToArray());
                                    string ResetUrl = _configuration["Url"] + "Home/ResetPassword?Code=" + Code;
                                    ResetPasswordLogInput _ResetPasswordLogInput = new ResetPasswordLogInput();
									_ResetPasswordLogInput.Code = Code;
									_ResetPasswordLogInput.UserId = user.UserId;
									_ResetPasswordLogInput.ResetUrl=ResetUrl;
									_ResetPasswordLogInput.CreatedDate = DateTime.Now;
									ResetPasswordLogOutput _ResetPasswordLogOutput = new ResetPasswordLogOutput();
									_ResetPasswordLogOutput = userLayer.AddResetPasswordLog(_ResetPasswordLogInput);

									if (_ResetPasswordLogOutput.Id > 0)
									{
										string Subject = "Reset Password";
										
										string Body = "Dear Customer, \n <br><br>Please find the below link to reset password.\n<br><br> <a href='" + ResetUrl + "' target='_blank'>Click Here</a>\n<br><br> Regards\n<br> SEWA.";
										SendEmailInput _SendEmailInput = new SendEmailInput();
										_SendEmailInput.email = Email;
										_SendEmailInput.subject = Subject;
										_SendEmailInput.message = Body;
										externalLayer.SendEmail(_SendEmailInput);
										
									}
								}
							}
						}
					}
					
				}
				return View();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
