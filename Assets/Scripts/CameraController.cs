using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Joystick joystick;
    private float MouseX;
    private float MouseY;
    public float sensitivityMouse = 200f;

    public Transform player;

    void Update()
    {
        MouseX = joystick.Horizontal * sensitivityMouse * Time.deltaTime;
        MouseY = joystick.Vertical * sensitivityMouse * Time.deltaTime;

        if (transform.localRotation.x >= 0.4)
        {
            transform.localRotation = new Quaternion(0.39f, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
        }
        else if (transform.localRotation.x <= -0.2)
        {
            transform.localRotation = new Quaternion(-0.19f, transform.localRotation.y, transform.localRotation.z, transform.localRotation.w);
        }
        else
        {
            player.Rotate(MouseX * new Vector3(0, 1, 0));
            transform.Rotate(-MouseY * new Vector3(1, 0, 0));
        }
    }
}
