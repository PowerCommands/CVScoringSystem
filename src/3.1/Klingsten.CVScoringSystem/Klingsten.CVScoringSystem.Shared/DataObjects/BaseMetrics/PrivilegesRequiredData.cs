using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.BaseMetrics;

public class PrivilegesRequiredData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "None", Weight = 0.85, AltWeight = 0.85, Vector = "N", Descricption = "The attacker is unauthorized prior to attack, and therefore does not require any access to settings or files of the vulnerable system to carry out an attack." },
            new() {Name = "Low", Weight = 0.62, AltWeight = 0.68, Vector = "L", Descricption = "The attacker requires privileges that provide basic user capabilities that could normally affect only settings and files owned by a user. Alternatively, an attacker with Low privileges has the ability to access only non-sensitive resources." },
            new() {Name = "High", Weight = 0.27, AltWeight = 0.5, Vector = "H", Descricption = "The attacker requires privileges that provide significant (e.g., administrative) control over the vulnerable component allowing access to component-wide settings and files." }
        };
        var metric = new Metric
        {
            Name = "Privileges Required",
            Order = 3,
            Vector = "PR",
            Descricption = "This metric describes the level of privileges an attacker must possess before successfully exploiting the vulnerability. The Base Score is greatest if no privileges are required.",
            Guidance = "Privileges Required is usually None for hard-coded credential vulnerabilities or vulnerabilities requiring social engineering (e.g., reflected cross-site scripting, cross-site request forgery, or file parsing vulnerability in a PDF reader).",
            Variables = variables
        };
        return metric;
    }
}