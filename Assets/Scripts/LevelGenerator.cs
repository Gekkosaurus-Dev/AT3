using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    public GameObject tileMap;

    // public GameObject OutsideCorner; //1
    // public GameObject OutsideWall; //2
    // public GameObject InsideCorner; //3
    // public GameObject InsideWall; //4
    // public GameObject TJuction; //7
    // public GameObject Pellet; //5

    public List<GameObject> tiles;

    int[,] levelMap =
    {
      {1,2,2,2,2,2,2,2,2,2,2,2,2,7}, //0
      {2,5,5,5,5,5,5,5,5,5,5,5,5,4}, //1
      {2,5,3,4,4,3,5,3,4,4,4,3,5,4}, //2
      {2,6,4,0,0,4,5,4,0,0,0,4,5,4}, //3
      {2,5,3,4,4,3,5,3,4,4,4,3,5,3}, //4
      {2,5,5,5,5,5,5,5,5,5,5,5,5,5}, //5
      {2,5,3,4,4,3,5,3,3,5,3,4,4,4}, //6
      {2,5,3,4,4,3,5,4,4,5,3,4,4,3}, //7
      {2,5,5,5,5,5,5,4,4,5,5,5,5,4}, //8
      {1,2,2,2,2,1,5,4,3,4,4,3,0,4}, //9
      {0,0,0,0,0,2,5,4,3,4,4,3,0,3}, //10
      {0,0,0,0,0,2,5,4,4,0,0,0,0,0}, //11
      {0,0,0,0,0,2,5,4,4,0,3,4,4,0}, //12
      {2,2,2,2,2,1,5,3,3,0,4,0,0,0}, //13
      {0,0,0,0,0,0,5,0,0,0,4,0,0,0}, //14
    };



    // Start is called before the first frame update
    void Start()
    {
        Destroy(tileMap);
        //Debug.Log(levelMap[0,0]);

        for(int i = 0; i < 15; i++){
          for(int j = 0; j < 14; j++){
            Debug.Log("spawning tile from" + i + "," + j);
            SpawnTile(i,j);
          }
        }

    }

    void SpawnTile(int row, int column){
      int tile = levelMap[row, column];
      if (tile != 0){
        tile = tile - 1;
        Instantiate(tiles[tile], new Vector3(column, row*(-1), 0), Quaternion.Euler(new Vector3(0, 0, 0))); //top left quadrant
        Instantiate(tiles[tile], new Vector3((27-column), row*(-1), 0), Quaternion.Euler(new Vector3(0, 0, 0))); //top right quadrant
        Instantiate(tiles[tile], new Vector3((column),((-28) - (row*(-1))), 0), Quaternion.Euler(new Vector3(0, 0, 0))); //bottom left
        Instantiate(tiles[tile], new Vector3((27-column), ((-28) - (row*(-1))), 0), Quaternion.Euler(new Vector3(0, 0, 0))); //bottom right
      }
    }


    // Update is called once per frame
    void Update()
    {

    }
}
