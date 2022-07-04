using MudBlazor;

namespace Klingsten.CVscoringSystem.WebClient.Shared;

public class AlertTemplate
{
    public Severity Severity { get; set; }
    public bool Show { get; set; }
    public string Message { get; set; } = "";
    public bool HasError { get; set; }
}