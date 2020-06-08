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
    private GameObject prevConnect;
    private GameObject currConnect;
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

    public void init()
    {
        //transform.position = vectPosition;
        spawnTile();
    }

    public void spawnTile()
    {
        Instantiate(tile, vectPosition, Quaternion.identity);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
