using AdapterPattern.Adapter;
using AdapterPattern.Aggregation;
using AdapterPattern.Model;
using Moq;

namespace AdapterPatternTestProject
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {

            var mockAdapter = new Mock<IInsuranceProviderAdapter>();
            mockAdapter.Setup(a => a.GetInsurancePlan()).Returns(new InsurancePlan
            {
                PlanName = "Test Plan",
                Premium = 500,
                CoverageDetails = "Test Coverage"
            });

            var aggregator = new InsuranceAggregator(new List<IInsuranceProviderAdapter> { mockAdapter.Object });

            var plans = aggregator.GetAllPlans();

            Assert.Single(plans);
            Assert.Equal("Test Plan", plans[0].PlanName);

        }
    }
}