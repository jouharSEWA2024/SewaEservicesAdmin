using SEWAEContractorCore.Models.Output;

namespace SEWAEContractorAdmin.Models
{
    public class GovernmentUserViewModel : ErrorViewModel
    {
        public List<GovernmentIdRecordOutput> GovernmentBPList { get; set; }
        public string SelectedBP { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
    }
}
