using Assets.Scripts;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class FillField : MonoBehaviour
{
    [SerializeField] private Text textNameStudent;
    [SerializeField] private Text textGradesStudents;
    [SerializeField] private Text textNameClass;
    [SerializeField] private Text textHeader;
    [SerializeField] private Text textNameClassHeader;
    [SerializeField] private InputField inputNameStudent;
    [SerializeField] private Text dropGadesStudent;
    private ListStudentsInClass listStudentsInClass;
    private int index;
    private bool isChangeStudent;

    private void Start()
    {
        GlobalEventManager.buttonOnStudentPressed.AddListener(Fill);
        listStudentsInClass = GetComponent<ListStudentsInClass>();
    }
    public void Fill(Student student)
    {
        textNameStudent.text = student.FullName;
        textGradesStudents.text = student.Grades;
        textHeader.text = student.FullName;
        textNameClass.text = textNameClassHeader.text;
    }

    public Student ReturnCurrentStudent()
    {
        Student student = new Student();
        student.FullName = textNameStudent.text;
        student.Grades = textGradesStudents.text;
        return student;
    }

    public void WriteButtonPressed()
    {
        inputNameStudent.text = textNameStudent.text;
        dropGadesStudent.text = textGradesStudents.text;
        index = listStudentsInClass.FindRwiteStudent();
        isChangeStudent = true;
    }

    public void BackButtonPressed()
    {
        if (isChangeStudent == true)
        {
            string fullName = inputNameStudent.text;
            string grades = dropGadesStudent.text;
            listStudentsInClass.ReRwiteStudent(index, fullName, grades);
        }
        isChangeStudent = false;
    }
   
}
