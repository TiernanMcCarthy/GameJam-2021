using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopulateUI : MonoBehaviour
{
    Punter thisPunter;

    public GameObject canvas;
    bool isOn = true; //equal to whether this canvas is visible or not
    [SerializeField] Button button;
    [Header("Text Fields")]
    [SerializeField] TMP_Text int_Text;
    [SerializeField] TMP_Text tox_Text;
    [SerializeField] TMP_Text emp_Text;
    [SerializeField] TMP_Text gen_Text;


    void Start()
    {
        thisPunter = GetComponentInChildren<Punter>();
    }

    // Update is called once per frame
    void Update()
    {
        int_Text.text = thisPunter.Intelligence.ToString();
        tox_Text.text = thisPunter.Toxicity.ToString();
        emp_Text.text = thisPunter.Empathy.ToString();
        gen_Text.text = thisPunter.Generosity.ToString();
    }

    public void HideUI()
    {
        isOn = !isOn;
        canvas.SetActive(isOn);
        if(isOn)
        {
            button.GetComponent<RectTransform>().localPosition = new Vector3(0.7f, 2.3f, 0);
        }
        else
        {
            button.GetComponent<RectTransform>().localPosition = new Vector3(0.7f, -2, 0);
        }
    }
}
