using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float offsetX;
    
	void Update ()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x + offsetX, transform.position.y, transform.position.z);
        }
	}
}
