

using UnityEngine.Events;

namespace Assets.Scripts

{
    class GlobalEventManager
    {
        public static UnityEvent<Student> buttonOnStudentPressed = new UnityEvent<Student>();
        public static void SentButtonPressed(Student student)
        {
            buttonOnStudentPressed.Invoke(student);
        }

        
    }
}
