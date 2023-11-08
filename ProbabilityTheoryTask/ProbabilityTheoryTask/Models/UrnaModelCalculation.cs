using System.Numerics;

namespace ProbabilityTheoryTask.Models
{
    public class UrnaModelCalculation
    {
        public double AllObjects { get; set; }
        public double SelectedObjects { get; set; }
        public double AllObjectsMarked { get; set; }
        public double SelectedObjectsMarked { get; set; }
        public double Result { get; set; }
        public void Calculate()
        {
            var firstNumerator = CalculateCombination(AllObjectsMarked, SelectedObjectsMarked);
            var secondNumerator = CalculateCombination(AllObjects-AllObjectsMarked, SelectedObjects-SelectedObjectsMarked);
            var denominator = CalculateCombination(AllObjects, SelectedObjects);
            Result = (firstNumerator*secondNumerator)/denominator;
        }
        public double CalculateCombination(double all, double chosen)
        {
            var isInputsValid = (all>=chosen)
                &&(all>=0)&&(chosen>=0);
            if (!isInputsValid)
            {
                return 0;
            }

            var diff = all-chosen;
            var chooseDiff = diff>chosen;
            var start = chooseDiff ? diff : chosen;
            if (chooseDiff)
            {
                var nF1 = CalculateFactorial(all, (int)start+1);
                var kF1 = CalculateFactorial(chosen);
                if (kF1==0)
                {
                    return 1;
                }
                return nF1 / kF1;
            }
            else
            {
                var nF = CalculateFactorial(all, (int)start+1);
                var diffF = CalculateFactorial(all-chosen);
                if (diffF==0)
                {
                    return 1;
                }
                return nF /  diffF;
            }
        }

        private double CalculateFactorial(double n, int start = 1)
        {
            int fact = 1;
            for (int i = start; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }
    }
}
