using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int count = 0;
            int threshold = (int)Math.Ceiling(Students.Count * 0.2);
            
            if(Students.Count < 5)
            {
                throw new InvalidOperationException();
            }

            foreach(Student s in Students)
            {
                if(s.AverageGrade > averageGrade)
                {
                    count++;
                }
            }

            if(count <= threshold)
            {
                return 'A';
            } else if(count <= 2*threshold)
            {
                return 'B';
            } else if(count <= 3*threshold)
            {
                return 'C';
            } else if(count <= 4*threshold)
            {
                return 'D';
            }
            return 'F';
        }
    }
}
