using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DataObjects.EnvironmentalMetrics;
using Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;
using Klingsten.CVScoringSystem.Shared.DataObjects.TemporalMetrics;

namespace Klingsten.CVscoringSystem.WebClient.Services;
public class ScorecardService : IScorecardService
{
    public IEnumerable<ScoreCard> GetScoreCards()
    {
        var retVal = new List<ScoreCard>();
        
        var baseMetrics = new List<Metric>
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

        retVal.Add(new ScoreCard {MetricType = ScoreMetricType.Base, Metrics = baseMetrics, Name = "Base metrics"});

        var temporalMetrics = new List<Metric>
        {
            ExploitCodeMaturityData.Get(),
            RemediationLevelData.Get(),
            ReportConfidenceData.Get()
        };
        retVal.Add(new ScoreCard { MetricType = ScoreMetricType.Temporal, Metrics = temporalMetrics, Name = "Temporal metrics" });

        var environmentalMetrics = new List<Metric>
        {
            ConfidentialityRequirementData.Get(),
            IntegrityRequirementData.Get(),
            AvailabilityRequirementData.Get()
        };
        retVal.Add(new ScoreCard { MetricType = ScoreMetricType.Environmental, Metrics = environmentalMetrics, Name = "Environmental metrics" });

        var modifiedBaseMetrics = new List<Metric>
        {
            ModifiedAttackVectorData.Get(),
            ModifiedAttackComplexityData.Get(),
            ModifiedPrivilegesRequiredData.Get(),
            ModifiedUserInteractionData.Get(),
            ModifiedScopeData.Get(),
            ModifiedConfidentialityData.Get(),
            ModifiedIntegrityData.Get(),
            ModifiedAvailabilityData.Get()
        };
        retVal.Add(new ScoreCard { MetricType = ScoreMetricType.Modified, Metrics = modifiedBaseMetrics, Name = "Modified base metrics" });

        return retVal;
    }
}