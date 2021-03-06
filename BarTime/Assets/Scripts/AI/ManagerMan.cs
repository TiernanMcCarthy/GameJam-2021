using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
public class ManagerMan : MonoBehaviour
{
    public List<Punter> punters;

    public int NumberOfPunters = 0;

    public Exit Exit;

    public float TotalMoney;

    public Punter Prefab;


    public int MaximumPunters = 20;

    public int WaveSize = 5;

    public float TimeBetweenWaves = 15;

    private float LastWaveTime = 0;


    public List<Transform> Spawns;

    public List<Transform> MoveToLocations;


    public TMPro.TextMeshProUGUI TimeGaming;

    public TMPro.TextMeshProUGUI MoneyGaming;

    public float StartTime = 0;

    public float RunTime = 300;

    bool Loaded = false;

    private void RandomisePunter(ref Punter Edit)
    {
        //Happiness
        Edit.Happiness += Random.Range(-2, 2);
        //Angriness
        Edit.Angriness += Random.Range(-2, 5);
        //Generosity
        Edit.Generosity += Random.Range(-5, 5);
        //Patience
        Edit.Patience += Random.Range(-2, 2);
        //Hunger
        Edit.Hunger += Random.Range(-2, 2.1f);

        Edit.NumberOfCheeseToSatisfy = 1;

        int MaxCheese = Random.Range(1, 3);

        int CheeseEffects = 0;

        Edit.Charisma = 10;
        Edit.Intelligence = 10;
        Edit.Strength = 10;
        Edit.SpeedCheese = 10;

        Edit.temp = this;

        if (Random.Range(0, 2) == 1 && CheeseEffects < MaxCheese)
        {
            Edit.Intelligence = Random.Range(1, 5);

            Edit.Charisma = 10;
            Edit.Strength = 10;
            Edit.SpeedCheese = 10;

            CheeseEffects += 1;

        }

        if (Random.Range(0, 2) == 1 && CheeseEffects < MaxCheese)
        {
            Edit.Strength = Random.Range(1, 5);
            Edit.Charisma = 10;
            Edit.Intelligence = 10;
            Edit.SpeedCheese = 10;

            CheeseEffects += 1;
        }

        if (Random.Range(0, 2) == 1 && CheeseEffects < MaxCheese)
        {
            Edit.SpeedCheese = Random.Range(1, 5);

            Edit.Charisma = 10;
            Edit.Intelligence = 10;
            Edit.Strength = 10;

            CheeseEffects += 1;
        }

        if (Random.Range(0, 2) == 1 && CheeseEffects < MaxCheese)
        {
            Edit.Charisma = Random.Range(1, 5);
            Edit.SpeedCheese = 10;
            Edit.Intelligence = 10;
            Edit.Strength = 10;
        }


        //DUM DUMB DUMB I AM INCREDIBLY LAZY

        if(Edit.SpeedCheese==10 && Edit.Intelligence==10 && Edit.Strength==10 && Edit.Charisma==10)
        {

            Edit.SpeedCheese = Random.Range(1, 5);
            Edit.Intelligence = Random.Range(1, 5);
            Edit.NumberOfCheeseToSatisfy = 2;
        }


        //Cheese Moods
        //Intelligence + 2

        //Strength  +2
        //Speed Cheese
        // Charisfma






    }


    private void SpawnPrefab()
    {
        Punter Temp = Instantiate(Prefab, Spawns[Random.Range(0, Spawns.Count)].position, Quaternion.identity);

        int Case = Random.Range(0, 2);

        if (Case == 0)
        {
            Temp.Team = false;
        }
        else
        {
            Temp.Team = true;
        }

        Temp.MoveToLocation = Spawns[0].position; //Address
        RandomisePunter(ref Temp);
        punters.Add(Temp);


    }


    private void SpawnPunters(int Remainder)
    {
        for (int i = NumberOfPunters; i < MaximumPunters; i++)
        {
            Remainder -= 1;
            SpawnPrefab();
            NumberOfPunters++;
            if (Remainder == 0) //Stop spawning them
            {
                i = 999;
            }
        }


    }


    private void CheckStateOfPunters()
    {
        if (NumberOfPunters < MaximumPunters && Time.time - LastWaveTime >= TimeBetweenWaves) //If there is room to spawn punters
        {

            SpawnPunters(WaveSize);
            LastWaveTime = Time.time;

        }
    }


    void CheckPuntersList()
    {
        punters = new List<Punter>();
        Punter[] temp = FindObjectsOfType<Punter>();

        foreach (Punter p in temp)
        {
            punters.Add(p);
        }
        NumberOfPunters = punters.Count;
    }

    public void Start()
    {
        SpawnPrefab();
        StartTime = Time.time;
        DontDestroyOnLoad(this.gameObject);
    }

    public void FixedUpdate()
    {
        //CheckPuntersList();
        //CheckStateOfPunters();
        if (Input.GetKeyDown("a"))
        {
            //SpawnPrefab();
        }
        if (Loaded == false)
        {
            MoneyGaming.text = TotalMoney.ToString();
            TimeGaming.text = "Remaining: " + Mathf.RoundToInt(RunTime - (Time.time - StartTime)).ToString();
            CheckPuntersList();
            CheckStateOfPunters();
        }

        if(Time.time-StartTime>=RunTime && Loaded==false)
        {
            Loaded = true;
            transform.position += new Vector3(3333, 333, 3333);
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }



    }

    
    //MoneyGaming

}
