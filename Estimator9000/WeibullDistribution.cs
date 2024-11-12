namespace Estimator9000
{
    public class WeibullDistribution
    {
        public static List<double?> GetCDF(double shapeK, double lambda, int count, int offSetDays = 0)
        {
            var res = new List<double?>();
            var sum = 0.0;

            for (int i = 0; i < offSetDays; i++)
            {
                res.Add(0);
            }

            for (int i = 0; i < count - offSetDays; i++)
            {
                var g = Sample(i, shapeK, lambda);

                if (g != null)
                {
                    sum = sum + (double)g;

                    if (sum > 1) sum = 1; // eliminate discrete ingtegral simulator issue


                    res.Add(sum);
                }
                else
                {
                    res.Add(0);
                }
            }

            return res;
        }

        private static double? Sample(int x, double shapeK, double lambda)
        {
            var p = (shapeK / lambda) *
                Math.Pow((x / lambda), (shapeK - 1)) *
                    Math.Exp(-1 * Math.Pow((x / lambda), shapeK));

            if (x < 0)
            {
                return 0;
            }

            return p;
        }
    }
}
