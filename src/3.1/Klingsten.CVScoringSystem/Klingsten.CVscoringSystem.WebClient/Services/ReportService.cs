namespace Klingsten.CVscoringSystem.WebClient.Services;

public class ReportService : IReportService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly IStateService _stateService;
    private string _key = "cvss_report";

    public ReportService(ILocalStorageService localStorageService, IStateService stateService)
    {
        _localStorageService = localStorageService;
        _stateService = stateService;
    }
    public async Task<VulnerabilityReport> Get() => await _localStorageService.GetItemAsync<VulnerabilityReport>(_key) ?? new VulnerabilityReport();
    public async Task<bool> Add(Vulnerability vulnerability)
    {
        var report =  await _localStorageService.GetItemAsync<VulnerabilityReport>(_key) ?? new VulnerabilityReport{Description = $"Report created {DateTime.Now}"};
        report.Vulnerabilities.Add(vulnerability);
        await _localStorageService.RemoveItem(_key);
        await _localStorageService.SetItem(_key, report);
        return true;
    }
    public async Task<bool> Remove(string name)
    {
        var report = await _localStorageService.GetItemAsync<VulnerabilityReport>(_key) ?? new VulnerabilityReport();
        var existing = report.Vulnerabilities.FirstOrDefault(x => x.Name == name);
        if (existing == null) return false;
        report.Vulnerabilities.Remove(existing);
        await _localStorageService.RemoveItem(_key);
        await _localStorageService.SetItem(_key, report);
        return true;
    }
    public async Task Clear() => await _localStorageService.RemoveItem(_key);
}