using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
    public void XMove(int x)
    {
        Vector3 oldPosition = Camera.main.transform.position;
        oldPosition.x = oldPosition.x + x;
        Camera.main.transform.position = oldPosition;
    }

    
}
