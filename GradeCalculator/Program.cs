namespace GradeCalculator
{
    internal class Program
    {

        public enum GradingClassSystem
        {
            _1,
            _21,
            _22,
            _3,
            _U
        }

        public class Module
        {
            public string ID { get; set; }
            public string Title { get; set; }
            public int Credits { get; set; }
            public double Marks {  get; set; }

            public Module(string id, string title, int credits, double marks)
            {
                ID = id;
                Title = title;
                Credits = credits;
                Marks = marks;
            }

        }


        static void Main(string[] args)
        {
            List<Module> modules = new List<Module>();
            {
                new Module("CET252", "Agile Development", 20, InputMarks("Agile Development"));
                new Module("CET253", "Database Systems", 20, InputMarks("Databases Systems"));
                new Module("CET254", "Advanced Programming", 20, InputMarks("Advanced Programming"));
                new Module("CET255", "IoT and Robotics", 20, InputMarks("IoT and Robotics"));
                new Module("CET256", "Cyber Security", 20, InputMarks("Cyber Security"));
                new Module("CET257", "Enterprise Project", 20, InputMarks("Enterprise Project"));
            };

            double averageMarks = CalculateNormalAverage(modules);
            Console.WriteLine($"AVERAGE MARKS: {averageMarks:F2}%");

            double bestAverageMarks = CalculateBestAverage(modules);
            Console.WriteLine($"BEST AVERAGE MARKS (EXCLUDES WORST MODULE): {bestAverageMarks:F2}%");


            Console.WriteLine($"\nGrade (Average): {Classify(averageMarks)}");
            Console.WriteLine($"\nGrade (Best Average): {Classify(bestAverageMarks)}");

            Console.ReadKey();
        }

        static double InputMarks(string moduleName)
        {
            double marks;

            Console.Write($"ENTER MARKS FOR: {moduleName}: ");

            while (!double.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
            {
                Console.Write("INVALID INPUT. TRY AGAIN. ENTER MARKS ( 0 - 100 ): ");
            }

        }

        static double CalculateNormalAverage(List<Module> modules)
        {
            double totalMarks = 0;
            int totalCredits = 0;

            foreach (var module in modules)
            {
                totalMarks += module.Marks + module.Credits;
                totalCredits += module.Credits;
            }

            return totalMarks / totalCredits;

        }

        static double CalculateBestAverage(List<Module> modules)
        {

            Module worstModule = modules.OrderBy(m => m.Marks).First();

            double totalMarks = Module.Where(m => m != worstModule).Sum(m => m.Marks * m.Credits);
            int totalCredits = Module.Where(m => m != worstModule).Sum(modules => modules.Credits);

            return totalMarks / totalCredits;

        }

        static GradingClassSystem Classify(double marks)
        {
            if (marks >= 70) return GradingClassSystem._1;
            if (marks >= 60) return GradingClassSystem._21;
            if (marks >= 50) return GradingClassSystem._22;
            if (marks >= 40) return GradingClassSystem._3;
            return GradingClassSystem._U;
        }
    }
}
