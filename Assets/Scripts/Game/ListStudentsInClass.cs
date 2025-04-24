using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListStudentsInClass : MonoBehaviour
{
    [SerializeField] private Text nameClassText;
    [SerializeField] private Text nameStudentText;
    [SerializeField] private Text gradesStudentText;
    [SerializeField] private GameObject boxStudent;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject buttonAddStudent;
    [SerializeField] private GameObject buttonPlus;
    [SerializeField] private GameObject canvasWithScrollField;
    [SerializeField] private GameObject textStudentAdded;
    [SerializeField] private Text indexField;
    [SerializeField] private GameObject textClassDeleted;
    private bool isNewStudent;
    private Class currentClass;

    private void Start()
    {
        LoadAll();
        
    }

    public void AddStudent()
    {
        string nameStudentString = nameStudentText.text;
        if (nameStudentString != "")
        {
            Student newStudent = new Student();
            newStudent.FullName = nameStudentString;
            newStudent.Grades = gradesStudentText.text;
            currentClass.StudentsOfThisClass.AddStudent(newStudent);
            SaveClass(currentClass);
            textStudentAdded.SetActive(true);
            isNewStudent = true;
        }
    }

    public void SaveClass(Class current—lass)
    {
        string std = JsonConvert.SerializeObject(current—lass);
        PlayerPrefs.SetString(current—lass.NameClass, std);
    }

    public Class LoadClass(string nameClass)
    {
        string std = PlayerPrefs.GetString(nameClass);
        return JsonConvert.DeserializeObject<Class>(std);
    }

    public void LoadAll()
    {
        string nameClass = PlayerPrefs.GetString("CurrentClass");
        nameClassText.text = nameClass;
        currentClass = LoadClass(nameClass);
        int numberOfStudents = currentClass.StudentsOfThisClass.Length;
        if(numberOfStudents>0)
        {
            buttonAddStudent.SetActive(false);
            buttonPlus.SetActive(true);
            canvasWithScrollField.SetActive(true);

            for (int i = 0; i<numberOfStudents; i++)
            {
                GameObject cloneStudent = Instantiate(boxStudent, content);
                cloneStudent.transform.GetChild(0).GetComponent<Text>().text = currentClass.StudentsOfThisClass.Students[i].FullName;
                cloneStudent.transform.GetChild(1).GetComponent<Text>().text = currentClass.StudentsOfThisClass.Students[i].Grades;
            }
        }
    }

    public void LoadNew()
    {
        if (isNewStudent)
        {
            string nameClass = PlayerPrefs.GetString("CurrentClass");
            currentClass = LoadClass(nameClass);
            int numberOfStudents = currentClass.StudentsOfThisClass.Length;
            if (numberOfStudents > 0)
            {
                buttonAddStudent.SetActive(false);
                buttonPlus.SetActive(true);
                canvasWithScrollField.SetActive(true);
                GameObject cloneStudent = Instantiate(boxStudent, content);
                cloneStudent.transform.GetChild(0).GetComponent<Text>().text = currentClass.StudentsOfThisClass.Students[numberOfStudents - 1].FullName;
                cloneStudent.transform.GetChild(1).GetComponent<Text>().text = currentClass.StudentsOfThisClass.Students[numberOfStudents - 1].Grades;
                isNewStudent = false;
            }
        }
    }

    public void DelStudent(Student student)
    {
        string nameClass = PlayerPrefs.GetString("CurrentClass");
        currentClass = LoadClass(nameClass);
        currentClass.StudentsOfThisClass.DeleteStudent(student);
        SaveClass(currentClass);
        GameObject[] boxes;
        boxes = GameObject.FindGameObjectsWithTag("BoxStudent");
        foreach (GameObject box in boxes)
        {
            if((box.transform.GetChild(0).GetComponent<Text>().text == student.FullName)&&(box.transform.GetChild(1).GetComponent<Text>().text==student.Grades))
            {
                Destroy(box);
            }
        }

    }
    public int FindRwiteStudent()
    {
        int index = -1;
        Student olsStudent = GetComponent<FillField>().ReturnCurrentStudent();
        string nameClass = PlayerPrefs.GetString("CurrentClass");
        Class currentClass = LoadClass(nameClass);
        foreach(Student std in currentClass.StudentsOfThisClass.Students)
        {
            if(std.Equals(olsStudent))
            {
                index = currentClass.StudentsOfThisClass.Students.IndexOf(std);
                break;
            }
        }
        return index;
    }

    public void ReRwiteStudent(int index, string fullName, string grades)
    {
        string nameClass = PlayerPrefs.GetString("CurrentClass");
        Class currentClass = LoadClass(nameClass);
        currentClass.StudentsOfThisClass.Students[index].FullName = fullName;
        currentClass.StudentsOfThisClass.Students[index].Grades = grades;
        SaveClass(currentClass);
    }


    public void DelClass()
    {
        string currentNameClass = PlayerPrefs.GetString("CurrentClass");
        PlayerPrefs.DeleteKey("CurrentClass");
        PlayerPrefs.DeleteKey(currentNameClass);
        string nms = PlayerPrefs.GetString("NamesClasses");
        List<string> lnms = new List<string>();
        lnms = JsonConvert.DeserializeObject<List<string>>(nms);
        lnms.Remove(currentNameClass);
        nms = JsonConvert.SerializeObject(lnms);
        PlayerPrefs.SetString("NamesClasses", nms);
        textClassDeleted.SetActive(true);
    }
}
