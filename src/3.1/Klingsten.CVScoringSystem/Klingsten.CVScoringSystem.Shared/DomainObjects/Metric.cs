namespace Klingsten.CVScoringSystem.Shared.DomainObjects;
public class Metric
{
    public string Name { get; set; } = "";
    public string Descricption { get; set; } = "";
    public string Guidance { get; set; } = "";
    public string Value { get; set; } = "";
    public string Vector { get; set; } = "";
    public int Order { get; set; }
    public List<MetricVariable> Variables { get; set; } = new();
}