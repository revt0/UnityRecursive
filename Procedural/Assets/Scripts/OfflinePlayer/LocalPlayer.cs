using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static Vector3 velocity;

    private void Start()
    {
        LockCursor();
        Init();
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Init()
    {
        if (SceneCamera.Instance != null)
            SceneCamera.Instance.gameObject.SetActive(false);
        RoundManager.Instance.roundCanvas.enabled = true;
        Menu.Instance.gameObject.SetActive(false);
    }
}