namespace ProbabilityTheoryTask.Models
{
    public class SimpleProbabilityCalculation
    {
        public double PermutationResult { get; set; }
        public double AccomodationResult { get; set; }
        public double CombinationResult { get; set; }

        public double PermutationInput { get; set; }
        public double AccomodationAllInput { get; set; }
        public double AccomodationChosenInput { get; set; }
        public double CombinationAllInput { get; set; }
        public double CombinationChosenInput { get; set; }
        public bool HasRepetitions { get; set; }
        public string PermutationExpression { get; set; }
        public void CalculateAll()
        {
            CalculatePermutations();
            CalculateAccomodation();
            CalculateCombination();
        }
        public void CalculatePermutations()
        {
            if (HasRepetitions)
            {
                if (string.IsNullOrWhiteSpace(PermutationExpression))
                {
                    PermutationResult=1;
                    return;
                }
                var arr = PermutationExpression.Split(',');
                var q = new Queue<double>();
                foreach (var item in arr)
                {
                    item.Trim();
                    if (double.TryParse(item, out var number))
                    {
                        q.Enqueue(number);
                    }
                    else
                    {
                        PermutationResult=0;
                        return;
                    }
                }

                var all = CalculateFactorial(PermutationInput);
                if (q.Sum()!=all)
                {
                    PermutationResult=0;
                    return;
                }
                var result = all;
                foreach (var item in q)
                {
                    result/=CalculateFactorial(item);
                }
                PermutationResult=result;
                return;
            }
            PermutationResult = CalculateFactorial(PermutationInput);
        }
        private int CalculateFactorial(double n, int start = 1)
        {

            int fact = 1;
            for (int i = start; i <= n; i++)
            {
                fact *= i;
            }

            return fact;
        }

        public void CalculateAccomodation()
        {
            var isInputsValid = (AccomodationAllInput>=AccomodationChosenInput)
                &&(AccomodationAllInput>=0)&&(AccomodationChosenInput>=0);
            if (!isInputsValid)
            {
                AccomodationResult=0;
                return;
            }
            if (HasRepetitions)
            {
                AccomodationResult = Math.Pow(AccomodationAllInput, AccomodationChosenInput);
                return;
            }
            var diff = AccomodationAllInput-AccomodationChosenInput;
            var nF = CalculateFactorial(AccomodationAllInput, (int)diff+1);
            AccomodationResult = nF;
        }

        public void CalculateCombination()
        {
            var isInputsValid = (CombinationAllInput>=CombinationChosenInput)
                &&(CombinationAllInput>=0)&&(CombinationChosenInput>=0);
            if (!isInputsValid)
            {
                CombinationResult=0;
                return;
            }
            if (HasRepetitions)
            {
                var all = CombinationAllInput+CombinationChosenInput-1;
                var diff = all-CombinationChosenInput;
                var chooseDiff = diff>CombinationChosenInput;
                var start = chooseDiff ? diff : CombinationChosenInput;
                if (chooseDiff)
                {
                    var nF2 = CalculateFactorial(all, (int)start+1);
                    var kF2 = CalculateFactorial(CombinationChosenInput);
                    if (kF2==0)
                    {
                        CombinationResult=1;
                        return;
                    }
                    CombinationResult = nF2 / kF2;
                    return;
                }
                else
                {
                    var nF1 = CalculateFactorial(all, (int)start+1);
                    var diffF1 = CalculateFactorial(all-CombinationChosenInput);
                    if (diffF1==0)
                    {
                        CombinationResult=1;
                        return;
                    }
                    CombinationResult = nF1 / diffF1;
                    return;
                }
            }
            var diff1 = CombinationAllInput-CombinationChosenInput;
            var chooseDiff1 = diff1>CombinationChosenInput;
            var start1 = chooseDiff1 ? diff1 : CombinationChosenInput;
            if (chooseDiff1)
            {
                var nF3 = CalculateFactorial(CombinationAllInput, (int)start1+1);
                var kF3 = CalculateFactorial(CombinationChosenInput);

                if (kF3==0)
                {
                    CombinationResult=1;
                    return;
                }
                CombinationResult = nF3 / kF3;
            }
            else
            {
                var nF = CalculateFactorial(CombinationAllInput, (int)start1+1);
                var diffF = CalculateFactorial(CombinationAllInput-CombinationChosenInput);
                if (diffF==0)
                {
                    CombinationResult=1;
                    return;
                }
                CombinationResult = nF / diffF;
            }
        }
    }
}
