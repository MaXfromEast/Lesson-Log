using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class AllLessons
    {
        private List<Lesson> lessons = new List<Lesson>();

        public int Length => lessons.Count();

        public void AddLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }

        public List<Lesson> Lessons
        {
            get
            {
                return lessons;
            }
        }
        public void DeleteStudent(Lesson lesson)
        {
            lessons.Remove(lesson);
        }
    }
}
