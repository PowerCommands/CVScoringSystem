namespace Klingsten.CVscoringSystem.WebClient.Services;

public class PreferencesService : IPreferencesService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IStateService _stateService;
    private readonly string _key = "preferences";
    public PreferencesService(ILocalStorageService localStorageService, IStateService stateService)
    {
        _localStorageService = localStorageService;
        _stateService = stateService;
    }
    public async Task Initialize() => _stateService.Preferences = await Get();
    public async void Save(Preferences preferences)
    {
        _stateService.Preferences.IsDarkMode = preferences.IsDarkMode;
        _stateService.Preferences.ShowMetricDecription = preferences.ShowMetricDecription;
        await _localStorageService.SetItem(_key, _stateService.Preferences);
    }
    public async Task<Preferences> Get() => await _localStorageService.GetItemAsync<Preferences>(_key) ?? new Preferences();
}