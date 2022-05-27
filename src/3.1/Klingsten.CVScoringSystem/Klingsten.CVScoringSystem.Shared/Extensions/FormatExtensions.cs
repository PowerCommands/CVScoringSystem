using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Extensions;

public static class FormatExtensions
{
    public static string ToVectoryStringValue(this Metric metric) => $"{metric.Vector}:{metric.Value}";
}