using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TheRightStudent : MonoBehaviour
{
    [SerializeField] private Text nameStudentText;
    [SerializeField] private Text gradesStudentText;

    
    public void GetStudent()
    {
        Student student = new Student();
        student.FullName = nameStudentText.text;
        student.Grades = gradesStudentText.text;
        GlobalEventManager.SentButtonPressed(student);
    }
}
