using UnityEngine.UI;
using UnityEngine;

public class ClearField : MonoBehaviour
{
    [SerializeField] private InputField fieldForClear;
    public void Clear()
    {
        fieldForClear.text = "";
    }
}
