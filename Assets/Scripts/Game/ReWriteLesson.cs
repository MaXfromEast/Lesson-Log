using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReWriteLesson : MonoBehaviour
{
    [SerializeField] private Text textClassName;
    [SerializeField] private Text textSubject;
    [SerializeField] private Text textTimeLesson;
    [SerializeField] private Toggle toggleIsDone;
    [SerializeField] private Text textNumber;
    public void Rewrite()
    {
        Lesson reLesson = new Lesson();
        reLesson.ClassName = textClassName.text;
        reLesson.Subject = textSubject.text;
        reLesson.TimeLesson = textTimeLesson.text;
        reLesson.IsDone = toggleIsDone.isOn;
        int nb = int.Parse(textNumber.text);
        string currentDate = PlayerPrefs.GetString("CurrentDateLessons");
        DateAndLessons dateAndLessons;
        dateAndLessons = LoadDateAndLesson(currentDate);
        dateAndLessons.AllLessons.Lessons[nb] = reLesson;
        Debug.Log("currentdate :" + currentDate);
        SaveDateAndLessons(dateAndLessons, currentDate);
    }

    public void SaveDateAndLessons(DateAndLessons dateAndLessons, string date)
    {
        string sdal = JsonConvert.SerializeObject(dateAndLessons);
        PlayerPrefs.SetString(date, sdal);
    }

    public DateAndLessons LoadDateAndLesson(string currentDate)
    {
        string tmp = PlayerPrefs.GetString(currentDate);
        return JsonConvert.DeserializeObject<DateAndLessons>(tmp);

    }
}



