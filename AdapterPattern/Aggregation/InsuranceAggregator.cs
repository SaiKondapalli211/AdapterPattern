using AdapterPattern.Adapter;
using AdapterPattern.Model;

namespace AdapterPattern.Aggregation
{
    public class InsuranceAggregator
    {
        private readonly IEnumerable<IInsuranceProviderAdapter> _adapters;

        public InsuranceAggregator(IEnumerable<IInsuranceProviderAdapter> adapters)
        {
            _adapters = adapters;
        }

        public List<InsurancePlan> GetAllPlans()
        {
            return _adapters.Select(adapter => adapter.GetInsurancePlan()).ToList();
        }
    }
}
