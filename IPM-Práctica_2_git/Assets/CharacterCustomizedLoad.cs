using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustomizedLoad : MonoBehaviour
{
    public Sprite set1;
    public Sprite set2;
    public Sprite set3;
    private int set;
    private string setKey = "PlayerSet";
    private Image imageComponent;

    // Start is called before the first frame update
    void Start()
    {
        imageComponent = GetComponent<Image>();

        set = PlayerPrefs.GetInt(setKey);

        if (set == 0)
        {
            set = 1;
            PlayerPrefs.SetInt(setKey, set);
        }

        switch (set)
        {
            case 1:
                imageComponent.sprite = set1;
                break;
            case 2:
                imageComponent.sprite = set2;
                break;
            case 3:
                imageComponent.sprite = set3;
                break;
        }
    }

    public void ChangeSet(int newSet)
    {
        PlayerPrefs.SetInt(setKey, newSet);
    }

}
