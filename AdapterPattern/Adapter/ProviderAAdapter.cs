using AdapterPattern.Model;
using AdapterPattern.ThirdPartyService;

namespace AdapterPattern.Adapter
{
    public class ProviderAAdapter : IInsuranceProviderAdapter
    {
        private readonly ProviderAService _providerAService;

        public ProviderAAdapter(ProviderAService providerAService)
        {
            _providerAService = providerAService;
        }

        public InsurancePlan GetInsurancePlan()
        {
            var providerAPlan = _providerAService.FetchPlan();
            return new InsurancePlan
            {
                PlanName = providerAPlan.Name,
                Premium = providerAPlan.Cost,
                CoverageDetails = providerAPlan.Benefits
            };
        }
    }
}
