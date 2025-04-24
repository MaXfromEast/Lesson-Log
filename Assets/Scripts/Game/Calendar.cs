using System;
using UnityEngine;
using UnityEngine.UI;

public class Calendar : MonoBehaviour
{
    [SerializeField] private GameObject boxDay;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject buttonPlus;
    [SerializeField] private Transform contentForLessons;
    private string[] days;
    void Start()
    {
        days = new string[60];
        DateTime thisDay = DateTime.Today;
        for (int i=0; i<60; i++)
        {
            days[i] = thisDay.AddDays(i - 30).ToString("ddd\ndd.MM");
            if(i<25)
            {
                PlayerPrefs.DeleteKey(days[i]);
            }
            else
            {
                GameObject cloneBoxDay = Instantiate(boxDay, content);
                if (PlayerPrefs.GetString(days[i]) != "")
                {
                    cloneBoxDay.GetComponent<Image>().color = new Color(255 / 255.0f, 0 / 255.0f, 0 / 255.0f, 255 / 255.0f);
                }
                cloneBoxDay.transform.GetChild(0).GetComponent<Text>().text = days[i];
                cloneBoxDay.GetComponent<SetLesson>().SetPlusButton(buttonPlus);
                cloneBoxDay.GetComponent<SetLesson>().SetContent(contentForLessons);
            }
        }
        

       
    }

    
}
