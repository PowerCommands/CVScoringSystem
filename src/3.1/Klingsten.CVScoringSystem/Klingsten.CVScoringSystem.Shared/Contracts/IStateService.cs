using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public interface IStateService
{
    Preferences Preferences { get; set; }
    void PreferencesChanged(Preferences preferences);
    public double CurrentScore { get; set; }
}