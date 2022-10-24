using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private List<Vector3> pos = new List<Vector3>();
    private int arrayPos;
    private int arrayPos2;
    //private float startTime;
    private float duration;
    private float timeElapsed;
    private Vector3 startPos;
    private Vector3 endPos;
    private bool posLock;

    public GameObject obj;
    public Animator movementAnimator;
    public AudioSource soundEffects;
    public AudioClip step;

    // Start is called before the first frame update
    void Start()
    {
      pos.Add(new Vector3(1.0f, -1.0f, 0.0f));
      pos.Add(new Vector3(6.0f, -1.0f, 0.0f));
      pos.Add(new Vector3(6.0f, -5.0f, 0.0f));
      pos.Add(new Vector3(1.0f, -5.0f, 0.0f));
      arrayPos = 0;
      arrayPos2 = 1;
      obj.transform.position = pos[arrayPos];
      startPos = pos[arrayPos];
      endPos = pos[arrayPos2];
      //startTime = Time.time;
      duration = 2.0f;
      playSound();

      movementAnimator.SetInteger("Direction",arrayPos2);
    }

    void playSound(){
      soundEffects.Play();
      Invoke("playSound", (step.length + 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
      float distance = Vector3.Distance(obj.transform.position, endPos);
        //Debug.Log("distance to point = " + distance);
        //Debug.Log("current position" + obj.transform.position);
        //Debug.Log("end position" + endPos);
        if (distance > 0.01f){
        obj.transform.position = Vector3.Lerp(startPos, endPos, (timeElapsed/duration));
        timeElapsed += Time.deltaTime;
      }
      else if ((distance <= 0.01f)){
        //Debug.Log("point reached");
        arrayPos ++;
        arrayPos2 ++;
        if (arrayPos > 3){
          arrayPos = 0;
        }
        if (arrayPos2 > 3){
          arrayPos2 = 0;
        }
        obj.transform.position = pos[arrayPos];
        startPos = pos[arrayPos];
        endPos = pos[arrayPos2];
        timeElapsed = 0;
        movementAnimator.SetInteger("Direction",arrayPos2);
      }
    }
}
