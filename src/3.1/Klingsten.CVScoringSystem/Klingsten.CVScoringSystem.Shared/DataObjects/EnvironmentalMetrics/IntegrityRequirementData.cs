using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.EnvironmentalMetrics;

public class IntegrityRequirementData
{
    public static Metric Get()
    {
        var metric = ConfidentialityRequirementData.Get();
        metric.Name = "Integrity Requirement";
        metric.Order = 1;
        metric.Vector = "IR";
        return metric;
    }
}