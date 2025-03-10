namespace AdapterPattern.ThirdPartyService
{
    public class ProviderAService
    {
        public (string Name, decimal Cost, string Benefits) FetchPlan()
        {
            return ("Provider A Health Plan", 500.00m, "Covers hospitalization, OPD");
        }
    }
}
