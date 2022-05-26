using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects;

public class ConfidentialityData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "High", Vector = "H", Descricption = "There is a total loss of confidentiality, resulting in all resources within the impacted component being divulged to the attacker. Alternatively, access to only some restricted information is obtained, but the disclosed information presents a direct, serious impact. For example, an attacker steals the administrator's password, or private encryption keys of a web server." },
            new() {Name = "Low", Vector = "L", Descricption = "There is some loss of confidentiality. Access to some restricted information is obtained, but the attacker does not have control over what information is obtained, or the amount or kind of loss is limited. The information disclosure does not cause a direct, serious loss to the impacted component." },
            new() {Name = "None", Vector = "N", Descricption = "There is no loss of confidentiality within the impacted component." }
        };
        var metric = new Metric
        {
            Name = "Confidentiality",
            Vector = "C",
            Descricption = "This metric measures the impact to the confidentiality of the information resources managed by a software component due to a successfully exploited vulnerability. Confidentiality refers to limiting information access and disclosure to only authorized users, as well as preventing access by, or disclosure to, unauthorized ones. The Base Score is greatest when the loss to the impacted component is highest.",
            Guidance = "",
            Variables = variables
        };
        return metric;
    }
}