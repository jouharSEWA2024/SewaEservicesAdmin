using Newtonsoft.Json;
using RestSharp;
using SEWAEContractorCore.Models.Input;
using SEWAEContractorCore.Models.Output;
using System.Collections.Generic;


namespace SEWAEContractor.ServiceLayer
{
    public class MasterLayer
    {
        private readonly IConfiguration _configuration;
        public MasterLayer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<GetIDTypeOutput> GetIDTypeList()
        {
            List<GetIDTypeOutput> list = new List<GetIDTypeOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetIDTypeList");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;



                var request = new RestRequest("", Method.Get);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                list = JsonConvert.DeserializeObject<List<GetIDTypeOutput>>(response.Content);
            }
            catch (Exception ex)
            {
				
				throw ex;
            }
            return list;
        }
        public List<GetIDTypeOutput> GetIDTypeListForRegistration()
        {
            List<GetIDTypeOutput> list = new List<GetIDTypeOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetIDTypeListForRegistration");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;



                var request = new RestRequest("", Method.Get);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                list = JsonConvert.DeserializeObject<List<GetIDTypeOutput>>(response.Content);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return list;
        }
        public List<CityMasterOutput> GetCityList()
		{
			List<CityMasterOutput> list = new List<CityMasterOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetCityList");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;
				var request = new RestRequest("", Method.Get);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<CityMasterOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return list;
		}
		public List<AccountTypeMasterOutput> GetAccountTypeList()
		{
			List<AccountTypeMasterOutput> list = new List<AccountTypeMasterOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetAccountType");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var request = new RestRequest("", Method.Get);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<AccountTypeMasterOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				//common.LogError("LoginModel : VerifyUser : API Exception ", ex.Message);
				throw ex;
			}
			return list;
		}
		public List<SubServiceTypeMasterOutput> GetSubServiceTypeList(SubServiceTypeMasterInput subServiceTypeMasterInput)
		{
			List< SubServiceTypeMasterOutput> list = new List<SubServiceTypeMasterOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetSubServiceType");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(subServiceTypeMasterInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<SubServiceTypeMasterOutput >> (response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return list;
		}
		public List<SubServiceTypeMasterOutput> getAllSubServiceTypeByServiceTypeIdandGroup(SubServiceTypeMasterInput subServiceTypeMasterInput)
		{
			List<SubServiceTypeMasterOutput> list = new List<SubServiceTypeMasterOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/getAllSubServiceTypeByServiceTypeIdandGroup");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(subServiceTypeMasterInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<SubServiceTypeMasterOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return list;
		}
		public GetSubServiceOutput GetSubServiceType(GetSubServiceInput _GetSubServiceInput)
		{
			GetSubServiceOutput getSubServiceOutput = new GetSubServiceOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetSubService");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetSubServiceInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getSubServiceOutput = JsonConvert.DeserializeObject<GetSubServiceOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return getSubServiceOutput;
		}
		public GetServiceOutput GetServiceType(GetServiceInput _GetServiceInput)
		{
			GetServiceOutput getServiceOutput = new GetServiceOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetService");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetServiceInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getServiceOutput = JsonConvert.DeserializeObject<GetServiceOutput>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return getServiceOutput;
		}
		public GetCityOutput GetCityType(GetCityInput _GetCityInput)
		{
			GetCityOutput getCityOutput = new GetCityOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetCity");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetCityInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getCityOutput = JsonConvert.DeserializeObject<GetCityOutput>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return getCityOutput;
		}
		public GetCityIdOutput GetCityId(GetCityIdInput _GetCityIdInput)
		{
			GetCityIdOutput getCityIdOutput = new GetCityIdOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetCityId");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetCityIdInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getCityIdOutput = JsonConvert.DeserializeObject<GetCityIdOutput>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return getCityIdOutput;
		}
		public List<SAPDoscumentTypesOutput> GetSAPDocumentTypeList(List<SAPDoscumentTypesInput> sAPDoscumentTypesInputList)
		{
			List<SAPDoscumentTypesOutput> list = new List<SAPDoscumentTypesOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetSAPDocumentTypeList");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;


				var jsonParams = JsonConvert.SerializeObject(sAPDoscumentTypesInputList);
				var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);
                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<SAPDoscumentTypesOutput>>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return list;
		}
        public GetDocumentTypeOutput GetDocumentType(GetDocumentTypeInput _GetDocumentTypeInput)
        {
            GetDocumentTypeOutput _GetDocumentTypeOutput = new GetDocumentTypeOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetDocumentType");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetDocumentTypeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetDocumentTypeOutput = JsonConvert.DeserializeObject<GetDocumentTypeOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetDocumentTypeOutput;
        }
        public GetSAPDocumentTypeOutput GetSAPDocumentType(GetSAPDocumentTypeInput _GetSAPDocumentTypeInput)
        {
            GetSAPDocumentTypeOutput _GetSAPDocumentTypeOutput = new GetSAPDocumentTypeOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetSAPDocumentType");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetSAPDocumentTypeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetSAPDocumentTypeOutput = JsonConvert.DeserializeObject<GetSAPDocumentTypeOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetSAPDocumentTypeOutput;
        }
		public List<GetServiceListOutput> GetServiceList(GetServiceListInput _GetServiceListInput)
		{
			List<GetServiceListOutput> _GetServiceListOutput = new List<GetServiceListOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetServiceList");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetServiceListInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_GetServiceListOutput = JsonConvert.DeserializeObject<List<GetServiceListOutput>>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return _GetServiceListOutput;
		}
        public List<GovernmentBPMasterOutput> GetGovernmentBPList()
        {
            List<GovernmentBPMasterOutput> list = new List<GovernmentBPMasterOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetGovernmentBP");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var request = new RestRequest("", Method.Get);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                list = JsonConvert.DeserializeObject<List<GovernmentBPMasterOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
		public GetServiceNameOutput GetServiceName(GetServiceNameInput _GetServiceNameInput)
		{
			GetServiceNameOutput getServiceNameOutput = new GetServiceNameOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetServiceName");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetServiceNameInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getServiceNameOutput = JsonConvert.DeserializeObject<GetServiceNameOutput>(response.Content);
			}
			catch (Exception ex)
			{
                throw ex;
            }
			return getServiceNameOutput;
		}
        public List<string> GetGeneralNOCList(GetAllGeneralNOCInput _GetAllGeneralNOCInput)
        {
            List<string> list = new List<string>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetGeneralNOCList");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;
                var jsonParams = JsonConvert.SerializeObject(_GetAllGeneralNOCInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                list = JsonConvert.DeserializeObject<List<string>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }
		public List<GetInspectionTypeListOutput> GetInspectionTypeList(GetInspectionTypeListInput _GetInspectionTypeListInput)
		{
			List<GetInspectionTypeListOutput> list = new List<GetInspectionTypeListOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetInspectionTypeList");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_GetInspectionTypeListInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				list = JsonConvert.DeserializeObject<List<GetInspectionTypeListOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return list;
		}
        public GetConnectionTypeOutput GetConnectionType(GetConnectionTypeInput _GetConnectionTypeInput)
        {
            GetConnectionTypeOutput _GetConnectionTypeOutput = new GetConnectionTypeOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetConnectionType");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetConnectionTypeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetConnectionTypeOutput = JsonConvert.DeserializeObject<GetConnectionTypeOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetConnectionTypeOutput;
        }
        public GetInspectionStepTypeOutput GetInspectionStepType(GetInspectionStepTypeInput _GetInspectionStepType)
        {
            GetInspectionStepTypeOutput _GetInspectionStepTypeOutput = new GetInspectionStepTypeOutput();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetInspectionStepType");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetInspectionStepType);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetInspectionStepTypeOutput = JsonConvert.DeserializeObject<GetInspectionStepTypeOutput>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetInspectionStepTypeOutput;
        }
        public List<GetSubServiceCategoryTypeOutput> GetSubServiceCategoryType(GetSubServiceCategoryTypeInput _GetSubServiceCategoryTypeInput)
        {
            List<GetSubServiceCategoryTypeOutput> _GetSubServiceCategoryTypeOutputList = new List<GetSubServiceCategoryTypeOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetSubServiceCategoryType");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetSubServiceCategoryTypeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetSubServiceCategoryTypeOutputList = JsonConvert.DeserializeObject<List<GetSubServiceCategoryTypeOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetSubServiceCategoryTypeOutputList;
        }
		public ProjectCategoryMappingOutput GetProjectCategoryMapping(ProjectCategoryMappingInput _ProjectCategoryMappingInput)
		{
			ProjectCategoryMappingOutput _ProjectCategoryMappingOutput = new ProjectCategoryMappingOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetProjectCategoryMapping");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(_ProjectCategoryMappingInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_ProjectCategoryMappingOutput = JsonConvert.DeserializeObject<ProjectCategoryMappingOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _ProjectCategoryMappingOutput;
		}
        public List<GetSubServiceCategoryTypeOutput> GetCategoryTypeBasedOnSubService(GetCategoryTypeBasedOnSubServiceInput _GetCategoryTypeBasedOnSubServiceInput)
        {
            List<GetSubServiceCategoryTypeOutput> _GetSubServiceCategoryTypeOutputList = new List<GetSubServiceCategoryTypeOutput>();
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetCategoryTypeBasedOnSubService");
                // client.Timeout = -1;
                //var body = @"";
                //var body = GetBusinessPartnerTechnicalDataInputList;

                var jsonParams = JsonConvert.SerializeObject(_GetCategoryTypeBasedOnSubServiceInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                _GetSubServiceCategoryTypeOutputList = JsonConvert.DeserializeObject<List<GetSubServiceCategoryTypeOutput>>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return _GetSubServiceCategoryTypeOutputList;
        }
		public List<GetSubServiceCategoryTypeOutput> GetAllCategories()
		{
			List<GetSubServiceCategoryTypeOutput> _GetSubServiceCategoryTypeOutputList = new List<GetSubServiceCategoryTypeOutput>();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetAllCategories");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

	
				var request = new RestRequest("", Method.Get);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				_GetSubServiceCategoryTypeOutputList = JsonConvert.DeserializeObject<List<GetSubServiceCategoryTypeOutput>>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return _GetSubServiceCategoryTypeOutputList;
		}
		public GetCategoryTypeBasedOnIdOutput GetCategoryTypeBasedOnId(GetCategoryTypeBasedOnIdInput getCategoryTypeBasedOnIdInput)
		{
			GetCategoryTypeBasedOnIdOutput getCategoryTypeBasedOnIdOutput = new GetCategoryTypeBasedOnIdOutput();	
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetCategoryTypeById");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(getCategoryTypeBasedOnIdInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getCategoryTypeBasedOnIdOutput = JsonConvert.DeserializeObject<GetCategoryTypeBasedOnIdOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return getCategoryTypeBasedOnIdOutput;
		}
		public GetServiceReasonCategoryBasedOnCategoryAndServiceOutput GetServiceReasonCategoryBasedonCategoryAndService(GetServiceReasonCategoryBasedOnCategoryAndServiceInput getServiceReasonCategoryBasedOnCategoryAndServiceInput)
		{
			GetServiceReasonCategoryBasedOnCategoryAndServiceOutput getServiceReasonCategoryBasedOnCategoryAndServiceOutput=new GetServiceReasonCategoryBasedOnCategoryAndServiceOutput();
			try
			{
				string baseUrl = _configuration["APIUrl"];
				var client = new RestClient(baseUrl + "api/Master/GetServiceReasonCategoryBasedOnCategoryAndService");
				// client.Timeout = -1;
				//var body = @"";
				//var body = GetBusinessPartnerTechnicalDataInputList;

				var jsonParams = JsonConvert.SerializeObject(getServiceReasonCategoryBasedOnCategoryAndServiceInput);
				var request = new RestRequest("", Method.Get);
				request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

				//request.UseDefaultCredentials = true;
				RestResponse response = client.Execute(request);
				getServiceReasonCategoryBasedOnCategoryAndServiceOutput = JsonConvert.DeserializeObject<GetServiceReasonCategoryBasedOnCategoryAndServiceOutput>(response.Content);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return getServiceReasonCategoryBasedOnCategoryAndServiceOutput;
		}
        public bool GetOTPRequiredBasedOnIDType(GetOTPRequiredBasedOnIDTypeInput getOTPRequiredBasedOnIDTypeInput)
        {
			bool OTPRequired = false;
            try
            {
                string baseUrl = _configuration["APIUrl"];
                var client = new RestClient(baseUrl + "api/Master/GetOTPRequiredBasedOnIDType");

                var jsonParams = JsonConvert.SerializeObject(getOTPRequiredBasedOnIDTypeInput);
                var request = new RestRequest("", Method.Get);
                request.AddParameter("application/json", jsonParams, ParameterType.RequestBody);

                //request.UseDefaultCredentials = true;
                RestResponse response = client.Execute(request);
                OTPRequired = JsonConvert.DeserializeObject<bool>(response.Content);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return OTPRequired;
        }
    }
}
