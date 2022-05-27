using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedUserInteractionData
{
    public static Metric Get()
    {
        var metric = UserInteractionData.Get();
        metric.Name = "Modified User Interaction";
        metric.Vector = "MUI";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}