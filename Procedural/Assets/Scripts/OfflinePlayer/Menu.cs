using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public static Menu Instance { get; set; }

    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private MeshRenderer skinSelectRenderer;
    [SerializeField] private AudioSource skinButtonAudioSource;
    [SerializeField] private AudioSource joinAudioSource;
    private int currentSkin;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        SetName();
        if (PlayerPrefs.HasKey("PlayerSkin"))
        {
            currentSkin = PlayerPrefs.GetInt("PlayerSkin");
            skinSelectRenderer.sharedMaterial = Skins.Instance.skins[currentSkin];
        }
    }

    public void SetName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
            nameInputField.text = PlayerPrefs.GetString("PlayerName");
    }

    public void SaveName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
    }

    public void RightArrow()
    {
        currentSkin++;
        if (currentSkin >= Skins.Instance.skins.Length)
            currentSkin = 0;
        skinSelectRenderer.sharedMaterial = Skins.Instance.skins[currentSkin];
        skinButtonAudioSource.PlayOneShot(skinButtonAudioSource.clip);
    }

    public void LeftArrow()
    {
        currentSkin--;
        if (currentSkin < 0)
            currentSkin = Skins.Instance.skins.Length - 1;
        skinSelectRenderer.sharedMaterial = Skins.Instance.skins[currentSkin];
        skinButtonAudioSource.PlayOneShot(skinButtonAudioSource.clip);
    }

    public void JoinButton()
    {
        //ClientSend.SpawnRequest(nameInputField.text, currentSkin);
        joinAudioSource.PlayOneShot(joinAudioSource.clip);
        SaveName(nameInputField.text);
        PlayerPrefs.SetInt("PlayerSkin", currentSkin);
    }
}