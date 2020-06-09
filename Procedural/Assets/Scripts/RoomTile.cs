using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Andrew Denman 2/6/2020
public class RoomTile : MonoBehaviour
{
    /* Directions
     * 1 ->  bottom
     * 2 ->  top
     * 3 ->  left
     * 4 ->  right
     */
    private RoomManager roomManager;
    private Transform prevConnect;
    private Transform currConnect;
    private Vector3 vectPosition;
    private GameObject tile;
    private bool needsSpawn;


    public void setVars(Vector3 vectPos, bool needS, GameObject aTile, RoomManager roomMan)
    {

        roomManager = roomMan;
        vectPosition = vectPos;
        needsSpawn = needS;
        tile = aTile;
    }

    public void Init()
    {
        //transform.position = vectPosition;
        spawnTile();
    }

    public void spawnTile()
    {
        
        GameObject temp = Instantiate(tile, transform);
        currConnect = temp.GetComponentInChildren<Transform>().Find("ConnectPoint");
    }
    // Start is called before the first frame update

    public Transform getConnect()
    {
        return currConnect;
    }
    void Start()
    {
        //Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
