using Klingsten.CVScoringSystem.Shared.DomainObjects;

namespace Klingsten.CVScoringSystem.Shared.DataObjects.EnvironmentalMetrics;

public class ConfidentialityRequirementData
{
    public static Metric Get()
    {
        var variables = new List<MetricVariable>
        {
            new() {Name = "Not defined", Vector = "X", Descricption = "Assigning this value indicates there is insufficient information to choose one of the other values, and has no impact on the overall Environmental Score, i.e., it has the same effect on scoring as assigning Medium." },
            new() {Name = "High", Vector = "H", Descricption = "Loss of [Confidentiality | Integrity | Availability] is likely to have a catastrophic adverse effect on the organization or individuals associated with the organization (e.g., employees, customers)." },
            new() {Name = "Medium", Vector = "M", Descricption = "Loss of [Confidentiality | Integrity | Availability] is likely to have a serious adverse effect on the organization or individuals associated with the organization (e.g., employees, customers)." },
            new() {Name = "Low", Vector = "L", Descricption = "Loss of [Confidentiality | Integrity | Availability] is likely to have only a limited adverse effect on the organization or individuals associated with the organization (e.g., employees, customers)." }
        };
        var metric = new Metric
        {
            Name = "Confidentiality Requirement",
            Order = 0,
            Vector = "CR",
            Descricption = "These metrics enable the analyst to customize the CVSS score depending on the importance of the affected IT asset to a user’s organization, measured in terms of Confidentiality, Integrity, and Availability. That is, if an IT asset supports a business function for which Availability is most important, the analyst can assign a greater value to Availability relative to Confidentiality and Integrity. Each Security Requirement has three possible values: Low, Medium, or High.<br/>The full effect on the environmental score is determined by the corresponding Modified Base Impact metrics.That is, these metrics modify the environmental score by reweighting the Modified Confidentiality,Integrity,and Availability impact metrics.For example,the Modified Confidentiality impact(MC) metric has increased weight if the Confidentiality Requirement(CR) is High.Likewise, the Modified Confidentiality impact metric has decreased weight if the Confidentiality Requirement is Low.The Modified Confidentiality impact metric weighting is neutral if the Confidentiality Requirement is Medium.This same process is applied to the Integrity and Availability requirements.",
            Guidance = "Note that the Confidentiality Requirement will not affect the Environmental score if the(Modified Base) confidentiality impact is set to None.Also, increasing the Confidentiality Requirement from Medium to High will not change the Environmental score when the(Modified Base) impact metrics are set to High. This is because the Modified Impact Sub - Score(part of the Modified Base Score that calculates impact) is already at a maximum value of 10.",
            Variables = variables
        };
        return metric;
    }
}