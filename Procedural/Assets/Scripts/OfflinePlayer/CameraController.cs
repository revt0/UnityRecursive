using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; set; }
    public Transform player;
    private Vector3 offset;
    public float smoothSpeed;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        offset = new Vector3(0f, 10f, -10f);
    }

    private void LateUpdate()
    {
        Vector3 velocity = LocalPlayer.velocity;
        return;
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);
        if (Vector3.Distance(desiredPosition, transform.position) > 1.2f)
            transform.position = desiredPosition;
        else
            transform.position = smoothPosition;
    }
}