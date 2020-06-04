using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawn : MonoBehaviour
{

    public int openingDirection;
    /*
     * 1 -> needs bottom
     * 2 -> needs top
     * 3 -> needs left
     * 4 -> needs right
     */
    public RoomTemplates templates;
    private int ran;
    private bool spawned = false;
    private float waitTime = 4f;
    
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, waitTime);
        //templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.1f);
    }

    // Update is called once per frame
    void Spawn()
    {
        if (spawned == false)
        {
            if (openingDirection == 1)
            {
                ran = Random.Range(0, templates.bottomRooms.Length);
                Instantiate(templates.bottomRooms[ran], transform.position,Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                ran = Random.Range(0, templates.topRooms.Length);
                Instantiate(templates.topRooms[ran], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                ran = Random.Range(0, templates.leftRooms.Length);
                Instantiate(templates.leftRooms[ran], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                ran = Random.Range(0, templates.rightRooms.Length);
                Instantiate(templates.rightRooms[ran], transform.position, Quaternion.identity);
            }
            spawned = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawn>().spawned == false && spawned == false)
            {
                Debug.Log(templates.name);
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);

            spawned = true;
        }
    }
}
