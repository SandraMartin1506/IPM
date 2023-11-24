using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    public bool nextScene;
    public int sceneIndex;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (nextScene)
        {
            changeScene(sceneIndex);
        }
    }
   public void changeScene(int index)
    {
       
            SceneManager.LoadScene(index);
        
    }
}
