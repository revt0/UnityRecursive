using UnityEngine;

public class SceneCamera : MonoBehaviour
{
    public static SceneCamera Instance { get; set; }

    private void Awake()
    {
        if (CameraController.Instance != null && CameraController.Instance.gameObject.activeInHierarchy)
            gameObject.SetActive(false);

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
}