using Klingsten.CVScoringSystem.Shared.DomainObjects;
using Klingsten.CVScoringSystem.Shared.DomainObjects.Weights;
using Klingsten.CVScoringSystem.Shared.Enums;
using Klingsten.CVScoringSystem.Shared.Extensions;

namespace Klingsten.CVScoringSystem.Shared.Managers;

public class ScoreCalculatorManager
{
    const double ExploitabilityCoefficient = 8.22;
    const double ScopeCoefficient = 1.08;

    private readonly ScoreCard _baseScoreCard;
    private readonly ScoreCard _temporalScoreCard;
    private readonly ScoreCard _environmentalScoreCard;
    private readonly ScoreCard _modifiedScoreCard;

    public ScoreCalculatorManager(ScoreCard baseScoreCard, ScoreCard temporalScoreCard, ScoreCard environmentalScoreCard, ScoreCard modifiedScoreCard)
    {
        _baseScoreCard = baseScoreCard;
        _temporalScoreCard = temporalScoreCard;
        _environmentalScoreCard = environmentalScoreCard;
        _modifiedScoreCard = modifiedScoreCard;
    }
    public SeverityRating GetSeverityRating(double score)
    {
        if (score == 0) return SeverityRating.None;
        if (score > 0.1 && score < 3.9) return SeverityRating.Low;
        if (score > 4.0 && score < 6.9) return SeverityRating.Medium;
        if (score > 7.0 && score < 8.9) return SeverityRating.High;
        if (score > 9.0) return SeverityRating.Critical;
        
        return SeverityRating.None;
    }

    public ScoreResult GetScoreResult(string baseVector, string temporalVector, string environmentalVector, string modifiedVector)
    {
        var baseScore = GetBaseScore(baseVector);
        var retVal = new ScoreResult(baseScore, baseScore.BaseScore, GetSeverityRating(baseScore.BaseScore));
        return retVal;
    }

    private ScoreDetail GetBaseScore(string baseVector)
    {
        var av = new BaseWeight(baseVector, _baseScoreCard.Metric("AV")).Weight;
        var ac = new BaseWeight(baseVector, _baseScoreCard.Metric("AC")).Weight;
        var pr = new PrivilegesRequiredWeight(baseVector, _baseScoreCard.Metric("PR"), _baseScoreCard.Metric("S")).Weight;
        var ui = new BaseWeight(baseVector, _baseScoreCard.Metric("UI")).Weight;
        var s = new BaseWeight(baseVector, _baseScoreCard.Metric("S")).Weight;
        var c = new BaseWeight(baseVector, _baseScoreCard.Metric("C")).Weight;
        var i = new BaseWeight(baseVector, _baseScoreCard.Metric("I")).Weight;
        var a = new BaseWeight(baseVector, _baseScoreCard.Metric("A")).Weight;

        var scope = _baseScoreCard.Metric("S").GetMetricVariable(baseVector).Vector;

        var iss = (1 - ((1 - c) * (1 - i) * (1 - a)));
        var impact = scope == "U" ? s * iss : s * (iss - 0.029) - 3.25 * Math.Pow(iss - 0.02, 15);

        var exploitability = ExploitabilityCoefficient * av * ac * pr * ui;

        var baseScore = impact <= 0 ? 0 : RoundUp(scope == "U" ? Math.Min((exploitability + impact), 10) : Math.Min(ScopeCoefficient * (exploitability + impact), 10));
        var scoreDetail = new ScoreDetail { BaseScore = baseScore, Exploitability = exploitability, Impact = impact };
        return scoreDetail;
    }
    private double RoundUp(double input)
    {
        var intInput = Math.Round(input * 100000);
        if (intInput % 10000 == 0) return intInput / 100000;
        return (Math.Floor(intInput / 10000) + 1) / 10;
    }
}