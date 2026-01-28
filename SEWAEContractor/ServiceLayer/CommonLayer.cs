using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractor.ServiceLayer
{
    public class CommonLayer
    {
        private readonly IConfiguration _configuration;
        public CommonLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public VerifyMobileOutput VerifyMobile(VerifyMobileInput verifyMobileInput)
        {
            VerifyMobileOutput _VerifyMobileOutput = new VerifyMobileOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Common/VerifyMobile");
                // client.Timeout = -1;
                //var body = @"";
                var jsonParams = JsonConvert.SerializeObject(verifyMobileInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _VerifyMobileOutput = JsonConvert.DeserializeObject<VerifyMobileOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _VerifyMobileOutput;
        }
		public List<ProjectCategoryOutput> GetProjectCategory()
		{
			List<ProjectCategoryOutput> _ProjectCategoryOutputList = new List<ProjectCategoryOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Common/GetProjectCategory");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				//var jsonParams = JsonConvert.SerializeObject(_GetSubServiceCategoryTypeInput);
				var request = new RestRequest("", Method.Get);
				//request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_ProjectCategoryOutputList = JsonConvert.DeserializeObject<List<ProjectCategoryOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _ProjectCategoryOutputList;
		}
		public List<ReasonOfSubmissionOutput> GetReasonOfSubmission()
		{
			List<ReasonOfSubmissionOutput> _ReasonOfSubmissionOutputList = new List<ReasonOfSubmissionOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Common/GetReasonOfSubmission");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				//var jsonParams = JsonConvert.SerializeObject(_GetSubServiceCategoryTypeInput);
				var request = new RestRequest("", Method.Get);
				//request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_ReasonOfSubmissionOutputList = JsonConvert.DeserializeObject<List<ReasonOfSubmissionOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _ReasonOfSubmissionOutputList;
		}
		public List<TransformerTypeOutput> GetTransformerType()
		{
			List<TransformerTypeOutput > _TransformerTypeOutputList = new List<TransformerTypeOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Common/GetTransformerType");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				//var jsonParams = JsonConvert.SerializeObject(_GetSubServiceCategoryTypeInput);
				var request = new RestRequest("", Method.Get);
				//request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_TransformerTypeOutputList = JsonConvert.DeserializeObject<List<TransformerTypeOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _TransformerTypeOutputList;
		}
		public List<GetProjectPurposeOutput> GetProjectPurpose()
		{
			List<GetProjectPurposeOutput> list = new List<GetProjectPurposeOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Common/GetProjectPurpose");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;



				var request = new RestRequest("", Method.Get);

                
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<GetProjectPurposeOutput>>(response.Content);
			}
			catch (Exception ex)
			{

				throw ex;
			}
			return list;
		}
        public string GetAccountTypeFromProjectCategory(GetAccountTypeFromProjectCategoryInput _GetAccountTypeFromProjectCategoryInput)
        {
			string AccountTypeId="";
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Common/GetAccountTypeFromProjectCategory");
                var jsonParams = JsonConvert.SerializeObject(_GetAccountTypeFromProjectCategoryInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                AccountTypeId = JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return AccountTypeId;
        }
        public string GetProjectCategoryFromDTPSLandUsageInfo(GetProjectCategoryFromDTPSLandUsageInfoInput _GetProjectCategoryFromDTPSLandUsageInfoInput)
        {
            string ProjectCategoryId = "";
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Common/GetProjectCategoryFromDTPSLandUsageInfo");
                var jsonParams = JsonConvert.SerializeObject(_GetProjectCategoryFromDTPSLandUsageInfoInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                ProjectCategoryId = JsonConvert.DeserializeObject<string>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return ProjectCategoryId;
        }
    }
}
