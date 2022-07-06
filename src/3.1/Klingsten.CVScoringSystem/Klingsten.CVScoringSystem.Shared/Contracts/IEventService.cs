using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public delegate void OnUserPreferencesChanged(Preferences preferences);
public delegate void OnScoreCardCompleted(ScoreCard card);
public delegate void OnVulnerabillityAddedToReport(Vulnerability vulnerability);
public interface IEventService
{
    event OnUserPreferencesChanged UserPreferencesChanged;
    void OnUserPreferencesChanged(Preferences preferences);

    event OnScoreCardCompleted ScoreCardCompleted;
    void OnScoreCardCompleted(ScoreCard card);

    event OnVulnerabillityAddedToReport VulnerabillityAddedToReport;
    void OnVulnerabillityAddedToReport(Vulnerability vulnerability);
}