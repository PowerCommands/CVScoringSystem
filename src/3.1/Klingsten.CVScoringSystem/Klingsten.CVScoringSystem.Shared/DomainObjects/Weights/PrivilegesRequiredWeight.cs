namespace Klingsten.CVScoringSystem.Shared.DomainObjects.Weights;

public class PrivilegesRequiredWeight : BaseWeight
{
    public PrivilegesRequiredWeight(string vector, Metric metric, Metric scopeMetric) : base(vector, metric)
    {
        var metricVariable = GetMetricVariable(vector, metric);
        var scopeMetricVariable = GetMetricVariable(vector, scopeMetric);
        Weight = scopeMetricVariable.Vector == "U" ? metricVariable.Weight : metricVariable.AltWeight;
    }
}