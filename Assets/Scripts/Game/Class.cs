
namespace Assets.Scripts
{
    public class Class
    {
        private string nameClass;
        private StudentsOfTheSameClass studentsOfThisClass = new StudentsOfTheSameClass();

        public string NameClass
        {
            set
            {
                nameClass = value;
            }
            get
            {
                return nameClass;
            }
        }
        public StudentsOfTheSameClass StudentsOfThisClass
        {
            set
            {
                studentsOfThisClass = value;
            }
            get
            {
                return studentsOfThisClass;
            }
        }



    }
}
