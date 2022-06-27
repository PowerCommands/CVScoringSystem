using Klingsten.CVScoringSystem.Shared.Extensions;

namespace Klingsten.CVScoringSystem.Shared.DomainObjects.Weights;
public class BaseWeight
{
    public BaseWeight(string vector, Metric metric)
    {
        var metricVariable = GetMetricVariable(vector, metric);
        Weight = metricVariable.Weight;
    }
    protected MetricVariable GetMetricVariable(string vector, Metric metric) => metric.GetMetricVariable(vector);
    public double Weight { get; set; }
}