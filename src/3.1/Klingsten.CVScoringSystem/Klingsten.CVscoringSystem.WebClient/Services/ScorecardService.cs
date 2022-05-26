using Klingsten.CVScoringSystem.Shared.DataObjects;

namespace Klingsten.CVscoringSystem.WebClient.Services;
public class ScorecardService : IScorecardService
{
    public IEnumerable<Metric> GetMetrics()
    {
        var retVal = new List<Metric>
        {
            AttackVectorData.Get(),
            AttackComplexityData.Get(),
            PrivilegesRequiredData.Get(),
            UserInteractionData.Get(),
            ScopeData.Get(),
            ConfidentialityData.Get(),
            IntegrityData.Get(),
            AvailabilityData.Get()
        };
        return retVal;
    }
}