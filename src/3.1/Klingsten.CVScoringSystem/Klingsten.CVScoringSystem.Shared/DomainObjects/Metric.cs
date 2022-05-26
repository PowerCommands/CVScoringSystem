using Klingsten.CVScoringSystem.Shared.Enums;

namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class Metric
{
    public string Name { get; set; } = "";
    public string Descricption { get; set; } = "";
    public double Value { get; set; } = 0.0;
    public string Vector { get; set; } = "";
    public List<MetricVariable> Variables { get; set; } = new();
}