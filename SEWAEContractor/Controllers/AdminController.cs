using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using SEWAEContractor.CommonFunctions;

using SEWAEContractor.ServiceLayer;
using SEWAEContractorAdmin.Models;
using SEWAEContractorApplication.Interfaces;
using SEWAEContractorCore.ExternalModels;
using SEWAEContractorCore.Models;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;
using SEWAEContractorAdmin.ServiceLayer;
namespace SEWAEContractorAdmin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IUnitOfWork unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly IStringLocalizer _localizer;
        AdminLayer _adminLayer;
        EncodeDecodeFunctions _encodeDecodeFunctions;
        UserLayer _userLayer;
        ExternalLayer _externalLayer;
        ActiveDirectoryLayer _activeDirectoryLayer;
        public AdminController(ILogger<AdminController> logger, IUnitOfWork unitOfWork, IConfiguration configuration, IStringLocalizer<AdminController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
            this.unitOfWork = unitOfWork;
            _configuration = configuration;
            _adminLayer=new AdminLayer(_configuration);
            _encodeDecodeFunctions = new EncodeDecodeFunctions(configuration);
            _userLayer = new UserLayer(_configuration);
            _externalLayer = new ExternalLayer(_configuration);
            _activeDirectoryLayer=new ActiveDirectoryLayer(_configuration);
        }
        #region GovernmentUserCreation
        public IActionResult CreateGovernmentUser()
        {
            GovernmentUserViewModel governmentUserViewModel = new GovernmentUserViewModel();
            try
            {
                if (HttpContext.Session.GetString("AdminLogin") == null)
                {
                    return RedirectToAction("AdminLogin", "Admin");
                }
                GovernmentIdOutput governmentIdOutput=_adminLayer.GetGovernmentList();

                List<string> govtRegisteredBPList = _adminLayer.GetAllGovtRegisteredBP();
                if(govtRegisteredBPList!=null && govtRegisteredBPList.Count>0)
                {
                    if(governmentIdOutput.GovernmentIdRecordOutputs!=null&& governmentIdOutput.GovernmentIdRecordOutputs.Count>0)
                    {
                        governmentUserViewModel.GovernmentBPList = governmentIdOutput.GovernmentIdRecordOutputs.Where(x => !String.IsNullOrEmpty(x.MainBp)  && !govtRegisteredBPList.Contains(x.MainBp)).ToList();
                        
                    }
                }
                return View(governmentUserViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception raised in Service Request Controller for BP: " + governmentUserViewModel.SelectedBP + ex.Message);
                governmentUserViewModel.ErrorType = "Fail";
                governmentUserViewModel.ErrorCode = "1";
                governmentUserViewModel.ErrorMessage = _localizer["We are facing technical issue at the moment, please try again later, If issue persists please contact SEWA"];
                return View(governmentUserViewModel);
            }
        }
        [HttpPost]
        public IActionResult CreateGovernmentUser(GovernmentUserViewModel governmentUserViewModel)
        {
            if (HttpContext.Session.GetString("AdminLogin") == null)
            {
                return RedirectToAction("AdminLogin", "Admin");
            }
            GovernmentIdOutput governmentIdOutput = _adminLayer.GetGovernmentList();

            List<string> govtRegisteredBPList = _adminLayer.GetAllGovtRegisteredBP();
            if (govtRegisteredBPList != null && govtRegisteredBPList.Count > 0)
            {
                if (governmentIdOutput.GovernmentIdRecordOutputs != null && governmentIdOutput.GovernmentIdRecordOutputs.Count > 0)
                {
                    governmentUserViewModel.GovernmentBPList = governmentIdOutput.GovernmentIdRecordOutputs.Where(x => !String.IsNullOrEmpty(x.MainBp) && !govtRegisteredBPList.Contains(x.MainBp)).ToList();

                }
            }
            string key = _configuration["CipherKey"];
            if (!String.IsNullOrEmpty(governmentUserViewModel.SelectedBP))
            {
                CheckUserNameInput checkUserNameInput = new CheckUserNameInput();
                checkUserNameInput.UserName = governmentUserViewModel.UserName;
                checkUserNameInput.Email = governmentUserViewModel.Email;
                CheckUserNameOutput checkUserNameOutput = new CheckUserNameOutput();
                checkUserNameOutput = _userLayer.CheckUserName(checkUserNameInput);
                if (checkUserNameOutput != null)
                {
                    if (!checkUserNameOutput.CheckUser)
                    {
                        governmentUserViewModel.Password = _encodeDecodeFunctions.CreateRandomPassword(10);
                        var issueAuthorityName = governmentUserViewModel.GovernmentBPList.Where(x => x.MainBp == governmentUserViewModel.SelectedBP).Select(x => x.Institute).First();
                        int issueAuthorityId = this.unitOfWork.IssueAuthorityMasterRepository.GetGovtIssueAuthorityId(issueAuthorityName);
                        AddMainUserInput addMainUserInput = new AddMainUserInput
                        {
                            UserName = governmentUserViewModel.UserName,
                            IDNumber = governmentUserViewModel.GovernmentBPList.Where(x=>x.MainBp==governmentUserViewModel.SelectedBP).Select(x=>x.GovernmentId).First(),
                            IDType = "Government",
                            BPNo = governmentUserViewModel.SelectedBP,
                            IsMainUser = true,
                            IsVerified = true,
                            CreatedDate = DateTime.Now,
                            Email = governmentUserViewModel.Email,
                            CompanyName = governmentUserViewModel.GovernmentBPList.Where(x => x.MainBp == governmentUserViewModel.SelectedBP).Select(x => x.EnglishName).First(),
                            Password = AESOperation.EncryptString(key, governmentUserViewModel.Password),
                            GovernmentIssuingAuthority = issueAuthorityId.ToString(),
                        };
                        int add = _userLayer.AddMainUser(addMainUserInput);
                        if (add > 0)
                        {
                            string Subject = "SEWA Portal Registration";
                            string Message = "Dear Customer, \n<br><br> Please find the user details\n <br><br>UserName:" + governmentUserViewModel.UserName + "\n<br> Password:" + governmentUserViewModel.Password + "<br><br>\nRegards,<br>\n SEWA";
                            SendEmailInput _SendEmailInput = new SendEmailInput();
                            _SendEmailInput.subject = Subject;
                            _SendEmailInput.message = Message;
                            _SendEmailInput.email = governmentUserViewModel.Email;
                            _externalLayer.SendEmail(_SendEmailInput);
                            governmentUserViewModel.ErrorCode = "2";
                            governmentUserViewModel.ErrorType = "Success";
                            governmentUserViewModel.ErrorMessage = _localizer["User Added Successfully"];
                            return View(governmentUserViewModel);
                        }
                        else
                        {
                            governmentUserViewModel.ErrorCode = "1";
                            governmentUserViewModel.ErrorType = "Fail";
                            governmentUserViewModel.ErrorMessage = _localizer["We faced some issue while adding user, please try again later"];
                            return View(governmentUserViewModel);
                        }
                    }
                    else
                    {
                        governmentUserViewModel.ErrorCode = "1";
                        governmentUserViewModel.ErrorType = "Fail";
                        governmentUserViewModel.ErrorMessage = _localizer["UserName/Email already exists"];
                        return View(governmentUserViewModel);
                    }
                }
                else
                {
                    governmentUserViewModel.ErrorCode = "1";
                    governmentUserViewModel.ErrorType = "Fail";
                    governmentUserViewModel.ErrorMessage = _localizer["UserName/Email already exists"];
                    return View(governmentUserViewModel);
                }
            }
            else
            {
                governmentUserViewModel.ErrorCode = "1";
                governmentUserViewModel.ErrorType = "Fail";
                governmentUserViewModel.ErrorMessage = _localizer["Please select the government entity from the list"];
                return View(governmentUserViewModel);
            }
        }

        #endregion
        #region Login
        public IActionResult AdminLogin()
        {
            AdminLoginViewModel adminLoginViewModel = new AdminLoginViewModel();
            try
            {
                return View(adminLoginViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception raised in Admin Login: "+ ex.Message);
                adminLoginViewModel.ErrorType = "Fail";
                adminLoginViewModel.ErrorCode = "1";
                adminLoginViewModel.ErrorMessage = _localizer["We are facing technical issue at the moment, please try again later, If issue persists please contact SEWA"];
                return View(adminLoginViewModel);
            }
        }
        [HttpPost]
        public IActionResult AdminLogin(AdminLoginViewModel adminLoginViewModel)
        {
            try
            {
                _logger.LogInformation(" Entering Admin Login: ");
                if (!String.IsNullOrEmpty(adminLoginViewModel.Username) && !String.IsNullOrEmpty(adminLoginViewModel.Password))
                {
                    CheckLoginInput checkLoginInput = new CheckLoginInput();
                    checkLoginInput.UserName = adminLoginViewModel.Username;
                    checkLoginInput.Password = adminLoginViewModel.Password;
                    AuthenticateADUserOutput authenticateADUserOutput = new AuthenticateADUserOutput();
                    authenticateADUserOutput=_activeDirectoryLayer.AuthenticateUser(checkLoginInput);
                    if (authenticateADUserOutput.AuthenticateUser)
                    {
                        _logger.LogInformation("Admin Login Credentials: " + adminLoginViewModel.Username);
                        
                        int loginId = _userLayer.checkAdminLogin(checkLoginInput);
                        _logger.LogInformation("Checking Admin Login:");
                        if (loginId>0)
                        {
                            HttpContext.Session.SetString("AdminLogin", loginId.ToString());
                            HttpContext.Session.SetString("UserType", "Admin");
                            HttpContext.Session.SetString("UserName", adminLoginViewModel.Username);
                            return RedirectToAction("CreateGovernmentUser", "Admin");
                        }
                        else
                        {
                            adminLoginViewModel.ErrorType = "Fail";
                            adminLoginViewModel.ErrorCode = "1";
                            adminLoginViewModel.ErrorMessage = _localizer["Dear User, You are not authorised to access the portal"];
                            return View(adminLoginViewModel);
                        }
                    }
                    else
                    {
                        adminLoginViewModel.ErrorType = "Fail";
                        adminLoginViewModel.ErrorCode = "1";
                        adminLoginViewModel.ErrorMessage = _localizer["Please enter valid credentials"];
                        return View(adminLoginViewModel);
                    }

                }
                else
                {
                    adminLoginViewModel.ErrorType = "Fail";
                    adminLoginViewModel.ErrorCode = "1";
                    adminLoginViewModel.ErrorMessage = _localizer["Please enter Username and Password"];
                    return View(adminLoginViewModel);
                }
               
                return View(adminLoginViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception raised in Admin Login: " + ex.Message);
                adminLoginViewModel.ErrorType = "Fail";
                adminLoginViewModel.ErrorCode = "1";
                adminLoginViewModel.ErrorMessage = _localizer["We are facing technical issue at the moment, please try again later, If issue persists please contact SEWA"];
                return View(adminLoginViewModel);
            }
        }
        public IActionResult Logout()
        {
            try
            {
                HttpContext.Session.Clear();
                return RedirectToAction("AdminLogin", "Admin");
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Exception in Logout Service: " + ex.Message);
                return RedirectToAction("AdminLogin", "Admin");
            }
        }

        public IActionResult ListGovernmentConsultant()
        {
            PremiseDetailsForGovernmentViewModel premiseDetailsForGovernmentViewModel = new PremiseDetailsForGovernmentViewModel();
            premiseDetailsForGovernmentViewModel.consultantPremiseDetailsForGovtUserOutputList = new List<ConsultantPremiseDetailsForGovtUserOutput>();
            try
            {
                if (HttpContext.Session.GetString("AdminLogin") == null)
                {
                    return RedirectToAction("AdminLogin", "Admin");
                }

                ConsultantPremiseDetailsForGovtUserInput consultantPremiseDetailsForGovtUserInput = new ConsultantPremiseDetailsForGovtUserInput();
                consultantPremiseDetailsForGovtUserInput.GovernmentUserId = 0;
                consultantPremiseDetailsForGovtUserInput.LoginedUserId = 0;
                List<ConsultantPremiseDetailsForGovtUserOutput> consultantPremiseDetailsForGovtUserOutputList = _userLayer.GetConsultantPremiseDetailsForGovtUser(consultantPremiseDetailsForGovtUserInput);
                premiseDetailsForGovernmentViewModel.consultantPremiseDetailsForGovtUserOutputList = consultantPremiseDetailsForGovtUserOutputList;
                return View(premiseDetailsForGovernmentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in Manage UserList Service:" + ex.Message);
                premiseDetailsForGovernmentViewModel.ErrorCode = "1";
                premiseDetailsForGovernmentViewModel.ErrorType = "Fail";
                premiseDetailsForGovernmentViewModel.ErrorMessage = _localizer["We are facing technical issue at the moment, please try again later, If issue persists please contact SEWA"];
                return View(premiseDetailsForGovernmentViewModel);
            }
        }


        #endregion
    }
}
