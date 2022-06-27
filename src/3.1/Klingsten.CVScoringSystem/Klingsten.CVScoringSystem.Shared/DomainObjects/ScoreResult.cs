using Klingsten.CVScoringSystem.Shared.Enums;

namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class ScoreResult
{
    public ScoreResult(ScoreDetail scoreDetail, double totalScore, SeverityRating severityRating)
    {
        ScoreDetail = scoreDetail;
        TotalScore = totalScore;
        SeverityRating = severityRating;
    }
    public ScoreDetail ScoreDetail { get; set; }
    public double TotalScore { get; set; }
    public SeverityRating SeverityRating { get; set; }
}