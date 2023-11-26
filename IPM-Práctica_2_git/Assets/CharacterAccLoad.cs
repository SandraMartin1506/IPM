using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAccLoad : MonoBehaviour
{
    public Sprite acc1;
    public Sprite acc2;
    public Sprite acc3;
    private int acc;
    private string accKey = "PlayerAcc";
    private Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();

        acc = PlayerPrefs.GetInt(accKey);
        imageComponent.sprite = acc1;
        switch (acc)
        {
            case 0:
                gameObject.SetActive(false);
                break;
            case 1:
                imageComponent.sprite = acc1;
                break;
            case 2:
                imageComponent.sprite = acc2;
                break;
            case 3:
                imageComponent.sprite = acc3;
                break;
        }
    }

    public void ChangeAcc(int newAcc)
    {
        PlayerPrefs.SetInt(accKey, newAcc);
    }
}
