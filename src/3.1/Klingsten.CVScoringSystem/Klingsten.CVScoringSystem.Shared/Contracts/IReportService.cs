using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public interface IReportService
{
    Task<VulnerabilityReport> Get();
    Task<bool> Add(Vulnerability vulnerability);
    Task<bool> Remove(string name);
    Task Clear();
}