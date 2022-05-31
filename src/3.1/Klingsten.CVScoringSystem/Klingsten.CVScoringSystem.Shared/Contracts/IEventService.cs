using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;

public delegate void OnUserPreferencesChanged(Preferences preferences);
public interface IEventService
{
    event OnUserPreferencesChanged UserPreferencesChanged;
    void OnUserPreferencesChanged(Preferences preferences);
}