using Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;
using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.ModifiedBaseMetrics;

public class ModifiedAttackComplexityData
{
    public static Metric Get()
    {
        var metric = AttackVectorData.Get();
        metric.Name = "Modified Attack Complexity";
        metric.Vector = "MAC";
        metric.Descricption = GetDescription();
        metric.Variables.Insert(0, new MetricVariable { Name = "Not defined", Vector = "X", Descricption = "The value assigned to the corresponding base metric is used." });
        return metric;
    }

    internal static string GetDescription()
    {
        return "These metrics enable the analyst to override individual Base metrics based on specific characteristics of a user’s environment. Characteristics that affect Exploitability, Scope, or Impact can be reflected via an appropriately modified Environmental Score.<br/>The full effect on the Environmental score is determined by the corresponding Base metrics. That is, these metrics modify the Environmental Score by overriding Base metric values, prior to applying the Environmental Security Requirements.For example, the default configuration for a vulnerable component may be to run a listening service with administrator privileges, for which a compromise might grant an attacker Confidentiality, Integrity, and Availability impacts that are all High.Yet, in the analyst’s environment, that same Internet service might be running with reduced privileges; in that case, the Modified Confidentiality, Modified Integrity, and Modified Availability might each be set to Low.<br/>For brevity, only the names of the Modified Base metrics are mentioned.Each Modified Environmental metric has the same values as its corresponding Base metric, plus a value of Not Defined. Not Defined is the default and uses the metric value of the associated Base metric.<br/>The intent of this metric is to define the mitigations in place for a given environment.It is acceptable to use the modified metrics to represent situations that increase the Base Score.For example, the default configuration of a component may require high privileges to access a particular function, but in the analyst’s environment there may be no privileges required.The analyst can set Privileges Required to High and Modified Privileges Required to None to reflect this more serious condition in their particular environment.";
    }
}