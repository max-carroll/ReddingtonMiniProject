using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Probability.Models;
using System.IO;

namespace Probability
{
    public class CalculationLogger
    {

        private Calculation _calc;

        public CalculationLogger(Calculation calc)
        {
            this._calc = calc;
        }

        public void log()
        {

            //string projectPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
            string projectPath = System.AppDomain.CurrentDomain.BaseDirectory;
            

            System.IO.StreamWriter file = new System.IO.StreamWriter(projectPath + "\\Logs\\CalculationLog.txt", true);

            string logString = String.Format("{0} : P(A): {1}, P(B): {2}, {3}, Result: {4} ", _calc.TimeExecuted, _calc.ProbA, _calc.ProbB, _calc.CalculationType, _calc.Result);

            file.WriteLine(logString);

            file.Close();
        
        }
    }
}