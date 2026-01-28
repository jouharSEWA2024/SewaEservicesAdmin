using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;
using System.Security.Policy;

namespace SEWAEContractor.ServiceLayer
{
    public class UserLayer
    {
        private readonly IConfiguration _configuration;
        public UserLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public CheckLoginOutput CheckLoginUser(CheckLoginInput _CheckLoginInput)
        {
            CheckLoginOutput _CheckLoginOutput = new CheckLoginOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/CheckLogin");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_CheckLoginInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _CheckLoginOutput = JsonConvert.DeserializeObject<CheckLoginOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _CheckLoginOutput;
        }
        public ForgotUserNameOutput GetUser(ForgotUserNameInput forgotUserNameInput)
        {
            ForgotUserNameOutput forgotUserNameOutput=new ForgotUserNameOutput();   
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/GetUser");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(new { Email= forgotUserNameInput.Email, Username=forgotUserNameInput.Username});
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                forgotUserNameOutput = JsonConvert.DeserializeObject<ForgotUserNameOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return forgotUserNameOutput;
        }
        public CheckUserNameOutput CheckUserName(CheckUserNameInput CheckUserNameInput)
        {
            CheckUserNameOutput CheckUserNameOutput = new CheckUserNameOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/CheckUserName");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(CheckUserNameInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                CheckUserNameOutput = JsonConvert.DeserializeObject<CheckUserNameOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CheckUserNameOutput;
        }
        public CheckIDValidityOutput CheckIDValidity (CheckIDValidityInput CheckIDValidityInput)
        {
            CheckIDValidityOutput CheckIDValidityOutput = new CheckIDValidityOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/CheckIDValidity");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(new { IDType = CheckIDValidityInput.IDType,IDNumber=CheckIDValidityInput.IDNumber });
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                CheckIDValidityOutput = JsonConvert.DeserializeObject<CheckIDValidityOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return CheckIDValidityOutput;
        }
        public RegisterUserOutput RegisterUser(RegisterUserInput registerUserInput)
        {
            RegisterUserOutput _RegisterUserOutput = new RegisterUserOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/RegisterUser");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(registerUserInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _RegisterUserOutput = JsonConvert.DeserializeObject<RegisterUserOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _RegisterUserOutput;
        }
        public VerifyOTPOutput VerifyOTP(VerifyOTPInput _VerifyOTPInput)
        {
            VerifyOTPOutput _VerifyOTPOutput = new VerifyOTPOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/VerifyOTP");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_VerifyOTPInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _VerifyOTPOutput = JsonConvert.DeserializeObject<VerifyOTPOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _VerifyOTPOutput;
        }
		public List<GetOwnerOutput> GetOwnerListByEMID(GetOwnerByEMIDInput getOwnerByEMIDInput)
		{
			List<GetOwnerOutput> listItems = new List<GetOwnerOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/GetOwnerListByEMID");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(getOwnerByEMIDInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				listItems= JsonConvert.DeserializeObject<List<GetOwnerOutput>>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return listItems;
		}
        public List<GetOwnerOutput> GetOwnerList(GetOwnerInput getOwnerInput)
        {
            List<GetOwnerOutput> listItems = new List<GetOwnerOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/GetOwnerList");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(getOwnerInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                listItems = JsonConvert.DeserializeObject<List<GetOwnerOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return listItems;
        }
        public ResetPasswordLogOutput AddResetPasswordLog(ResetPasswordLogInput _ResetPasswordLogInput) 
        {
            ResetPasswordLogOutput _ResetPasswordLogOutput=new ResetPasswordLogOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/AddResetPasswordLog");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_ResetPasswordLogInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _ResetPasswordLogOutput = JsonConvert.DeserializeObject<ResetPasswordLogOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _ResetPasswordLogOutput;
        }
		public UpdatePasswordOutput UpdatePassword(UpdatePasswordInput _UpdatePasswordInput)
		{
			UpdatePasswordOutput _UpdatePasswordOutput = new UpdatePasswordOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/UpdatePassword");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_UpdatePasswordInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_UpdatePasswordOutput = JsonConvert.DeserializeObject<UpdatePasswordOutput>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return _UpdatePasswordOutput;
		}
		public List<BulkEmailOutput> GetBulkEmailList()
		{
			List<BulkEmailOutput> listItems = new List<BulkEmailOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/GetBulkEmailData");
				// client.Timeout = -1;
				//var body = @"";
				
				var request = new RestRequest("", Method.Get);
				//request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				listItems = JsonConvert.DeserializeObject<List<BulkEmailOutput>>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return listItems;
		}
		public List<GetUserTypeOutput> GetUserTypeList()
		{
			List<GetUserTypeOutput> listItems = new List<GetUserTypeOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/GetUserTypeList");
				// client.Timeout = -1;
				//var body = @"";

				var request = new RestRequest("", Method.Get);
				//request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				listItems = JsonConvert.DeserializeObject<List<GetUserTypeOutput>>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return listItems;
		}
		public AddOwnerUUIDInfoOutput AddOwnerUUID(AddOwnerUUIDInfoInput _AddOwnerUUIDInfoInput)
		{
			AddOwnerUUIDInfoOutput _AddOwnerUUIDInfoOutput = new AddOwnerUUIDInfoOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/AddOwnerUUID");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_AddOwnerUUIDInfoInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_AddOwnerUUIDInfoOutput = JsonConvert.DeserializeObject<AddOwnerUUIDInfoOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _AddOwnerUUIDInfoOutput;
		}
		public CheckOwnerUUIDOutput CheckOwnerUUID(CheckOwnerUUIDInput _CheckOwnerUUIDInput)
		{
			CheckOwnerUUIDOutput _CheckOwnerUUIDOutput = new CheckOwnerUUIDOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/CheckOwnerUUID");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_CheckOwnerUUIDInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_CheckOwnerUUIDOutput = JsonConvert.DeserializeObject<CheckOwnerUUIDOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _CheckOwnerUUIDOutput;
		}
		public int AddChildUser(AddChildUserInput addChildUserInput)
		{
            int result = 0;    
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/AddChildUser");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(addChildUserInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				result = JsonConvert.DeserializeObject<int>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
        public int AddConsultantForGovernment(AddConsultantForGovernmentInput addConsultantForGovernmentInput)
        {
            int result = 0;
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/AddConsultantForGovernment");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(addConsultantForGovernmentInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
		public List<string> GetGovernmentBPForApprovedConsultant(GetGovernmentBPForApprovedConsultantInput getGovernmentBPForApprovedConsultantInput)
		{
            List<string> result = new List<string>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/GetGovernmentBPForApprovedConsultant");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(getGovernmentBPForApprovedConsultantInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				result = JsonConvert.DeserializeObject<List<string>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return result;
		}
		public List<ApprovedPremiseDetailsForConsultantOutput> GetPremiseDetailsForApprovedConsultant(ApprovedPremiseDetailsForConsultantInput approvedPremiseDetailsForConsultantInput)
		{
			List<ApprovedPremiseDetailsForConsultantOutput> approvedPremiseDetailsForConsultantOutputs = new List<ApprovedPremiseDetailsForConsultantOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/User/GetPremiseDetailsForApprovedConsultant");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(approvedPremiseDetailsForConsultantInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				approvedPremiseDetailsForConsultantOutputs = JsonConvert.DeserializeObject<List<ApprovedPremiseDetailsForConsultantOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return approvedPremiseDetailsForConsultantOutputs;
		}
        public List<GovtChildUserOutput> GetGovtChildUser(GovtChildUserInput govtChildUserInput)
        {
            List<GovtChildUserOutput> govtChildUserOutputList=new List<GovtChildUserOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/GetChildUser");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(govtChildUserInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                govtChildUserOutputList = JsonConvert.DeserializeObject<List<GovtChildUserOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return govtChildUserOutputList;
        }
        public List<ConsultantPremiseDetailsForGovtUserOutput> GetConsultantPremiseDetailsForGovtUser(ConsultantPremiseDetailsForGovtUserInput consultantPremiseDetailsForGovtUserInput)
        {
            List<ConsultantPremiseDetailsForGovtUserOutput> consultantPremiseDetailsForGovtUserOutputList = new List<ConsultantPremiseDetailsForGovtUserOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/GetConsultantPremiseDetailsForGovtUser");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(consultantPremiseDetailsForGovtUserInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                consultantPremiseDetailsForGovtUserOutputList = JsonConvert.DeserializeObject<List<ConsultantPremiseDetailsForGovtUserOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return consultantPremiseDetailsForGovtUserOutputList;
        }
        public VerifyOTPForTransactionIDOutput VerifyOTPBasedOnTransactionID(VerifyOTPForTransactionIDInput verifyOTPForTransactionIDInput)
        {
            VerifyOTPForTransactionIDOutput verifyOTPForTransactionIDOutput = new VerifyOTPForTransactionIDOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/VerifyOTPBasedOnTransactionID");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(verifyOTPForTransactionIDInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                verifyOTPForTransactionIDOutput = JsonConvert.DeserializeObject<VerifyOTPForTransactionIDOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return verifyOTPForTransactionIDOutput;
        }
        public int AddMainUser(AddMainUserInput addMainUserInput)
        {
            int result = 0;
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/AddMainUser");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(addMainUserInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
        public int checkAdminLogin(CheckLoginInput _checkLoginInput)
        {
            int result = 0;
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/User/CheckAdminLogin");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_checkLoginInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                result = JsonConvert.DeserializeObject<int>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }
    }
}
