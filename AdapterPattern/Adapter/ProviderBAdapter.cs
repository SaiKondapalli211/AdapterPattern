using AdapterPattern.Model;
using AdapterPattern.ThirdPartyService;

namespace AdapterPattern.Adapter
{
    public class ProviderBAdapter : IInsuranceProviderAdapter
    {
        private readonly ProviderBService _providerBService;

        public ProviderBAdapter(ProviderBService providerBService)
        {
            _providerBService = providerBService;
        }

        public InsurancePlan GetInsurancePlan()
        {
            var providerBPlan = _providerBService.GetPlanDetails();
            return new InsurancePlan
            {
                PlanName = providerBPlan.PlanTitle,
                Premium = providerBPlan.MonthlyPremium,
                CoverageDetails = providerBPlan.PolicyCoverage
            };
        }
    }
}
