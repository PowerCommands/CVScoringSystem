using Klingsten.CVScoringSystem.Shared.DomainObjects;
using Klingsten.CVScoringSystem.Shared.Enums;

namespace Klingsten.CVScoringSystem.Shared.Extensions;

public static class ScoreCardExtensions
{
    public static Metric Metric(this ScoreCard scoreCard, string vector) => scoreCard.Metrics.First(m => m.Vector == vector);
    public static MetricVariable GetMetricVariable(this Metric metric, string vector)
    {
        var metricString = vector.Split('/').First(v => v.StartsWith($"{metric.Vector}:"));
        var metricValue = metricString.Split(':')[1];
        if (string.IsNullOrEmpty(metricValue)) metricValue = "X";
        var metricVariable = metric.Variables.First(v => v.Vector == metricValue);
        return metricVariable;
    }
    public static double ReplaceIfUnmodified(this double metricVariableWeight, double baseWeight) => metricVariableWeight == 1 ? baseWeight : metricVariableWeight;

    public static SeverityRating ToSeverityRating(this double score)
    {
        if (score == 0) return SeverityRating.None;
        if (score > 0.1 && score < 3.91) return SeverityRating.Low;
        if (score > 4.0 && score < 6.91) return SeverityRating.Medium;
        if (score > 7.0 && score < 8.91) return SeverityRating.High;
        if (score > 8.99) return SeverityRating.Critical;

        return SeverityRating.None;
    }

    public static string ToSeverityRatingDisplayText(this double score)
    {
        if (score == 0) return $"{SeverityRating.None} {score}";
        if (score > 0.1 && score < 3.91) return $"{SeverityRating.Low} {score}";
        if (score > 4.0 && score < 6.91) return $"{SeverityRating.Medium} {score}";
        if (score > 7.0 && score < 8.91) return $"{SeverityRating.High} {score}";
        if (score > 8.99) return $"{SeverityRating.Critical} {score}";

        return $"{SeverityRating.None} {score}";
    }
}