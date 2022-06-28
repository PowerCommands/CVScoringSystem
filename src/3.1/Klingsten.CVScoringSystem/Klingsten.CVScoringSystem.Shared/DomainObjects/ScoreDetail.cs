namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class ScoreDetail
{
    public double Impact { get; set; }
    public double ModifiedImpact { get; set; }
    public double Exploitability { get; set; }
    public double ModifiedExploitability { get; set; }
    public double BaseScore { get; set; }
    public double TempuralScore { get; set; }
    public double EnvironmentScore { get; set; }
}