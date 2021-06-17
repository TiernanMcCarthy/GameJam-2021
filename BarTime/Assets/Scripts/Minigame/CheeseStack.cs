using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheeseStack : MonoBehaviour
{
    Minigame thisGame;

    public int remainingCheese;
    public Cheese thisCheese;
    [SerializeField] int cheeseDecider; //cheat way of setting which cheese this stack will use from the editor - 0 = strength / 1 = speed / 2 = smart / 3 = charisma
    public Character player;
    [SerializeField] TMPro.TextMeshProUGUI thisText;
    [SerializeField] GameObject[] ModelStack;
    void Start()
    {
        //SetCheeseType();
        thisGame = GetComponent<Minigame>();
        RestockCheese();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void GiveCheese()
    {
        if(remainingCheese > 0)
        {
           // ModelStack[remainingCheese - 1].SetActive(false);
            remainingCheese--;
            thisText.text = remainingCheese.ToString();
            Cheese temp = Instantiate(thisCheese);
            player.CurrentCheese = temp;
        }
        else
        {
            thisGame.PlayGame();
        }
    }
    public void RestockCheese()
    {
        remainingCheese = 4;
        thisText.text = remainingCheese.ToString();
        //for (int i = 0; i < 4; i++)
        //{
        //    //ModelStack[i].SetActive(true);
        //}
    }

    void SetCheeseType()
    {
        switch(cheeseDecider)
        {
            case 0:
                //thisCheese.StrengthEffect = 2;
                break;
            case 1:
                //thisCheese.SpeedEffect = 2;
                break;
            case 2:
                //thisCheese.IntelliEffect = 2;
                break;
            case 3:
                //thisCheese.CharismaEffect = 2;
                break;

        }
    }
}
