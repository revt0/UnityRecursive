using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//written by Andrew Denman 2/6/2020
public class RoomManager : MonoBehaviour
{
    public GameObject[] Tiles;
    public GameObject spawnTile;
    public GameObject endTile;
    public GameObject roomTile;
    public int mapLength;
    public List<RoomTile> rooms;
    // Start is called before the first frame update
    void Start()
    {
        mapLength = 10;
        init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void init()
    {
        GameObject curr = SpawnRoom(new Vector3(0f, 0f, 0f), true, 0);
        Transform connectP;
        for (int i =0; i< mapLength;++i)
        {
            connectP = curr.GetComponent<Transform>().Find("ConnectPoint");
            SpawnRoom(connectP.position, true, 2);
                
        }
        connectP = curr.GetComponent<Transform>().Find("ConnectPoint");
        SpawnRoom(connectP.position, true, 1);
    }

    //type 0 = start area
    //type 1 = end area
    //type 2 = random
    private GameObject SpawnRoom(Vector3 vectPos, bool needS, int type)
    {
        GameObject tempTile = spawnTile;
        switch (type)
        {
            case 0:
                tempTile = spawnTile;
                break;
            case 1:
                tempTile = endTile;
                break;
            case 2:
                int index = Random.Range(0,Tiles.Length);
                tempTile = Tiles[index];
                break;
        }
        RoomTile tempRT = new RoomTile();
        tempRT.setVars(vectPos, needS, tempTile, this);
        return Instantiate(roomTile, vectPos, Quaternion.identity);
        
    }
}
