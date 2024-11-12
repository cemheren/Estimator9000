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

        public static List<double?> Shift(this List<double?> a, int offset)
        {
            var res = new List<double?>(capacity: a.Count);

            for (int i = 0; i < offset; i++)
            {
                res.Add(0);
            }

            for (int i = 0; i < a.Count - offset; i++)
            {
                res.Add(a[i]);
            }

            return res;
        }
    }
}
