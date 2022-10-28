using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadFirstLevel()
    {
        //DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(1);
    }

    public void LoadSecondLevel()
    {
        //DontDestroyOnLoad(this);
        SceneManager.LoadSceneAsync(2);
    }
}
