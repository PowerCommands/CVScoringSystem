using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public interface IScorecardService
{
    IEnumerable<Metric> GetMetrics();
}