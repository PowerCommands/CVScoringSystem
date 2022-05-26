using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects;

public class IntegrityData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "High", Vector = "H", Descricption = "There is a total loss of integrity, or a complete loss of protection. For example, the attacker is able to modify any/all files protected by the impacted component. Alternatively, only some files can be modified, but malicious modification would present a direct, serious consequence to the impacted component." },
            new() {Name = "Low", Vector = "L", Descricption = "Modification of data is possible, but the attacker does not have control over the consequence of a modification, or the amount of modification is limited. The data modification does not have a direct, serious impact on the impacted component." },
            new() {Name = "None", Vector = "N", Descricption = "There is no loss of integrity within the impacted component." }
        };
        var metric = new Metric
        {
            Name = "Integrity",
            Vector = "I",
            Descricption = "This metric measures the impact to integrity of a successfully exploited vulnerability. Integrity refers to the trustworthiness and veracity of information. The Base Score is greatest when the consequence to the impacted component is highest.",
            Guidance = "",
            Variables = variables
        };
        return metric;
    }
}