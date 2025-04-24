using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    public class Lesson : IEquatable<Lesson>
    {
        
        private string subject;
        private string timeLesson;
        private string className;
        private bool isDone;
        

        public string Subject
        {
            set
            {
                subject = value;
            }
            get
            {
                return subject;
            }
        }

        public string TimeLesson
        {
            set
            {
                timeLesson = value;
            }
            get
            {
                return timeLesson;
            }
        }

        public string ClassName
        {
            set
            {
                className = value;
            }
            get
            {
                return className;
            }
        }

        public bool IsDone
        {
            get
            {
                return isDone;
            }
            set
            {
                isDone = value;
            }
        }

        public bool Equals(Lesson other)
        {
            if (other == null)
                return false;

            if ((this.ClassName == other.ClassName) && (this.subject == other.subject)&& (this.timeLesson == other.timeLesson))
                return true;
            else
                return false;
        }
    }
}
