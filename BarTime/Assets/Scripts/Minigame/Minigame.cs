using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minigame : MonoBehaviour
{
    //will be referenced as a variable for each cheese stack
    //NEED TO MAKE A "CAN PLAY" VARIABLE SO THAT THE PLAYER CAN'T KEEP PLAYING AFTER FAILING
    //ALSO NEED TO RESET THE ARROWS TO BEING A WHITE COLOUR AS IT CURRENTLY STAYS GREEN
    public List<KeyCode> KeySequence;

    [SerializeField]GameObject canvas;
    [SerializeField] CheeseStack thisStack;
    [SerializeField] Character matthewMcCarter;
    [Header("Arrow Sprites")]
    [SerializeField] Sprite Sprite_UP;
    [SerializeField] Sprite Sprite_DOWN;
    [SerializeField] Sprite Sprite_LEFT;
    [SerializeField] Sprite Sprite_RIGHT;

    [Header("UI components")] //the actual images on the canvas - will set their values to be equal to relevant arrows
    [SerializeField]Image[] Ui_Images;
    [SerializeField] TMPro.TextMeshProUGUI TimerText;
    bool isPlaying = false;
    bool canPlay = true;
    int currentArrow = 0;
    void Start()
    {
        KeySequence = new List<KeyCode>();
        GeneratePattern();
        
    }

    // Update is called once per frame
    void Update()
    {
        //code for actually playing the arrow game is stored here
        if(isPlaying)
        {
            
            Debug.Log("Press " + KeySequence[currentArrow]);
            if (Input.GetKeyDown(KeySequence[currentArrow]))
            {
                Ui_Images[currentArrow].color = Color.green;
                if (++currentArrow == KeySequence.Count)
                {
                    isPlaying = false;
                    currentArrow = 0;
                    TimerText.text = "DUB";
                    StartCoroutine(WonGame());
                    // sequence typed
                }
            }
            else if (Input.anyKeyDown)
            {
                Ui_Images[currentArrow].color = Color.red;
                currentArrow = 0;
                TimerText.text = "FAIL";
                isPlaying = false;
                StartCoroutine(WaitToStockCheese());
            }
        }
    }

    public void PlayGame()
    {
        if(canPlay)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (KeySequence[i])
                {
                    case KeyCode.LeftArrow:
                        Ui_Images[i].sprite = Sprite_LEFT;
                        Ui_Images[i].color = Color.white;
                        break;
                    case KeyCode.RightArrow:
                        Ui_Images[i].sprite = Sprite_RIGHT;
                        Ui_Images[i].color = Color.white;
                        break;
                    case KeyCode.UpArrow:
                        Ui_Images[i].sprite = Sprite_UP;
                        Ui_Images[i].color = Color.white;
                        break;
                    case KeyCode.DownArrow:
                        Ui_Images[i].sprite = Sprite_DOWN;
                        Ui_Images[i].color = Color.white;
                        break;
                }
            }
            canvas.SetActive(true);
            currentArrow = 0;
            matthewMcCarter.Speed = 0;
            StartCoroutine(OneSecDelay());
            //isPlaying = true;
            StartCoroutine(GameCountdown());
        }

    }
    void GeneratePattern()
    {
        //called at the start, will generate the pattern that sticks with this cheese stack for the whole game
        //will use a random int representing an arrow. 0 = left, 1 = down, 2 = right, 3 = up
        int[] lastUsed = new int[2] { 99, 99 }; //will be used to make sure that there aren't more than two in a row
        bool canEnd = false;
        for(int i = 0; i < 5; i++)
        {
            canEnd = false;
            while(!canEnd)
            {
                int temp = Random.Range(0, 4);
                Debug.Log("key temp = " + temp);
                if (temp == lastUsed[0] && temp == lastUsed[1])
                {
                    continue;
                }
                else
                {
                    lastUsed[1] = lastUsed[0];
                    lastUsed[0] = temp;
                    switch (temp)
                    {
                        case 0:
                            KeySequence.Add(KeyCode.LeftArrow);
                            Debug.Log("Added key " + KeyCode.LeftArrow.ToString());
                            canEnd = true;
                            break;
                        case 1:
                            KeySequence.Add(KeyCode.DownArrow);
                            Debug.Log("Added key " + KeyCode.DownArrow.ToString());
                            canEnd = true;
                            break;
                        case 2:
                            KeySequence.Add(KeyCode.RightArrow);
                            Debug.Log("Added key " + KeyCode.RightArrow.ToString());
                            canEnd = true;
                            break;
                        case 3:
                            KeySequence.Add(KeyCode.UpArrow);
                            Debug.Log("Added key " + KeyCode.UpArrow.ToString());
                            canEnd = true;
                            break;
                    }

                }
            }
      
        }
        //PlayGame();
       
    }

    IEnumerator GameCountdown()
    {
        yield return new WaitForSeconds(1);
        if (isPlaying)
        {
            TimerText.text = "3";
        }
        yield return new WaitForSeconds(1);
        if(isPlaying)
        {
            TimerText.text = "2";
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(1);
        if (isPlaying)
        {
            TimerText.text = "1";
        }
        else
        {
            yield break;
        }
        yield return new WaitForSeconds(1);
        if (isPlaying)
        {
            TimerText.text = "FAILED";
            isPlaying = false;
            StartCoroutine(WaitToStockCheese());
            yield break;
        }
        else
        {
            yield break;
        }
    }

    IEnumerator WaitToStockCheese()
    {
        matthewMcCarter.Speed = 5;
        canPlay = false;
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
        TimerText.text = "3";
        yield return new WaitForSeconds(7);
        thisStack.RestockCheese();
        canPlay = true;
       
    }
    IEnumerator WonGame()
    {
        matthewMcCarter.Speed = 5;
        canPlay = false;
        Debug.Log("cheese");
        thisStack.RestockCheese();
        yield return new WaitForSeconds(1);
        canvas.SetActive(false);
        canPlay = true;
        TimerText.text = "3";
    }

    IEnumerator OneSecDelay()
    {
        TimerText.text = "WAIT";
        yield return new WaitForSeconds(1);
        TimerText.text = "3";
        isPlaying = true;
    }
}
