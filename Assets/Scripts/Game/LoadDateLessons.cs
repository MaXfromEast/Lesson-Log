
using Assets.Scripts;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class LoadDateLessons : MonoBehaviour
{
    private Lesson lesson;
    
    [SerializeField] private InputField textSubject;
    [SerializeField] private Text textClassName;
    [SerializeField] private InputField textTime;


    public void MakeLesson()
    {
        lesson = new Lesson();
        lesson.Subject = textSubject.text;
        lesson.ClassName = textClassName.text;
        lesson.TimeLesson = textTime.text;
        string currentDate = PlayerPrefs.GetString("CurrentDateLessons");
        DateAndLessons dateAndLessons;
        dateAndLessons = LoadDateAndLesson(currentDate);
        dateAndLessons.AllLessons.AddLesson(lesson);
        
        Debug.Log("currentdate :" + currentDate);
        dateAndLessons.Date = currentDate;
        SaveDateAndLessons(dateAndLessons, currentDate);
    }

    public void SaveDateAndLessons(DateAndLessons dateAndLessons, string date)
    {
        string sdal = JsonConvert.SerializeObject(dateAndLessons);
        Debug.Log("sdal :" + sdal);
        PlayerPrefs.SetString(date, sdal);
    }

    public DateAndLessons LoadDateAndLesson(string currentDate)
    {
        string tmp = PlayerPrefs.GetString(currentDate);
        if (tmp != "")
        {
            return JsonConvert.DeserializeObject<DateAndLessons>(tmp);
        }
        else
        {
            DateAndLessons dateAndLessons = new DateAndLessons();
            return dateAndLessons;
        }
    }



}

