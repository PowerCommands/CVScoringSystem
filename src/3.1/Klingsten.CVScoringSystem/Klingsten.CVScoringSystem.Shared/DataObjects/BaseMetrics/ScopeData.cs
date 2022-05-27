using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;

public class ScopeData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "Unchanged", Vector = "U", Descricption = "An exploited vulnerability can only affect resources managed by the same security authority. In this case, the vulnerable component and the impacted component are either the same, or both are managed by the same security authority." },
            new() {Name = "Changed", Vector = "C", Descricption = "An exploited vulnerability can affect resources beyond the security scope managed by the security authority of the vulnerable component. In this case, the vulnerable component and the impacted component are different and managed by different security authorities." }
        };
        var metric = new Metric
        {
            Name = "Scope",
            Order = 4,
            Vector = "S",
            Descricption = "The Scope metric captures whether a vulnerability in one vulnerable component impacts resources in components beyond its security scope.<br/>Formally,a security authority is a mechanism (e.g., an application, an operating system,firmware,a sandbox environment) that defines and enforces access control in terms of how certain subjects / actors(e.g., human users, processes) can access certain restricted objects / resources(e.g., files, CPU, memory) in a controlled manner.All the subjects and objects under the jurisdiction of a single security authority are considered to be under one security scope.If a vulnerability in a vulnerable component can affect a component which is in a different security scope than the vulnerable component, a Scope change occurs.Intuitively, whenever the impact of a vulnerability breaches a security / trust boundary and impacts components outside the security scope in which vulnerable component resides, a Scope change occurs.<br/>The security scope of a component encompasses other components that provide functionality solely to that component, even if these other components have their own security authority.For example, a database used solely by one application is considered part of that application’s security scope even if the database has its own security authority, e.g., a mechanism controlling access to database records based on database users and associated database privileges.<br/>The Base Score is greatest when a scope change occurs.",
            Guidance = "",
            Variables = variables
        };
        return metric;
    }
}