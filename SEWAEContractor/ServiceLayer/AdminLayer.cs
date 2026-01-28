using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Output;

namespace SEWAEContractor.ServiceLayer
{
    public class AdminLayer
    {
        private readonly IConfiguration _configuration;
        public AdminLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public GovernmentIdOutput GetGovernmentList()
        {
            GovernmentIdOutput governmentList = new GovernmentIdOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Admin/GetGovernmentID");
                
                var request = new RestRequest("", Method.Get);
                RestResponse response = client.Execute(request);
                governmentList = JsonConvert.DeserializeObject<GovernmentIdOutput>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return governmentList;
        }
        public List<string> GetAllGovtRegisteredBP()
        {
            List<string> _getAllGovtRegisterdBP=new List<string>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Admin/GetGovtRegisteredBP");

                var request = new RestRequest("", Method.Get);
                RestResponse response = client.Execute(request);
                _getAllGovtRegisterdBP = JsonConvert.DeserializeObject<List<string>>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return _getAllGovtRegisterdBP;
        }
    }
}
