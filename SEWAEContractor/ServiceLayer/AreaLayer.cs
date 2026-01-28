using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;
using System;

namespace SEWAEContractor.ServiceLayer
{
    public class AreaLayer
    {
        private readonly IConfiguration _configuration;
        public AreaLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AreaOutput GetAreaByCity(AreaInput areaInput)
        {

            AreaOutput areaOutput = new AreaOutput();
            areaOutput.areaDtlOutputs = new List<AreaDtlOutput>();

            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Area/GetAreaListbycity");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;



                var jsonParams = JsonConvert.SerializeObject(areaInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                areaOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<AreaDtlOutput>>(response.Content);
                //areaOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<AreaDtlOutput>>(areaOutputs);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return areaOutput;
        }
        public GetAreaCodeOutput GetAreaCodeByAreaName(GetAreaCodeInput _GetAreaCodeInput)
        {

            GetAreaCodeOutput getAreaCodeOutput = new GetAreaCodeOutput();



            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Area/GetAreaCodeByAreaName");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;



                var jsonParams = JsonConvert.SerializeObject(_GetAreaCodeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                getAreaCodeOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<GetAreaCodeOutputDtl>>(response.Content);
                // _GetAreaCodeOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<GetAreaCodeOutputDtl>>(areaOutputs);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return getAreaCodeOutput;
        }
        public List<AreaDtlOutput> GetFullAreaList()
        {
            List<AreaDtlOutput> areaDtlOutputs = new List<AreaDtlOutput>();
          
            try
            {
                string baseUrl = _configuration["APIUrl"];

                var client = new RestClient(baseUrl);
                var request = new RestRequest("api/Area/GetFullAreaList", Method.Get);
                request.AddHeader("Content-Type", "application/json");
                // Optional: Add headers if needed
                // request.AddHeader("Authorization", "Bearer your_token");

                RestResponse response = client.Execute(request);
                areaDtlOutputs = JsonConvert.DeserializeObject<List<AreaDtlOutput>>(response.Content);
                //areaOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<AreaDtlOutput>>(areaOutputs);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return areaDtlOutputs;
        }
        public GetAreaCodeOutput GetSewaAreaCode(GetSewaAreaCodeInput _GetSewaAreaCodeInput)
        {

            GetAreaCodeOutput getAreaCodeOutput = new GetAreaCodeOutput();



            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Area/GetSewaAreaCode");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;



                var jsonParams = JsonConvert.SerializeObject(_GetSewaAreaCodeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                getAreaCodeOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<GetAreaCodeOutputDtl>>(response.Content);
                // _GetAreaCodeOutput.areaDtlOutputs = JsonConvert.DeserializeObject<List<GetAreaCodeOutputDtl>>(areaOutputs);
            }
            catch (Exception ex)
            {
                //common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
                throw ex;
            }
            return getAreaCodeOutput;
        }
    }
}
