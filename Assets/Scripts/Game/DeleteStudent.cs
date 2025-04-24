using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class DeleteStudent : MonoBehaviour
{
    [SerializeField] private Text textNameStudent;
    [SerializeField] private Text textGradesStudents;
    [SerializeField] private ListStudentsInClass listStudentsInClass;
    [SerializeField] private GameObject textStudentDeleted;

    public void DeletePressed()
    {
        Student student = new Student();
        student.FullName = textNameStudent.text;
        student.Grades = textGradesStudents.text;
        listStudentsInClass.DelStudent(student);
        textStudentDeleted.SetActive(true);
    }
}
