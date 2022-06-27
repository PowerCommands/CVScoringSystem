using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Extensions;

public static class ScoreCardExtensions
{
    public static Metric Metric(this ScoreCard scoreCard, string vector) => scoreCard.Metrics.First(m => m.Vector == vector);
    public static MetricVariable GetMetricVariable(this Metric metric, string vector)
    {
        var metricString = vector.Split('/').First(v => v.StartsWith($"{metric.Vector}:"));
        var metricValue = metricString.Split(':')[1];
        var metricVariable = metric.Variables.First(v => v.Vector == metricValue);
        return metricVariable;
    }
}