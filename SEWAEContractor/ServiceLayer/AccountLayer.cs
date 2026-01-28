using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractor.ServiceLayer
{
	public class AccountLayer
	{
		private readonly IConfiguration _configuration;
		public AccountLayer(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public CreateAccountOutput CreateAccount(CreateAccountInput createAccountInput)
		{
			CreateAccountOutput createAccountOutput = new CreateAccountOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Account/CreateAccount");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(createAccountInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				createAccountOutput = JsonConvert.DeserializeObject<CreateAccountOutput>(response.Content);
			}
			catch (Exception ex)
			{
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                createAccountOutput.ResponseCode = 1;
                createAccountOutput.ResponseMessage = ex.Message;
                return createAccountOutput; 
            }
			return createAccountOutput;
		}
        public GetAccountOutput GetAccountListByBP(GetAccountInput _getAccountInput)
        {
            GetAccountOutput getAccountOutput = new GetAccountOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Account/GetAccountListByBP");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_getAccountInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                getAccountOutput = JsonConvert.DeserializeObject<GetAccountOutput>(response.Content);
            }
            catch (Exception ex)
            {
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				throw ex;
            }
            return getAccountOutput;
        }
		public GetOwnerInfoOutput GetOwnerAccountListByBP(GetOwnerInfoInput _GetOwnerInfoInput)
		{
			GetOwnerInfoOutput _GetOwnerInfoOutput = new GetOwnerInfoOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Account/GetOwnerAccountListByBP");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_GetOwnerInfoInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_GetOwnerInfoOutput = JsonConvert.DeserializeObject<GetOwnerInfoOutput>(response.Content);
			}
			catch (Exception ex)
			{
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				throw ex;
			}
			return _GetOwnerInfoOutput;
		}
        public GetNOCByCAOutput GetNOCByCA(GetNOCByCAInput _GetNOCByCAInput)
        {
            GetNOCByCAOutput _GetNOCByCAOutput = new GetNOCByCAOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Account/GetNOCByCA");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_GetNOCByCAInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetNOCByCAOutput = JsonConvert.DeserializeObject<GetNOCByCAOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _GetNOCByCAOutput;
        }
        public GetAccountOutput GetAccountListByFilter(GetAccountInput _getAccountInput)
        {
            GetAccountOutput getAccountOutput = new GetAccountOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Account/GetAccountListByFilter");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_getAccountInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                getAccountOutput = JsonConvert.DeserializeObject<GetAccountOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return getAccountOutput;
        }
		public GetExistingAccountOutput GetExistingAccountListByFilter (List<GetExistingAccountInput> _GetExistingAccountInputList)
		{
			GetExistingAccountOutput _GetExistingAccountOutput = new GetExistingAccountOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Account/GetExistingAccountListByFilter");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_GetExistingAccountInputList);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_GetExistingAccountOutput = JsonConvert.DeserializeObject<GetExistingAccountOutput>(response.Content);
			}
			catch (Exception ex)
			{
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				throw ex;
			}
			return _GetExistingAccountOutput;
		}
        public GetOwnerInfoOutput GetOwnerAccountListByFilter(GetOwnerAccountInfoInput _GetOwnerAccountInfoInput)
        {
            GetOwnerInfoOutput _GetOwnerInfoOutput = new GetOwnerInfoOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Account/GetOwnerAccountListByFilter");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_GetOwnerAccountInfoInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetOwnerInfoOutput = JsonConvert.DeserializeObject<GetOwnerInfoOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _GetOwnerInfoOutput;
        }
    }
}
