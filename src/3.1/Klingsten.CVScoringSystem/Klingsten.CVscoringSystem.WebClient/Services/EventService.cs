namespace Klingsten.CVscoringSystem.WebClient.Services;

public class EventService : IEventService
{
    public event OnUserPreferencesChanged? UserPreferencesChanged;
    public void OnUserPreferencesChanged(Preferences preferences) => UserPreferencesChanged?.Invoke(preferences);
}