namespace Estimator9000
{
    public class Variable
    {
        public string? Name { get; set; }
        public double Mean { get; set; }
        public double variance { get; set; }
        public double shift { get; set; }
        public DateTime startDate { get; set; }

        public Variable DependsOn { get; set; }

        public static Variable Parse(string value, Variable dependsOn)
        {
            var components = value.Split('-').Select(c => c.Trim()).ToArray();
            var variance = double.Parse(components[2]);

            if (variance == 0)
            {
                variance = 0.5;
            }

            var startDate = DateTime.Today;
            if (components.Length == 5 && DateTime.TryParse(components[4].Trim(['(', ')']), out startDate)) { }

            return new Variable
            {
                Name = components[0],
                Mean = double.Parse(components[1]),
                variance = variance,
                shift = double.Parse(components[3]),
                DependsOn = dependsOn,
                startDate = startDate
            };
        }
    }
}
