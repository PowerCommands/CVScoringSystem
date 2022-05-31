using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.Contracts;
public interface IPreferencesService
{
    Task Initialize();
    void Save(Preferences preferences);
    Task<Preferences> Get();
}