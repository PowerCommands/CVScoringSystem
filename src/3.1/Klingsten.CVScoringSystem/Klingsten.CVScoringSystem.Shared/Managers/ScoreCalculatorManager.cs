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

    public ScoreCalculatorManager(List<ScoreCard> scoreCards)
    {
        _baseScoreCard = scoreCards.First(s => s.MetricType == ScoreMetricType.Base);
        _temporalScoreCard = scoreCards.First(s => s.MetricType == ScoreMetricType.Temporal);
        _environmentalScoreCard = scoreCards.First(s => s.MetricType == ScoreMetricType.Environmental);
        _modifiedScoreCard = scoreCards.First(s => s.MetricType == ScoreMetricType.Modified);
    }

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

    public ScoreResult GetScoreResult(string baseVector)
    {
        var scoreDetail = GetScoreDetails(baseVector);
        var retVal = new ScoreResult(scoreDetail, GetSeverityRating(scoreDetail.BaseScore), GetSeverityRating(scoreDetail.TemporalScore), GetSeverityRating(scoreDetail.EnvironmentScore));
        return retVal;
    }

    private ScoreDetail GetScoreDetails(string vector)
    {
        var av = new BaseWeight(vector, _baseScoreCard.Metric("AV")).Weight;
        var ac = new BaseWeight(vector, _baseScoreCard.Metric("AC")).Weight;
        var pr = new PrivilegesRequiredWeight(vector, _baseScoreCard.Metric("PR"), _baseScoreCard.Metric("S")).Weight;
        var ui = new BaseWeight(vector, _baseScoreCard.Metric("UI")).Weight;
        var s = new BaseWeight(vector, _baseScoreCard.Metric("S")).Weight;
        var c = new BaseWeight(vector, _baseScoreCard.Metric("C")).Weight;
        var i = new BaseWeight(vector, _baseScoreCard.Metric("I")).Weight;
        var a = new BaseWeight(vector, _baseScoreCard.Metric("A")).Weight;

        var scope = _baseScoreCard.Metric("S").GetMetricVariable(vector).Vector;

        var iss = (1 - ((1 - c) * (1 - i) * (1 - a)));
        var impact = scope == "U" ? s * iss : s * (iss - 0.029) - 3.25 * Math.Pow(iss - 0.02, 15);

        var exploitability = ExploitabilityCoefficient * av * ac * pr * ui;

        var baseScore = impact <= 0 ? 0 : RoundUp(scope == "U" ? Math.Min((exploitability + impact), 10) : Math.Min(ScopeCoefficient * (exploitability + impact), 10));
        var temporalScore = GetTemporalScore(vector, baseScore);
        var environmentalScore = GetEnvironmentScore(vector);

        var scoreDetail = new ScoreDetail {BaseScore = baseScore, Exploitability = exploitability, Impact = impact, TemporalScore = temporalScore, EnvironmentScore = environmentalScore.Score, ModifiedExploitability = environmentalScore.Exploitability, ModifiedImpact = environmentalScore.Impact};
        return scoreDetail;
    }

    private double GetTemporalScore(string vector, double baseScore)
    {
        var e = new BaseWeight(vector, _temporalScoreCard.Metric("E")).Weight;
        var rl = new BaseWeight(vector, _temporalScoreCard.Metric("RL")).Weight;
        var rc = new BaseWeight(vector, _temporalScoreCard.Metric("RC")).Weight;

        var score = RoundUp(baseScore * e * rl * rc);
        return score;
    }

    private EnvironmentalScore GetEnvironmentScore(string vector)
    {
        var e = new BaseWeight(vector, _temporalScoreCard.Metric("E")).Weight;
        var rl = new BaseWeight(vector, _temporalScoreCard.Metric("RL")).Weight;
        var rc = new BaseWeight(vector, _temporalScoreCard.Metric("RC")).Weight;

        var cr = new BaseWeight(vector, _environmentalScoreCard.Metric("CR")).Weight;
        var ir = new BaseWeight(vector, _environmentalScoreCard.Metric("IR")).Weight;
        var ar = new BaseWeight(vector, _environmentalScoreCard.Metric("AR")).Weight;

        var av = new BaseWeight(vector, _baseScoreCard.Metric("AV")).Weight;
        var ac = new BaseWeight(vector, _baseScoreCard.Metric("AC")).Weight;
        var pr = new PrivilegesRequiredWeight(vector, _baseScoreCard.Metric("PR"), _baseScoreCard.Metric("S")).Weight;
        var ui = new BaseWeight(vector, _baseScoreCard.Metric("UI")).Weight;
        var s = new BaseWeight(vector, _baseScoreCard.Metric("S")).Weight;
        var c = new BaseWeight(vector, _baseScoreCard.Metric("C")).Weight;
        var i = new BaseWeight(vector, _baseScoreCard.Metric("I")).Weight;
        var a = new BaseWeight(vector, _baseScoreCard.Metric("A")).Weight;

        var mav = new BaseWeight(vector, _modifiedScoreCard.Metric("MAV")).Weight.ReplaceIfUnmodified(av);
        var mac = new BaseWeight(vector, _modifiedScoreCard.Metric("MAC")).Weight.ReplaceIfUnmodified(ac);
        var mpr = new PrivilegesRequiredWeight(vector, _modifiedScoreCard.Metric("MPR"), _modifiedScoreCard.Metric("MS")).Weight.ReplaceIfUnmodified(pr);
        var mui = new BaseWeight(vector, _modifiedScoreCard.Metric("MUI")).Weight.ReplaceIfUnmodified(ui);
        var ms = new BaseWeight(vector, _modifiedScoreCard.Metric("MS")).Weight.ReplaceIfUnmodified(s);
        var mc = new BaseWeight(vector, _modifiedScoreCard.Metric("MC")).Weight.ReplaceIfUnmodified(c);
        var mi = new BaseWeight(vector, _modifiedScoreCard.Metric("MI")).Weight.ReplaceIfUnmodified(i);
        var ma = new BaseWeight(vector, _modifiedScoreCard.Metric("MA")).Weight.ReplaceIfUnmodified(a);

        double envScore;

        var scope = _baseScoreCard.Metric("S").GetMetricVariable(vector).Vector;
        var mScope = _modifiedScoreCard.Metric("MS").GetMetricVariable(vector).Vector;

        var miss = Math.Min(1 - ((1 - mc * cr) * (1 - mi * ir) * (1 - ma * ar)), 0.915);

        var modifiedImpact = mScope == "U" || (mScope == "X" && scope == "U") ? ms * miss : ms * (miss - 0.029) - 3.25 * Math.Pow(miss * 0.9731 - 0.02, 13);
        var modifiedExploitability = ExploitabilityCoefficient * mav * mac * mpr * mui;

        if (modifiedImpact <= 0)
        {
            envScore = 0;
        }
        else if (mScope == "U" || (mScope == "X" && scope == "U"))
        {
            envScore = RoundUp(RoundUp(Math.Min((modifiedImpact + modifiedExploitability), 10)) * e * rl * rc);
        }
        else
        {
            envScore = RoundUp(RoundUp(Math.Min(ScopeCoefficient * (modifiedImpact + modifiedExploitability), 10)) * e * rl * rc);
        }

        var scoreDetail = new EnvironmentalScore {Score = envScore, Exploitability = modifiedExploitability, Impact = modifiedImpact};
        return scoreDetail;
    }
    private double RoundUp(double input)
    {
        var intInput = Math.Round(input * 100000);
        if (intInput % 10000 == 0) return intInput / 100000;
        return (Math.Floor(intInput / 10000) + 1) / 10;
    }
}