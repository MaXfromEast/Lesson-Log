using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetClassesNames : MonoBehaviour
{
    [SerializeField] private Dropdown downNamesClasses;

    public void GetNames()
    {
        downNamesClasses.options.Clear();
        string nms = PlayerPrefs.GetString("NamesClasses");
        List<string> lnms = new List<string>();
        if (nms != "")
        {
            lnms = JsonConvert.DeserializeObject<List<string>>(nms);
        }
        foreach (string item in lnms)
        {
            Dropdown.OptionData m_NewData = new Dropdown.OptionData();
            m_NewData.text = item;
            downNamesClasses.options.Add(m_NewData);
        }
    }
}
