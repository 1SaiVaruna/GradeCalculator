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
        }
    }
}
