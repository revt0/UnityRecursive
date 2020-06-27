using System.Collections.Generic;
using UnityEngine;

public class OfflinePlayer : MonoBehaviour
{
    public GameObject pickupGO;

    private Rigidbody rb;
    private readonly float defaultSpeed = 10f;
    private float currentSpeed;
    private bool isSpeedBoostActive;
    private float speedBoostCounter;
    private List<GameObject> pickups = new List<GameObject>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        if (SceneCamera.Instance != null)
            SceneCamera.Instance.gameObject.SetActive(false);
        Respawn();
        SpawnPickups();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (speedBoostCounter >= 180)
        {
            currentSpeed = defaultSpeed;
            speedBoostCounter = 0;
            isSpeedBoostActive = false;
        }
        else if (isSpeedBoostActive)
            speedBoostCounter++;

        Vector3 movement = new Vector3(horizontal, 0.0f, vertical);
        rb.AddForce(movement * currentSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Kill Box"))
            Respawn();
        if (other.gameObject.CompareTag("Pick Up"))
        {
            Destroy(other.gameObject);
            currentSpeed += (defaultSpeed * 0.65f);
            isSpeedBoostActive = true;
            AudioSource audio = GetComponentInChildren<AudioSource>();
            if (!audio.isPlaying)
                audio.PlayOneShot(audio.clip);
        }
    }

    public void Respawn()
    {
        transform.position = RespawnPoint();
        ResetMovement();
        SpawnPickups();
    }

    private void ResetMovement()
    {
        rb.Sleep();
        currentSpeed = defaultSpeed;
        rb.velocity = Vector3.zero;
        rb.WakeUp();
    }

    private Vector3 RespawnPoint()
    {
        GameObject[] pointsGO = GameObject.FindGameObjectsWithTag("Spawn Point");
        if (pointsGO.Length < 1)
            return new Vector3(0f, 0.5f, 0f);
        Vector3[] points = new Vector3[pointsGO.Length];
        for (int i = 0; i < pointsGO.Length; i++)
            points[i] = pointsGO[i].transform.position;
        return points[Random.Range(0, points.Length)];
    }

    private void SpawnPickups()
    {
        foreach (GameObject go in pickups)
            Destroy(go);
        pickups.Clear();
        GameObject[] pointsGO = GameObject.FindGameObjectsWithTag("Pickup Spawn");
        if (pointsGO.Length < 1)
            return;
        for (int i = 0; i < pointsGO.Length; i++)
        {
            GameObject pickup = Instantiate(pickupGO, pointsGO[i].transform.position, Quaternion.identity);
            BoxCollider pickupCollider = pickup.AddComponent<BoxCollider>();
            pickupCollider.size = new Vector3(1.1f, 1.1f, 1.1f);
            pickupCollider.isTrigger = true;
            pickups.Add(pickup);
        }
    }
}