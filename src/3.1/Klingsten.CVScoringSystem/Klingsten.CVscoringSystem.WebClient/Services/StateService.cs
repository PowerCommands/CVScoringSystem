namespace Klingsten.CVscoringSystem.WebClient.Services;
public class StateService : IStateService
{
    private readonly IEventService _eventService;
    public StateService(IEventService eventService) => _eventService = eventService;
    public Preferences Preferences { get; set; } = new();
    public double CurrentScore { get; set; }
    public void PreferencesChanged(Preferences preferences)
    {
        Preferences = preferences;
        _eventService.OnUserPreferencesChanged(preferences);
    }
}