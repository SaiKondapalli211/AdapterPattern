namespace AdapterPattern.ThirdPartyService
{
    public class ProviderBService
    {
        public (string PlanTitle, decimal MonthlyPremium, string PolicyCoverage) GetPlanDetails()
        {
            return ("Provider B Comprehensive Plan", 450.00m, "Includes dental, vision, and emergency");
        }
    }
}
