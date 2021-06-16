using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrazyAssRedBars : MonoBehaviour
{
    public Slider thisSlider;
    public Image fillImage;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (thisSlider.value < thisSlider.maxValue)
        {
            fillImage.color = Color.red;
        }
        else
        {
            fillImage.color = Color.green;
        }
    }

    public void OnValueChanged()
    {
        //Debug.Log("haha lol XD");
        //if (thisSlider.value < thisSlider.maxValue)
        //{
        //    fillImage.color = Color.red;
        //}
        //else
        //{
        //    fillImage.color = Color.green;
        //}
    }
}
