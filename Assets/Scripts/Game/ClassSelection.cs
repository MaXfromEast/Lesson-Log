using UnityEngine;
using UnityEngine.UI;

public class ClassSelection : MonoBehaviour
{
    [SerializeField] private Text textCurrentClass;
    public void Choice()
    {
        PlayerPrefs.SetString("CurrentClass", textCurrentClass.text);
    }    
}
