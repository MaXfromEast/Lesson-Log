using Assets.Scripts;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListClassesMain : MonoBehaviour
{
    
    [SerializeField] private GameObject boxClass;
    [SerializeField] private Transform content;
    [SerializeField] private GameObject buttonAddClass;
    [SerializeField] private GameObject buttonPlus;
    [SerializeField] private GameObject canvasWithScrollField;
    [SerializeField] private GameObject textClassAdded;
    [SerializeField] private Text nameClassText;
    private bool isAddClass;

   // private List<Class> AllClasses;


    void Start()
    {
        LoadStart();
    }

    public void AddClass()
    {
        string nameClassString = nameClassText.text; 
        if (nameClassString != "")
        {
            SaveNameClass(nameClassString, LoadNameClass());
            Class newClass = new Class();
            newClass.NameClass = nameClassString;
            SaveClass(newClass);
            textClassAdded.SetActive(true);
            isAddClass = true;
        }
    }

    public void LoadStart()
    {
        if (LoadNameClass().Count > 0)
        {
            buttonAddClass.SetActive(false);
            buttonPlus.SetActive(true);
            canvasWithScrollField.SetActive(true);
            List<string> namesClasses = LoadNameClass();
            //AllClasses = new List<Class>();
            foreach (string name in namesClasses)
            {
                Class oneOfClass = new Class();
                oneOfClass = LoadClass(name);
                //AllClasses.Add(oneOfClass);
                GameObject cloneBoxClass = Instantiate(boxClass, content);
                cloneBoxClass.transform.GetChild(0).GetComponent<Text>().text = oneOfClass.NameClass;
                cloneBoxClass.transform.GetChild(1).GetComponent<Text>().text = oneOfClass.StudentsOfThisClass.Length.ToString();
            }
        }
    }

    public void LoadNew()
    {
        if (LoadNameClass().Count > 0)
        {
            buttonAddClass.SetActive(false);
            buttonPlus.SetActive(true);
            canvasWithScrollField.SetActive(true);
            if (isAddClass)
            {
                List<string> namesClasses = LoadNameClass();
                //AllClasses = new List<Class>();
                Class oneOfClass = new Class();
                oneOfClass = LoadClass(namesClasses[LoadNameClass().Count-1]);
                //AllClasses.Add(oneOfClass);
                GameObject cloneBoxClass = Instantiate(boxClass, content);
                cloneBoxClass.transform.GetChild(0).GetComponent<Text>().text = oneOfClass.NameClass;
                cloneBoxClass.transform.GetChild(1).GetComponent<Text>().text = oneOfClass.StudentsOfThisClass.Length.ToString();
            }
        }
        isAddClass = false;
    }
    public void SaveNameClass(string newName, List<string> lnms)
    {
        lnms.Add(newName);
        string nms = JsonConvert.SerializeObject(lnms);
        PlayerPrefs.SetString("NamesClasses", nms);
    }

    public List<string> LoadNameClass()
    {
        string nms = PlayerPrefs.GetString("NamesClasses");
        List<string> lnms = new List<string>();
        if (nms != "")
        {
            lnms = JsonConvert.DeserializeObject<List<string>>(nms);
        }
        return lnms;
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

}
