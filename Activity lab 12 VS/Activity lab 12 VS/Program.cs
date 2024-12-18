using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity_lab_12_VS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] number=new int[7] {0,1,2,3,4,5,6};

            var numquery=
                from num in number
                where (num%2==0)
                select num;

            foreach (int num in numquery)
            {
                Console.WriteLine(num);
            }

            studentClass obj=new studentClass();
            obj.QueryHighScores(1, 90);

            Console.WriteLine();
            Console.ReadKey();


        }
    }

    public class studentClass
    {
        protected enum Gradelevel { firstyear = 1, secondyear, thirdyear };

        protected class student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int id { get; set; }
            public Gradelevel year;

            public List<int> ExamScores;

        }

        protected static List<student> students = new List<student>()
        {
            new student
            {
                FirstName="terry",LastName="adams",id=1,year=Gradelevel.secondyear,
                ExamScores=new List<int>{99,82,82,79}
            },
            new student
            {
                FirstName="Fadi",LastName="adams",id=2,year=Gradelevel.secondyear,
                ExamScores=new List<int>{69,82,92,29}
            },
            new student
            {
                FirstName="Mahad",LastName="ghauri",id=3,year=Gradelevel.thirdyear,
                ExamScores=new List<int>{99,92,92,29}
            },
            new student
            {
                FirstName="Faseeh",LastName="adams",id=4,year=Gradelevel.firstyear,
                ExamScores=new List<int>{69,62,72,39}
            },
            new student
            {
                FirstName="mahateer",LastName="Faseeh",id=5,year=Gradelevel.firstyear,
                ExamScores=new List<int>{79,35,52,79}
            },
            new student
            {
                FirstName="Arsal",LastName="Ghauri",id=6,year=Gradelevel.secondyear,
                ExamScores=new List<int>{12,82,95,99}
            }
        };

        protected static int Getpercent(student s)
        {
            double avg = s.ExamScores.Average();
            return avg > 0 ? (int)avg / 10 : 0;
        }


        public void QueryHighScores(int exams, int score)
        {
            var highScores = from student in students
                             where student.ExamScores[exams] > score
                             select new { Name = student.FirstName, Score = student.ExamScores[exams] };

            foreach (var item in highScores)
            {
                Console.WriteLine( "{0, -10}{1}", item.Name, item.Score);
            }

        }
    }
}
