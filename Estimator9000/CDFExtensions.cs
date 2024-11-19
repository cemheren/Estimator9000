namespace Estimator9000
{
    public static class CDFExtensions
    {
        public static List<double?> MultiplyAndAssign(this List<double?> a, List<double?> b)
        {
            var res = new List<double?>(capacity: a.Count);
            for (int i = 0; i < a.Count; i++)
            {
                res.Add(a[i] * b[i]);
            }

            return res;
        }

        public static List<double?> MaxOf(this List<double?> a, List<double?> b)
        {
            var res = new List<double?>(capacity: a.Count);
            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] == null)
                {
                    res.Add(b[i]);
                }
                else if (b[i] == null)
                {
                    res.Add(a[i]);
                }
                else 
                { 
                    res.Add(Math.Max((double)a[i]!, (double)b[i]!));
                }
            }

            return res;
        }

        public static List<double?> MonteCarloCombine(this List<double?> limitProbabilityCdf, List<double?> originalCdf)
        {
            var res = new double?[limitProbabilityCdf.Count].ToList();
            for (int i = 0; i < limitProbabilityCdf.Count; i++)
            {
                var scaleFactor = limitProbabilityCdf[i] ?? 0;
                // each day's limit probability determines the upper limit on the cdf funciton for the monte carlo simulation 
                var shifted = originalCdf.Shift(i, scaleFactor);

                res = MaxOf(res, shifted);
            }

            return res;
        }

        public static List<double?> Shift(this List<double?> a, int offset, double scale = 1.0)
        {
            var res = new List<double?>(capacity: a.Count);

            for (int i = 0; i < offset; i++)
            {
                res.Add(0);
            }

            for (int i = 0; i < a.Count - offset; i++)
            {
                res.Add(a[i] * scale);
            }

            return res;
        }
    }
}
