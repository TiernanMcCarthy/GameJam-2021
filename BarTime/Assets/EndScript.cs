using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{

    public ManagerMan Scene;

    public TMPro.TextMeshProUGUI Money;

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Start()
    {
        Scene = FindObjectOfType<ManagerMan>();

        Money.text = "Tips Recieved: " +Scene.TotalMoney.ToString();
        
    }


}
