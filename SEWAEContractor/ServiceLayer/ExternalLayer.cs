using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.External.Input;
using SEWAEContractorCore.Models.External.Output;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractor.ServiceLayer
{
	public class ExternalLayer
	{
		private readonly IConfiguration _configuration;
		public ExternalLayer(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public GetPersonInformationOutput GetCustomerInformation(GetPersonInformationInput getPersonInformationInput)
		{
			GetPersonInformationOutput _GetPersonInformationOutput = new GetPersonInformationOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/External/GetPersonInformation");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(getPersonInformationInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_GetPersonInformationOutput = JsonConvert.DeserializeObject<GetPersonInformationOutput>(response.Content);
			}
			catch (Exception ex)
			{
                _GetPersonInformationOutput.responseCode = "1";
                _GetPersonInformationOutput.responseDesc= ex.Message;    
                return _GetPersonInformationOutput; 
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);

            }
			return _GetPersonInformationOutput;
		}
		public EconomicLicenceOutput GetTradeLicenseInformation(EconomicLicenceInput _EconomicLicenceInput)
		{
			EconomicLicenceOutput _EconomicLicenceOutput = new EconomicLicenceOutput();
           
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/SEDD/GetLicenseInfo");
				// client.Timeout = -1;
				//var body = @"";
				var jsonParams = JsonConvert.SerializeObject(_EconomicLicenceInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_EconomicLicenceOutput = JsonConvert.DeserializeObject<EconomicLicenceOutput>(response.Content);
    //            if(_EconomicLicenceOutput.ResponseCode==500)
    //            {
    //                _EconomicLicenceOutput.ResponseCode = 1;

				//}
			}
			catch (Exception ex)
			{
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				_EconomicLicenceOutput.ResponseMessage=ex.Message;
                _EconomicLicenceOutput.ResponseCode = 1;
			}
			return _EconomicLicenceOutput;
		}

		public void SendEmail(SendEmailInput _SendEmailInput)
		{
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/External/SendEmail");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_SendEmailInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                
            }
            catch (Exception ex)
            {
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				throw ex;
            }
        }
        public UAEPassAccessTokenOutput GetUAEPassAccessToken(UAEPassAccessTokenInput _UAEPassAccessTokenInput)
        {
            UAEPassAccessTokenOutput _UAEPassAccessTokenOutput = new UAEPassAccessTokenOutput();
            string result;
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/External/GetUAEPassAccessToken");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_UAEPassAccessTokenInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _UAEPassAccessTokenOutput = JsonConvert.DeserializeObject<UAEPassAccessTokenOutput>(response.Content);
                //result = JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _UAEPassAccessTokenOutput;
        }
        public UAEPassUserInfoOutput GetUAEPassUserInfo(UAEPassUserInfoInput _UAEPassUserInfoInput)
        {
            UAEPassUserInfoOutput _UAEPassUserInfoOutput = new UAEPassUserInfoOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/External/GetUAEPassUserInfo");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(_UAEPassUserInfoInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _UAEPassUserInfoOutput = JsonConvert.DeserializeObject<UAEPassUserInfoOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _UAEPassUserInfoOutput;
        }
        public MunicipalityTokenServiceOutput GetMunicipalityServiceToken()
        {
            MunicipalityTokenServiceOutput _MunicipalityTokenServiceOutput = new MunicipalityTokenServiceOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/External/GetMunicipalityServiceToken");
                // client.Timeout = -1;
                //var body = @"";
                //var jsonParams = JsonConvert.SerializeObject(_UAEPassUserInfoInput);
                var request = new RestRequest("", Method.Post);
                //request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _MunicipalityTokenServiceOutput = JsonConvert.DeserializeObject<MunicipalityTokenServiceOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _MunicipalityTokenServiceOutput;
        }
        public GetOwnerPlotOutput GetOwnerPlotInfo(GetOwnerPlotInput getOwnerPlotInput)
        {
            GetOwnerPlotOutput _GetOwnerPlotOutput = new GetOwnerPlotOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/External/GetOwnerPlotInfo");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(getOwnerPlotInput);
                var request = new RestRequest("", Method.Post);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetOwnerPlotOutput = JsonConvert.DeserializeObject<GetOwnerPlotOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _GetOwnerPlotOutput;
        }
    }
}
