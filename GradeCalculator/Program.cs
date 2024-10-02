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
            Console.WriteLine("COMPUPTER SCIENCE GRADE CALCAULTOR");
            Console.WriteLine("\n- - - - - - - - - - -  - -\n");
            List<Module> modules = new List<Module>
            {
                new Module("CET252", "AGILE DEVELOPMENT", 20, InputMarks("AGILE DEVELOPMENT")),
                new Module("CET253", "DATABASE SYSTEMS", 20, InputMarks("DATABASE SYSTEMS")),
                new Module("CET254", "ADVANCED PROGRAMMING", 20, InputMarks("ADVANCED PROGRAMMING")),
                new Module("CET255", "IOT AND ROBOTICS", 20, InputMarks("IOT AND ROBOTICS")),
                new Module("CET256", "CYBER SECURITY", 20, InputMarks("CYBER SECURITY")),
                new Module("CET257", "ENTERPRISE PROJECT", 20, InputMarks("ENTERPRISE PROJECT"))
            };

            Console.WriteLine("\n- - - - - - - - - - -  - -\n");
            double averageMarks = CalculateNormalAverage(modules);
            Console.WriteLine($"AVERAGE: {averageMarks:F2}%");

            double bestAverageMarks = CalculateBestAverage(modules);
            Console.WriteLine($"BEST AVERAGE: {bestAverageMarks:F2}%");


            Console.WriteLine($"\nFINAL GRADE: {Classify(averageMarks)}");
            Console.WriteLine($"(BEST) FINAL GRADE: {Classify(bestAverageMarks)}");

            Console.ReadKey();

        }

        static double InputMarks(string moduleName)
        {
            double marks;

            Console.Write($"ENTER MARKS FOR {moduleName}: ");

            while (!double.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
            {
                Console.Write("\nINVALID INPUT. TRY AGAIN. ENTER MARKS ( 0 - 100 ): ");
            }
            Console.WriteLine("");
            return marks;
        }

        static double CalculateNormalAverage(List<Module> modules)
        {
            double totalMarks = 0;
            int totalCredits = 0;

            foreach (var module in modules)
            {
                totalMarks += module.Marks * module.Credits;
                totalCredits += module.Credits;
            }

            return totalMarks / totalCredits;

        }

        static double CalculateBestAverage(List<Module> modules)
        {

            Module worstModule = modules.OrderBy(m => m.Marks).First();

            double totalMarks = modules.Where(m => m != worstModule).Sum(m => m.Marks * m.Credits);
            int totalCredits = modules.Where(m => m != worstModule).Sum(modules => modules.Credits);

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
