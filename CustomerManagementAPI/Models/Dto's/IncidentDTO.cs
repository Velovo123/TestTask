namespace CustomerManagementAPI.Dto_s
{
    public class IncidentDTO
    {
        public string IncidentName { get; set; }
        public string Description { get; set; }
        public List<AccountDTO> Accounts { get; set; }
    }
}
