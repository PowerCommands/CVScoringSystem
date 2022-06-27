namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class MetricVariable
{
    public string Name { get; set; } = "";
    public string Descricption { get; set; } = "";
    public double Weight { get; set; } = 0.0;
    public double AltWeight { get; set; } = 0.0;
    public string Vector { get; set; } = "";
}