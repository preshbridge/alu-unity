
using System.Threading;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    public Transform Player;

    public bool isInverted;
    private float AngleRotation = 45f;

    private Vector3 DistanceApart = Vector3.zero;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    public float rotationSpeed = 7f;

    public float minYrotation = -55f;
    public float maxYrotation = 55f;

    private void Awake()
    {
        isInverted = PlayerPrefs.GetInt("isInverted", 0) == 1;
        DistanceApart = transform.position - Player.position;
    
}

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
        RotatePlayer();
    }

    void RotateAroundPlayer()
    {
        rotationX += Input.GetAxis("Mouse X") * AngleRotation * Time.deltaTime;


        if (isInverted)
        {
            rotationY += Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }
        else
        {
            rotationY -= Input.GetAxis("Mouse Y") * AngleRotation * Time.deltaTime;
        }

        rotationY = Mathf.Clamp(rotationY, minYrotation, maxYrotation);
            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        transform.rotation = rotation;

        transform.position = Player.position + DistanceApart;


        // transform.RotateAround(Player.position, Vector3.up,   RotationYDirection * AngleRotation * Time.deltaTime);
        //transform.LookAt(Player);
        //transform.rotation = rotation;
    }

    void FollowPlayer()
    {
        Vector3 pos = Player.position + DistanceApart;
        transform.position = pos;
    }

    void RotatePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Quaternion pos = Quaternion.Euler(0, rotationX, 0);
            Player.rotation = Quaternion.Slerp(Player.rotation, pos, Time.deltaTime * rotationSpeed);
        }
    }
}