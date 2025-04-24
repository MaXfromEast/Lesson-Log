using System;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Scripts
{
    public class StudentsOfTheSameClass
    {
        private List<Student> students = new List<Student>();
       
        public int Length => students.Count();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public List<Student> Students
        {
            set
            {
                students = value;
            }
            get
            {
                return students;
            }
        }
        public void DeleteStudent(Student student)
        {
            students.Remove(student);
        }

    }
}
