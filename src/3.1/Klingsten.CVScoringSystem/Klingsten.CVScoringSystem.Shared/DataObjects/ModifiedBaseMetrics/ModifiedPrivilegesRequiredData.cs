using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedPrivilegesRequiredData
{
    public static Metric Get()
    {
        var metric = PrivilegesRequiredData.Get();
        metric.Name = "Modified Privileges Required";
        metric.Vector = "MPR";
        metric.Descricption = ModifiedAttackComplexityData.GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Weight = 1, AltWeight = 1, Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }
}