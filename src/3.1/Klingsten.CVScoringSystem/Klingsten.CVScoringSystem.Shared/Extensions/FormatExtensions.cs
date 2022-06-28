using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Extensions;

public static class FormatExtensions
{
    public static string ToVectoryStringValue(this Metric metric) => $"{metric.Vector}:{metric.Value.ToValueOrDefault()}";
    private static string ToValueOrDefault(this string metricValue) => string.IsNullOrEmpty(metricValue) ? "X" : metricValue;
}