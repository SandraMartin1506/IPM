using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingButtons : MonoBehaviour
{
 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) //Cambiar este if por cada vez que se triggerea un evento en la historia
            ChoiceScreen.Show("Hola guapa", "pasas mucho", "por aquí");
        
    }
}
