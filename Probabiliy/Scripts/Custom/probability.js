function ProbabilityCalculation(probA, probB)
{
    if ( validate(probA) )
    {
        this.ProbA = parseFloat(probA);
    }

    if (validate(probB))
    {
        this.ProbB = parseFloat(probB);
    }
    

    this.CombinedWith = function()
    {
        return this.ProbA * this.ProbB;

    };

    this.Either = function()
    {
        return (this.ProbA + this.ProbB) - (this.ProbA * this.ProbB)
    };
}


function validate(prob)
{

    if ( isNaN(parseFloat(prob)))
    {
        throw new Error("Probabilities must be numbers");
    }

    if (prob > 1)
    {
        throw new Error("Probabilities must be <= 1");
    }

    if (prob < 0)
    {
        throw new Error("Probabilities must be >= 0");
    }

    return true;



}


