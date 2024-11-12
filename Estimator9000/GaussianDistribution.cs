namespace Estimator9000
{
    public class GaussianDistribution
    {
        public static List<double?> GetCDF(double mean, double variance, int count, int offSetDays = 0)
        {
            var res = new List<double?>();
            var sum = 0.0;

            for (int i = 0; i < offSetDays; i++)
            {
                res.Add(0);
            }

            for (int i = 0; i < count - offSetDays; i++)
            {
                var g = SampleGaussian(i, mean, variance);

                if (g != null)
                {
                    sum = sum + (double)g;
                    res.Add(sum);
                }
                else
                {
                    res.Add(0);
                }
            }

            return res;
        }

        private static double? SampleGaussian(int x, double mean, double variance)
        {
            var sigma = Math.Sqrt(variance);
            var sqrttwopi = Math.Sqrt(2 * Math.PI * variance);

            var p = (1 / (sqrttwopi)) * Math.Exp(-1 * (Math.Pow((x - mean), 2) / (2 * variance)));

            // if (p < 0)
            // {
            //     return null;
            // }

            return p;
        }
    }
}
