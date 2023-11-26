using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMakeupLoad : MonoBehaviour
{
    public Sprite makeup1;
    public Sprite makeup2;
    public Sprite makeup3;
    private int makeup;
    private string makeupKey = "PlayerMakeup";
    private Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();

        makeup = PlayerPrefs.GetInt(makeupKey);
        imageComponent.sprite = makeup1;
        switch (makeup)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                imageComponent.sprite = makeup1;
                break;
            case 2:
                imageComponent.sprite = makeup2;
                break;
            case 3:
                imageComponent.sprite = makeup3;
                break;
        }
    }

    public void ChangeMakeup(int newMakeup)
    {
        PlayerPrefs.SetInt(makeupKey, newMakeup);
    }
}
