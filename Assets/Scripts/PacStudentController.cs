using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System;

public class PacStudentController : MonoBehaviour
{

    public GameObject pacStudent;

    private Vector3 currentPos;
    private Vector3 checkPos;
    private Vector3 targetPos;
    private KeyCode lastInput;
    private KeyCode currentInput;
    private float speed;

    public Tilemap tileMap;


    //current position = pacStudent.transform.position;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(1.0f, -1.0f, 0.0f);
        targetPos = new Vector3(1.0f, -1.0f, 0.0f);
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
          lastInput = KeyCode.W;
        }
        if (Input.GetKeyDown(KeyCode.A)){
          lastInput = KeyCode.A;
        }
        if (Input.GetKeyDown(KeyCode.S)){
          lastInput = KeyCode.S;
        }
        if (Input.GetKeyDown(KeyCode.D)){
          lastInput = KeyCode.D;
        }

        doMovement();
        //Debug.Log(lastInput);

    }

    private void doMovement(){
      if ((lastInput == KeyCode.W) || (lastInput == KeyCode.A) || (lastInput == KeyCode.S) || (lastInput == KeyCode.D)){

        float distance = Vector3.Distance(pacStudent.transform.position, targetPos);
        if (distance > 0.01f){
          pacStudent.transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
        }

        else if ((distance <= 0.01f)){
          pacStudent.transform.position = targetPos;
          currentPos = transform.position;
          if (tryMovement(lastInput) == true){
            targetPos = checkPos;
            currentInput = lastInput;
          }
          else if (tryMovement (currentInput) == true){
            targetPos = checkPos;
          }
        }

      }

    }

  private bool tryMovement( KeyCode input ){
    if (input == KeyCode.W){
      checkPos = new Vector3(currentPos.x, currentPos.y + 1.0f, currentPos.z);
      return(checkPosition(checkPos));
    }
    else if (input == KeyCode.A){
      checkPos = new Vector3(currentPos.x - 1.0f, currentPos.y, currentPos.z);
      return(checkPosition(checkPos));
    }
    else if (input == KeyCode.S){
      checkPos = new Vector3(currentPos.x, currentPos.y - 1.0f, currentPos.z);
      return(checkPosition(checkPos));
    }
    else if (input == KeyCode.D){
      checkPos = new Vector3(currentPos.x + 1.0f, currentPos.y, currentPos.z);
      return(checkPosition(checkPos));
    }
    else{
      return false;
    }
  }


  private bool checkPosition(Vector3 position){
    //Debug.Log(tileMap.GetTile(Vector3Int.FloorToInt(position)).name); //converts the Vector3 position variable to Vector3Int
    TileBase tileAtPosition = tileMap.GetTile(Vector3Int.FloorToInt(position));
    if (tileAtPosition != null){
      if( (tileAtPosition.name == "BACKGROUNDTILESFINAL_0") || (tileAtPosition.name == "BACKGROUNDTILESFINAL_1") || (tileAtPosition.name == "BACKGROUNDTILESFINAL_2") || (tileAtPosition.name == "BACKGROUNDTILESFINAL_3") || (tileAtPosition.name == "BACKGROUNDTILESFINAL_4") ){
        return false;
      }
      else if ((tileAtPosition.name == "BACKGROUNDTILESFINAL_5")){
        return true;
      }
      else{
        return true;
      }
    }
    else {
      return true;
    }

  }


}
