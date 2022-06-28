using Klingsten.CVScoringSystem.Shared.Enums;

namespace Klingsten.CVScoringSystem.Shared.DomainObjects;

public class ScoreResult
{
    public ScoreResult(ScoreDetail scoreDetail, SeverityRating baseSeverityRating, SeverityRating temporalSeverityRating, SeverityRating enviromentalSeverityRating)
    {
        ScoreDetail = scoreDetail;
        BaseSeverityRating = baseSeverityRating;
        TemporalSeverityRating = temporalSeverityRating;
        EnviromentalSeverityRating = enviromentalSeverityRating;
    }
    public ScoreDetail ScoreDetail { get; set; }
    public SeverityRating BaseSeverityRating { get; set; }
    public SeverityRating TemporalSeverityRating { get; set; }
    public SeverityRating EnviromentalSeverityRating { get; set; }
}