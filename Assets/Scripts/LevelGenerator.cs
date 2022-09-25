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
        int rotation1 = 0;
        int rotation2 = 0;
        int rotation3 = 0;
        int rotation4 = 0;

        int aboveTile = -1;
        int belowTile = -1;
        int leftTile = -1;
        int rightTile = -1;

        //checking surrounding tiles
        if (row == 0 && column == 0){
          rotation1 = 180;
          rotation2 = rotation1 - 90;//90;
          rotation3 = rotation1 - 270;//-90;
          rotation4 = rotation1 - 180; //0;
        }
        else {
          if (row == 0){ //top row
            belowTile = levelMap[row + 1, column] - 1;
          }
          else if (row == 14){
            aboveTile = levelMap[row - 1, column] - 1;
          }
          else{
            aboveTile = levelMap[row - 1, column] - 1;
            belowTile = levelMap[row + 1, column] - 1;
          }

          if (column == 0){ //top row
            rightTile = levelMap[row, column + 1] - 1;
          }
          else if (column == 13){
            leftTile = levelMap[row, column - 1] - 1;
          }
          else{
            rightTile = levelMap[row, column + 1] - 1;
            leftTile = levelMap[row, column - 1] - 1;
          }


            if (tile == 0){
              if ( (rightTile == 0) || (rightTile == 1) || (rightTile == 6) ){
                if ( (aboveTile == 0) || (aboveTile == 1) || (aboveTile == 6) ){
                  rotation1 = 270;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
                else if ( (belowTile == 0) || (belowTile == 1) || (belowTile == 6) ){
                  rotation1 = 180;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
              }
              else if ( (leftTile == 0) || (leftTile == 1) || (leftTile == 6) ){
                if ( (aboveTile == 0) || (aboveTile == 1) || (aboveTile == 6) ){
                  rotation1 = 0;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
                else if ( (belowTile == 0) || (belowTile == 1) || (belowTile == 6) ){
                  rotation1 = 90;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
              }
            }

            if (tile == 1){
              if ( ((aboveTile == 0) || (aboveTile == 1) || (aboveTile == 6)) && ((belowTile == 0) || (belowTile == 1) || (belowTile == 6)) ){
                rotation1 = 90;
                rotation2 = 90;
                rotation3 = 90;
                rotation4 = 90;
              }
              else if( ((aboveTile == 0) || (aboveTile == 1) || (aboveTile == 6)) && (rightTile != 0) && (rightTile != 1) && (rightTile != 6) ){
                rotation1 = 90;
                rotation2 = 90;
                rotation3 = 90;
                rotation4 = 90;
              }
            }

            if (tile == 2){
              if ( (rightTile == 2) || (rightTile == 3) || (rightTile == 6) ){
                if ( (aboveTile == 2) || (aboveTile == 3) || (aboveTile == 6) ){
                  rotation1 = 270;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
                else if ( (belowTile == 2) || (belowTile == 3) || (belowTile == 6) ){
                  rotation1 = 180;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
              }
              else if ( (leftTile == 2) || (leftTile == 3) || (leftTile == 6) ){
                if ( (aboveTile == 2) || (aboveTile == 3) || (aboveTile == 6) ){
                  rotation1 = 0;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
                else if ( (belowTile == 2) || (belowTile == 3) || (belowTile == 6) ){
                  rotation1 = 90;
                  rotation3 = rotation1 - 90;//90;
                  rotation2 = rotation1 - 270;//-90;
                  rotation4 = rotation1 - 180; //0;
                }
              }
            }

            if (tile == 3){
              if ( ((aboveTile == 2) || (aboveTile == 3) || (aboveTile == 6)) && ((belowTile == 2) || (belowTile == 3) || (belowTile == 6)) ){
                rotation1 = 90;
                rotation2 = 90;
                rotation3 = 90;
                rotation4 = 90;
              }
              else if( ((aboveTile == 2) || (aboveTile == 3) || (aboveTile == 6)) && (rightTile != 2) && (rightTile != 3) && (rightTile != 6) ){
                rotation1 = 90;
                rotation2 = 90;
                rotation3 = 90;
                rotation4 = 90;
              }
            }

            if (tile == 6){

            }

          }


        Instantiate(tiles[tile], new Vector3(column, row*(-1), 0), Quaternion.Euler(new Vector3(0, 0, rotation1))); //top left quadrant
        Instantiate(tiles[tile], new Vector3((27-column), row*(-1), 0), Quaternion.Euler(new Vector3(0, 0, rotation2))); //top right quadrant
        Instantiate(tiles[tile], new Vector3((column),((-28) - (row*(-1))), 0), Quaternion.Euler(new Vector3(0, 0, rotation3))); //bottom left
        Instantiate(tiles[tile], new Vector3((27-column), ((-28) - (row*(-1))), 0), Quaternion.Euler(new Vector3(0, 0, rotation4))); //bottom right
      }
    }



    // Update is called once per frame
    void Update()
    {

    }
}
