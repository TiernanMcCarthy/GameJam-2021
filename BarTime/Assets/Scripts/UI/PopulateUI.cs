using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateUI : MonoBehaviour
{
    Punter thisPunter;

    public GameObject canvas;
    bool isOn = false; //equal to whether this canvas is visible or not
    bool NeedsSecondCheese = false;
    [Header("Sliders")]
    //[SerializeField] Slider strSlider;
    //[SerializeField] Slider spdSlider;
    //[SerializeField] Slider intSlider;
    //[SerializeField] Slider chrSlider;

    [SerializeField] Image happinessFace;
    [SerializeField] Image generosityFace;

    [SerializeField] Image CheeseDesireUI;
    [SerializeField] Image CheeseDesireUI_Secondary; //for if it is one of the sick freaks that needs TWO cheeses 
    [SerializeField] Sprite[] happySprites;
    [SerializeField] Sprite[] genSprites;
    [SerializeField] Sprite[] cheeseSprites; //0 = strength, 1 = int, 2 = speed, 3 = char
    [SerializeField] Sprite DefaultSprite;
 
    void Start()
    {
        thisPunter = GetComponentInChildren<Punter>();
    }

    // Update is called once per frame
    void Update()
    {
        //strSlider.value = thisPunter.Strength;
        //spdSlider.value = thisPunter.SpeedCheese;
        //intSlider.value = thisPunter.Intelligence;
        //chrSlider.value = thisPunter.Charisma;
    }

    private void FixedUpdate()
    {
        if(thisPunter.Happiness < 5)
        {
            happinessFace.sprite = happySprites[0];
        }
        else if (thisPunter.Happiness > 4 && thisPunter.Happiness < 9)
        {
            happinessFace.sprite = happySprites[1];
        }
        else
        {
            happinessFace.sprite = happySprites[2];
        }

        if (thisPunter.Generosity < 9)
        {
            generosityFace.sprite = genSprites[0];
        }
        else if (thisPunter.Happiness > 8 && thisPunter.Happiness < 13)
        {
            generosityFace.sprite = genSprites[1];
        }
        else
        {
            generosityFace.sprite = genSprites[2];
        }

        if(thisPunter.Strength < 10)
        {
            CheeseDesireUI.sprite = cheeseSprites[0];
            //NeedsSecondCheese = true;
        }
        if (thisPunter.Intelligence < 10)
        {
            if(CheeseDesireUI.sprite != DefaultSprite && CheeseDesireUI.sprite != cheeseSprites[1])
            {
                CheeseDesireUI_Secondary.sprite = cheeseSprites[1];
            }
            else
            {
                CheeseDesireUI.sprite = cheeseSprites[1];
                //NeedsSecondCheese = true;
            }           
        }
        if (thisPunter.SpeedCheese < 10)
        {
            if (CheeseDesireUI.sprite != DefaultSprite && CheeseDesireUI.sprite != cheeseSprites[2])
            {
                CheeseDesireUI_Secondary.sprite = cheeseSprites[2];
            }
            else
            {
                CheeseDesireUI.sprite = cheeseSprites[2];
                //NeedsSecondCheese = true;
            }
        }
        if (thisPunter.Charisma < 10)
        {
            if (CheeseDesireUI.sprite != DefaultSprite && CheeseDesireUI.sprite != cheeseSprites[3])
            {
                CheeseDesireUI_Secondary.sprite = cheeseSprites[3];
            }
            else
            {
                CheeseDesireUI.sprite = cheeseSprites[3];
                //NeedsSecondCheese = true;
            }
        }
    }
    public void HideUI()
    {
        isOn = !isOn;
        canvas.SetActive(isOn);
        Debug.Log("Look at me I'm a crazy old punter... I am hiding my epic UI :/");
    }
}
