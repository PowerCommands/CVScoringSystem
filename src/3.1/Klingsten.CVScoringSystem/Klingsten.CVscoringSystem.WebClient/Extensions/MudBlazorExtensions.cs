using MudBlazor;

namespace Klingsten.CVscoringSystem.WebClient.Extensions;

public static class MudBlazorExtensions
{
    public static Color ToMudBlazorColor(this SeverityRating severityRating)
    {
        switch (severityRating)
        {
            case SeverityRating.None:
                return Color.Success;
            case SeverityRating.Low:
                return Color.Info;
            case SeverityRating.Medium:
                return Color.Warning;
            case SeverityRating.High:
                return Color.Secondary;
            case SeverityRating.Critical:
                return Color.Error;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}