using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetLesson : MonoBehaviour
{
    [SerializeField] private Text textDate;
    [SerializeField] private GameObject boxLesson;
    private GameObject plusButton;
    private Transform content;
    
    public void Appoint()
    {


        PlayerPrefs.SetString("CurrentDateLessons", textDate.text);
        plusButton.SetActive(true);
        GameObject[] boxes;
        boxes = GameObject.FindGameObjectsWithTag("BoxLesson");
        foreach (GameObject box in boxes)
        {
            Destroy(box);   
        }
        if (PlayerPrefs.GetString(textDate.text) != "")
        {
            
            string tmp = PlayerPrefs.GetString(textDate.text);
            DateAndLessons dateAndLessons = new DateAndLessons();
            dateAndLessons = JsonConvert.DeserializeObject<DateAndLessons>(tmp); 
            int k = dateAndLessons.AllLessons.Length;
           
            for (int i = 0; i < k; i++)
            {
                GameObject cloneBoxLesson = Instantiate(boxLesson, content);
                cloneBoxLesson.transform.GetChild(0).GetComponent<InputField>().text = dateAndLessons.AllLessons.Lessons[i].Subject;
                cloneBoxLesson.transform.GetChild(1).GetComponent<Text>().text = dateAndLessons.AllLessons.Lessons[i].ClassName;
                cloneBoxLesson.transform.GetChild(2).GetComponent<InputField>().text = dateAndLessons.AllLessons.Lessons[i].TimeLesson;
                cloneBoxLesson.transform.GetChild(4).GetComponent<Toggle>().isOn = dateAndLessons.AllLessons.Lessons[i].IsDone;
                cloneBoxLesson.transform.GetChild(5).GetComponent<Text>().text = i.ToString();
            }
            

        }
    }

    public void SetPlusButton(GameObject plusButton)
    {
        this.plusButton = plusButton;
    }

    public void SetContent(Transform content)
    {
        this.content = content;
    }


}
