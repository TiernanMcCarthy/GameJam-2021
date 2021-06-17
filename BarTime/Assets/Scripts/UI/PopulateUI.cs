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
    [Header("Sliders")]
    [SerializeField] Slider strSlider;
    [SerializeField] Slider spdSlider;
    [SerializeField] Slider intSlider;
    [SerializeField] Slider chrSlider;

    [SerializeField] Image happinessFace;
    [SerializeField] Image generosityFace;

    [SerializeField] Sprite[] happySprites;
    [SerializeField] Sprite[] genSprites;

    void Start()
    {
        thisPunter = GetComponentInChildren<Punter>();
    }

    // Update is called once per frame
    void Update()
    {
        strSlider.value = thisPunter.Strength;
        spdSlider.value = thisPunter.SpeedCheese;
        intSlider.value = thisPunter.Intelligence;
        chrSlider.value = thisPunter.Charisma;
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
    }
    public void HideUI()
    {
        isOn = !isOn;
        canvas.SetActive(isOn);
        if(isOn)
        {
           // button.GetComponent<RectTransform>().localPosition = new Vector3(0.7f, 2.3f, 0);
        }
        else
        {
            //button.GetComponent<RectTransform>().localPosition = new Vector3(0.7f, -2, 0);
        }
    }
}
