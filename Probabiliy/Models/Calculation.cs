using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Probability.Models
{

    public class Calculation
    {
        public DateTime TimeExecuted { get; set; }
        public string ProbA { get; set; }
        public string ProbB { get; set; }
        public CalculationType CalculationType { get; set; }
        public string Result { get; set; }

        public Calculation(string probA, string probB, string result, string calculationType)
        {

            if (ConstructorParametersValidate(probA, probB, result, calculationType))
            {

                this.ProbA = probA;
                this.ProbB = probB;
                this.Result = result;

                if (calculationType == "Combined")
                {
                    this.CalculationType = CalculationType.Combined;
                }
                else if (calculationType == "Either")
                {
                    this.CalculationType = CalculationType.Either;
                }

                this.TimeExecuted = DateTime.Now;

            }
            
        }

        private bool ConstructorParametersValidate(string probA, string probB, string result, string calculationType)
        {
            ValidateProbability(probA, "probA");
            ValidateProbability(probB, "probB");
            ValidateProbability(result, "result");

            if (calculationType == null)
            {
                throw new ArgumentNullException("calculationType");
            }

            if (calculationType != "Combined" && calculationType != "Either")
            {
                throw new ArgumentException("Not a valid calculationType");
            }

            return true;
        }

        private void ValidateProbability(string prob, string name)
        {
            if (prob == null)
            {
                throw new ArgumentNullException(name);
            }

            float probToFloat;

            if (!float.TryParse(prob, out probToFloat))
            {
                throw new ArgumentException(String.Format("{0} must be numeric", name));
            }

            if (probToFloat > 1)
            {
                throw new ArgumentException(String.Format("{0} must be less than one",name));
            }

            if (probToFloat < 0)
            {
                throw new ArgumentException(String.Format("{0} must be greater than zero",name));
            }
        }

    }
}