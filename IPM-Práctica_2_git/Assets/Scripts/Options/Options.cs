using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    private string Escena;

    public void Start()
    {
        if (Main_Menu.Escena != null)
        {
            Escena = Main_Menu.Escena;
            Main_Menu.Escena = null;
        }
    }
 
    public void Back()
    {
        SceneManager.LoadScene(Escena, LoadSceneMode.Single);
    }

}
