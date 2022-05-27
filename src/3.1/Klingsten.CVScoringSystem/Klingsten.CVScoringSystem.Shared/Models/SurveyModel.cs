namespace Klingsten.CVScoringSystem.Shared.Models;
public class SurveyModel
{
    public int BaseMetricCompletedCount { get; set; }
    public bool BaseMetricCompleted { get; set; } = true;
    public int TemporalMetricCompletedCount { get; set; }
    public bool TemporalMetricCompleted { get; set; }
    public int EnvironmentMetricCompletedCount { get; set; }
    public bool EnvironmentMetricCompleted { get; set; }
    public bool Completed { get; set; }
}