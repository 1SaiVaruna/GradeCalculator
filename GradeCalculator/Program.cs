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
                new Module("CET252", "Agile Development", 20, InputMarks("Agile Development" ),
                new Module("CET253", "Database Systems", 20, InputMarks("Databases Systems"),
                new Module("CET254", "Advanced Programming", 20, InputMarks("Advanced Programming")),
                new Module("CET255", "IoT and Robotics", 20, InputMarks("IoT and Robotics")),
                new Module("CET256", "Cyber Security", 20, InputMarks("Cyber Security")),
                new Module("CET257", "Enterprise Project", 20, InputMarks("Enterprise Project")),
            };
        }

        static double InputMark(string moduleName)
        {
            double marks;

            Console.Write($"ENTER MARKS FOR: {moduleName}: ");

            while (!double.TryParse(Console.ReadLine(), out marks) || marks < 0 || marks > 100)
            {
                Console.Write("INVALID INPUT. TRY AGAIN. ENTER MARKS ( 0 - 100 ): ");
            }

        }
    }
}
