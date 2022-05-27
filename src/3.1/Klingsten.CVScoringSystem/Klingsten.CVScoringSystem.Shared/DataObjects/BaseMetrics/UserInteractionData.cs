using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;

public class UserInteractionData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "None", Vector = "N", Descricption = "The vulnerable system can be exploited without interaction from any user." },
            new() {Name = "Required", Vector = "R", Descricption = "Successful exploitation of this vulnerability requires a user to take some action before the vulnerability can be exploited. For example, a successful exploit may only be possible during the installation of an application by a system administrator." }
        };
        var metric = new Metric
        {
            Name = "User Interaction",
            Order = 3,
            Vector = "UI",
            Descricption = "This metric captures the requirement for a human user, other than the attacker, to participate in the successful compromise of the vulnerable component. This metric determines whether the vulnerability can be exploited solely at the will of the attacker, or whether a separate user (or user-initiated process) must participate in some manner. The Base Score is greatest when no user interaction is required. ",
            Guidance = "",
            Variables = variables
        };
        return metric;
    }
}