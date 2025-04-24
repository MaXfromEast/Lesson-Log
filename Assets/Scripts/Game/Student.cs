
using System;

namespace Assets.Scripts
{
    public class Student : IEquatable<Student>
    {
        private string fullName;
        private string grades;
        

        public string FullName
        {
            set
            {
                fullName = value;
            }
            get
            {
                return fullName;
            }
        }

        public string Grades
        {
            set
            {
                grades = value;
            }
            get
            {
                return grades;
            }
        }

        public bool Equals(Student other)
        {
            if (other == null)
                return false;

            if ((this.fullName == other.fullName)&&(this.Grades == other.Grades))
                return true;
            else
                return false;
        }
    }
}
