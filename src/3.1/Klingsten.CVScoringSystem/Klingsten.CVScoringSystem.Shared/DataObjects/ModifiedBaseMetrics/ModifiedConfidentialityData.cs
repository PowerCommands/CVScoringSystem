using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedConfidentialityData
{
    public static Metric Get()
    {
        var metric = ConfidentialityData.Get();
        metric.Name = "Modified Confidentiality";
        metric.Vector = "MC";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Weight = 1, Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}