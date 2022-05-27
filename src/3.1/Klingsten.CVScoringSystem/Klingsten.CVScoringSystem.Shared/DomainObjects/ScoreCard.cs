using Klingsten.CVScoringSystem.Shared.Enums;

namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class ScoreCard
{
    public string Name { get; set; } = "";
    public ScoreMetricType MetricType { get; set; }
    public List<Metric> Metrics { get; set; } = new();
    public double Score { get; set; }
    public string VectorString { get; set; } = "";
}