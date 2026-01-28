using Newtonsoft.Json;
using NuGet.Protocol.Core.Types;
using RestSharp;
using SEWAEContractor.Controllers;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractor.ServiceLayer
{
    public class BPLayer
    {
        private readonly IConfiguration _configuration;
        
        public BPLayer(IConfiguration configuration)
        {
            _configuration = configuration;
            
        }
        public GetBusinessPartnerTechnicalDataOutput GetBusinessPartnerData(List<GetBusinessPartnerTechnicalDataInput> GetBusinessPartnerTechnicalDataInputList)
        {
            GetBusinessPartnerTechnicalDataOutput _GetBusinessPartnerTechnicalDataOutput = new GetBusinessPartnerTechnicalDataOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/BP/GetBusinessPartnerByTechnicalData");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                
                var jsonParams = JsonConvert.SerializeObject(GetBusinessPartnerTechnicalDataInputList);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetBusinessPartnerTechnicalDataOutput = JsonConvert.DeserializeObject<GetBusinessPartnerTechnicalDataOutput>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
               throw ex;
            }
            return _GetBusinessPartnerTechnicalDataOutput;
        }
		public CreateBPOutput CreateBP(CreateBPInput createBPInput)
		{
			CreateBPOutput createBPOutput = new CreateBPOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/BP/CreateBP");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;


				var jsonParams = JsonConvert.SerializeObject(createBPInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				createBPOutput = JsonConvert.DeserializeObject<CreateBPOutput>(response.Content);
			}
			catch (Exception ex)
			{
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                createBPOutput.ResponseCode = 1;
                createBPOutput.ResponseMessage = ex.Message;    
                return createBPOutput;

            }
			return createBPOutput;
		}
        public List<GetBusinessPartnerTechnicalDataOutput> GetBusinessPartnerDataV2(List<GetBusinessPartnerTechnicalDataInput> GetBusinessPartnerTechnicalDataInputList)
        {
            List<GetBusinessPartnerTechnicalDataOutput> _GetBusinessPartnerTechnicalDataOutputList = new List<GetBusinessPartnerTechnicalDataOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/BP/GetBusinessPartnerByTechnicalDataV2");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;


                var jsonParams = JsonConvert.SerializeObject(GetBusinessPartnerTechnicalDataInputList);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetBusinessPartnerTechnicalDataOutputList = JsonConvert.DeserializeObject<List<GetBusinessPartnerTechnicalDataOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return _GetBusinessPartnerTechnicalDataOutputList;
        }
		public AddBPRoleOutput CreateBPRole(AddBPRoleInput addBPRoleInput)
		{
			AddBPRoleOutput addBPRoleOutput = new AddBPRoleOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/BP/CreateBPRole");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;


				var jsonParams = JsonConvert.SerializeObject(addBPRoleInput);
				var request = new RestRequest("", Method.Post);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				addBPRoleOutput = JsonConvert.DeserializeObject<AddBPRoleOutput>(response.Content);
			}
			catch (Exception ex)
			{
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				addBPRoleOutput.ResponseCode = 1;
				addBPRoleOutput.ResponseMessage = ex.Message;
				return addBPRoleOutput;

			}
			return addBPRoleOutput;
		}
	}
}
