using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.EnvironmentalMetrics;

public class AvailabilityRequirementData
{
    public static Metric Get()
    {
        var metric = ConfidentialityRequirementData.Get();
        metric.Name = "Availability Requirement";
        metric.Vector = "AR";
        return metric;
    }
}