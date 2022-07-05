using Klingsten.CVScoringSystem.Shared.DataObjects;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public interface IScorecardService
{
    IEnumerable<ScoreCard> GetScoreCards();
    Task<Vulnerabilities> GetCommonVulnerabilities();
}