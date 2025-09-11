using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float angleRotation = 45f;
    public float playerRotationSpeed = 5f;

    private Vector3 distanceFromPlayer = Vector3.zero;
    private float rotationX = 9.0f;
    private float rotationY = 0.0f;
    private bool isInverted;

    public float minYRotation = -60f;
    public float maxYRotation = 60f;

    private void Awake()
    {
        isInverted = PlayerPrefs.GetInt("isInverted", 0) == 1;
        distanceFromPlayer = transform.position - player.position;
    }

    private void Update()
    {
        FollowPlayer();
        RotateAroundPlayer();
        RotatePlayer();
    }

    void RotateAroundPlayer()
    {
        rotationX += Input.GetAxis("Mouse X") * angleRotation * Time.deltaTime;

        if (isInverted)
        {
            rotationY += Input.GetAxis("Mouse Y") * angleRotation * Time.deltaTime;
        }
        else
        {
            rotationY -= Input.GetAxis("Mouse Y") * angleRotation * Time.deltaTime;
        }

        rotationY = Mathf.Clamp(rotationY, minYRotation, maxYRotation);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);
        transform.position = player.position + distanceFromPlayer;
        transform.rotation = rotation;
    }

    void FollowPlayer()
    {
        Vector3 targetPosition = player.position + distanceFromPlayer;
        transform.position = targetPosition;
    }

    void RotatePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Quaternion targetRotation = Quaternion.Euler(0, rotationX, 0);
            player.rotation = Quaternion.Slerp(player.rotation, targetRotation, Time.deltaTime * playerRotationSpeed);
        }
    }
}
