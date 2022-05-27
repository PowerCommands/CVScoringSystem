using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.TemporalMetrics;

public class RemediationLevelData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "Not defined", Vector = "X", Descricption = "Assigning this value indicates there is insufficient information to choose one of the other values, and has no impact on the overall Temporal Score, i.e., it has the same effect on scoring as assigning Unavailable." },
            new() {Name = "Unavailable", Vector = "U", Descricption = "There is either no solution available or it is impossible to apply." },
            new() {Name = "Workaround", Vector = "W", Descricption = "There is an unofficial, non-vendor solution available. In some cases, users of the affected technology will create a patch of their own or provide steps to work around or otherwise mitigate the vulnerability." },
            new() {Name = "Temporary Fix", Vector = "T", Descricption = "There is an official but temporary fix available. This includes instances where the vendor issues a temporary hotfix, tool, or workaround." },
            new() {Name = "Official Fix ", Vector = "O", Descricption = "A complete vendor solution is available. Either the vendor has issued an official patch, or an upgrade is available." }
        };
        var metric = new Metric
        {
            Name = "Remediation Level",
            Order = 1,
            Vector = "RL",
            Descricption = "The Remediation Level of a vulnerability is an important factor for prioritization. The typical vulnerability is unpatched when initially published. Workarounds or hotfixes may offer interim remediation until an official patch or upgrade is issued. Each of these respective stages adjusts the Temporal Score downwards, reflecting the decreasing urgency as remediation becomes final. The less official and permanent a fix, the higher the vulnerability score.",
            Guidance = "",
            Variables = variables
        };
        return metric;
    }
}