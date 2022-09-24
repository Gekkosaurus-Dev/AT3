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

    public GameObject pacStudent;
    public Animator movementAnimator;
    public AudioSource soundEffects;
    public AudioClip step;

    // Start is called before the first frame update
    void Start()
    {
      pos.Add(new Vector3(1.5f, -0.5f, 0.0f));
      pos.Add(new Vector3(6.5f, -0.5f, 0.0f));
      pos.Add(new Vector3(6.5f, -4.5f, 0.0f));
      pos.Add(new Vector3(1.5f, -4.5f, 0.0f));
      arrayPos = 0;
      arrayPos2 = 1;
      pacStudent.transform.position = pos[arrayPos];
      startPos = pos[arrayPos];
      endPos = pos[arrayPos2];
      //startTime = Time.time;
      duration = 1.5f;
      playSound();
    }

    void playSound(){
      soundEffects.Play();
      Invoke("playSound", (step.length + 0.5f));
    }

    // Update is called once per frame
    void Update()
    {
      float distance = Vector3.Distance(pacStudent.transform.position, endPos);
      //Debug.Log("distance to point = " + distance);
      //Debug.Log("current position" + pacStudent.transform.position);
      //Debug.Log("end position" + endPos);
      if (distance > 0.01f){
        pacStudent.transform.position = Vector3.Lerp(startPos, endPos, (timeElapsed/duration));
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
        pacStudent.transform.position = pos[arrayPos];
        startPos = pos[arrayPos];
        endPos = pos[arrayPos2];
        timeElapsed = 0;
      }
    }
}
