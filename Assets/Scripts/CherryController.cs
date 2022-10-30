using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    /*This script implements the spawning and movement of the bonus cherry sprite created in the previous assessment.
      o The bonus cherry should spawn once every 10 seconds.

      o It should be instantiated at a random location just outside of the camera view on any side of the level.
          The starting location should be different every time.

      o It should move in a straight line, via linear lerping, from one side of the screen to the other, passing through
          the center point of the level and ignoring collisions with walls, ghosts, and pellets.

      o If the cherry reaches the other side of the level, outside of camera view, destroy it.*/


    // Start is called before the first frame update

    public GameObject cherry;
    private int side;
    private Vector3 position;
    private float speed;
    private float endX;
    private float endY;
    private float distanceTo;
    private Vector3 endPos;
    private GameObject newCherry;

    void Start()
    {
      speed = 5.0f;
      InvokeRepeating("SpawnCherry", 1.0f, 10.0f);
    }

    void SpawnCherry(){
      side = Random.Range(1,5);
      if (side == 1){ //left
        //Debug.Log("spawned on left");
        position = new Vector3(-16.0f, Random.Range(-31.0f, 3.0f), 0.0f);
      }
      else if (side == 2){ //right
        //Debug.Log("spawned on right");
        position = new Vector3(43.0f, Random.Range(-31.0f, 3.0f), 0.0f);
      }
      else if (side == 3){ //top
        //Debug.Log("spawned on top");
        position = new Vector3(Random.Range(-16.0f, 43.0f), 3.0f, 0.0f);
      }
      else{ //bottom
        //Debug.Log("spawned on bottom");
        position = new Vector3(Random.Range(-16.0f, 43.0f), -31.0f, 0.0f);
      }
      newCherry = Instantiate(cherry, position, Quaternion.Euler(new Vector3(0, 0, 0)));
      //center = 13.5f, -14.0f, 0.0f
      endX = ((13.5f - newCherry.transform.position.x) * 2);
      endY = ((14.0f - newCherry.transform.position.y) * 2);
      endPos = new Vector3(endX, endY, 0.0f);

    }

    void Update(){
      if (newCherry != null){
        distanceTo = Vector3.Distance(newCherry.transform.position, endPos);
        Debug.Log("targetPos = " + endPos);
      if (distanceTo > 0.01f){
        newCherry.transform.position = Vector3.MoveTowards(newCherry.transform.position, endPos, Time.deltaTime * speed);
      }
    }
  }
}
