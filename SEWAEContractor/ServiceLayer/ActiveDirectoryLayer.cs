using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractorAdmin.ServiceLayer
{
    public class ActiveDirectoryLayer
    {
        private readonly IConfiguration _configuration;
        public ActiveDirectoryLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public AuthenticateADUserOutput AuthenticateUser(CheckLoginInput _CheckLoginInput)
        {
            AuthenticateADUserOutput _AuthenticateADUserOutput = new AuthenticateADUserOutput(); 
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/ActiveDirectory/AuthenticateUser");

                var jsonParams = JsonConvert.SerializeObject(_CheckLoginInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                RestResponse response = client.Execute(request);
                _AuthenticateADUserOutput = JsonConvert.DeserializeObject<AuthenticateADUserOutput>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _AuthenticateADUserOutput;
        }
    }

}
