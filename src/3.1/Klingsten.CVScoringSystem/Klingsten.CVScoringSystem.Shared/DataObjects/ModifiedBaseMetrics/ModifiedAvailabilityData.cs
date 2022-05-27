using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedAvailabilityData
{
    public static Metric Get()
    {
        var metric = AvailabilityData.Get();
        metric.Name = "Modified Availability";
        metric.Vector = "MA";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}