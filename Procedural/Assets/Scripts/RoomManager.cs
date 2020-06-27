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
    public bool randomSeed;
    public List<RoomTile> rooms;
    public int seed;
    // Start is called before the first frame update
    void Start()
    {

        if(randomSeed)
            seed = Random.Range(-100000000,100000000);
        Random.InitState(seed);
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Init()
    {
        GameObject curr = SpawnRoom(new Vector3(0f, 0f, 0f), Quaternion.identity, true, 0);
        Transform connectP;
        for (int i =0; i< mapLength;++i)
        {
            connectP = curr.GetComponent<RoomTile>().getConnect();
            //Debug.Log("currP: " + connectP.name + " " + connectP.position);
            curr = SpawnRoom(connectP.position, connectP.rotation, true, 2);
        }
        connectP = curr.GetComponent<RoomTile>().getConnect();
        curr = SpawnRoom(connectP.position, connectP.rotation, true, 1);

    }

    //type 0 = start area
    //type 1 = end area
    //type 2 = random
    private GameObject SpawnRoom(Vector3 vectPos, Quaternion quatPos, bool needS, int type)
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
                int index = Random.Range(0, Tiles.Length);
                tempTile = Tiles[index];
                break;
        }
        GameObject tempRT = Instantiate(roomTile, vectPos, quatPos);
        tempRT.GetComponent<RoomTile>().setVars(vectPos, needS, tempTile, this);
        tempRT.GetComponent<RoomTile>().Init();
        return tempRT;
        
    }
}
