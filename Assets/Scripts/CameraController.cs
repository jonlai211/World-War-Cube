using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 50f;

    void Update()
    {
        if (target)
        {
            transform.LookAt(target);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.RotateAround(target.position, Vector3.up, rotateSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.RotateAround(target.position, Vector3.up, -rotateSpeed * Time.deltaTime);
        }
    }
}