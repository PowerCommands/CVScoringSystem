using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedIntegrityData
{
    public static Metric Get()
    {
        var metric = IntegrityData.Get();
        metric.Name = "Modified Integrity";
        metric.Vector = "MI";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}