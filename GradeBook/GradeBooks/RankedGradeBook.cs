using System;
using System.Collections.Generic;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool IsWeighted) : base(name, IsWeighted)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            double count = 0.0;
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].AverageGrade <= averageGrade)
                {
                    count++;
                }               
            }
            if (count / Students.Count > 0.8)
                return 'A';
            else if (count / Students.Count > 0.6)
                return 'B';
            else if (count / Students.Count > 0.4)
                return 'C';
            else if (count / Students.Count > 0.2)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStatistics();

        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);

        }
    }
}
