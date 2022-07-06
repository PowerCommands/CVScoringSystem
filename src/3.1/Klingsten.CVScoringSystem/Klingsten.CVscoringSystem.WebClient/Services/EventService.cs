namespace Klingsten.CVscoringSystem.WebClient.Services;

public class EventService : IEventService
{
    public event OnUserPreferencesChanged? UserPreferencesChanged;
    public void OnUserPreferencesChanged(Preferences preferences) => UserPreferencesChanged?.Invoke(preferences);
    
    public event OnScoreCardCompleted? ScoreCardCompleted;
    public void OnScoreCardCompleted(ScoreCard card) => ScoreCardCompleted?.Invoke(card);
    
    public event OnVulnerabillityAddedToReport? VulnerabillityAddedToReport;
    public void OnVulnerabillityAddedToReport(Vulnerability vulnerability) => VulnerabillityAddedToReport?.Invoke(vulnerability);
}