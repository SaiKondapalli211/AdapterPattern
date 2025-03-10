using AdapterPattern.Model;

namespace AdapterPattern.Adapter
{
    public interface IInsuranceProviderAdapter
    {
        InsurancePlan GetInsurancePlan();
    }
}
