using System.Collections;
using UnityEngine;

public class SetActive : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(routine: WaitCoroutine());
    }

    IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(false);
    }
}
