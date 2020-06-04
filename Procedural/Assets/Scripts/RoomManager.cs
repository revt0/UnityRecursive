using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Andrew Denman 2/6/2020
public class RoomManager : MonoBehaviour
{
    public GameObject[] bottomRooms;
    public GameObject[] topRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject spawnRoom;
    public GameObject closedRoom;
    public GameObject roomTile;

    public List<RoomTile> rooms;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRoom(Vector3 vectPos, bool needS, int dirNeed)
    {
        RoomTile tempRT = new RoomTile(vectPos, needS, dirNeed);
        Instantiate(roomTile, vectPos, Quaternion.identity);
    }
}
