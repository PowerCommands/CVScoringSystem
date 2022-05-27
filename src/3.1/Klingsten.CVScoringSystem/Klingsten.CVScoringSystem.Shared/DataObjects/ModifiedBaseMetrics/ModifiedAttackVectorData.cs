using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedAttackVectorData
{
    public static Metric Get()
    {
        var metric = AttackVectorData.Get();
        metric.Name = "Modified Attack Vector";
        metric.Vector = "MAV";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}