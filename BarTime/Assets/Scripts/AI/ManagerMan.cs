using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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



    private void RandomisePunter(Punter Edit)
    {
        //Happiness
        Edit.Happiness += Random.Range(-2, 2);
        //Angriness
        Edit.Angriness += Random.Range(-2, 4);
        //Generosity
        Edit.Generosity += Random.Range(-5, 5);
        //Patience
        Edit.Patience += Random.Range(-2, 2);
        //Hunger
        Edit.Hunger += Random.Range(-2, 2.1f);




        int CheeseEffects = 0;


        if(Random.Range(0,1)==1)
        {
            Edit.Intelligence = 2;
        }

        //Cheese Moods
        //Intelligence + 2
        
        //Strength  +2
        //Speed Cheese
        // Charisfma






    }


    private void SpawnPrefab()
    {
        Punter Temp = Instantiate(Prefab, Spawns[Random.Range(0, Spawns.Count)].position,Quaternion.identity);

        int Case = Random.Range(0, 2);

        if(Case==0)
        {
            Temp.Team = false;
        }
        else
        {
            Temp.Team = true;
        }

        Temp.MoveToLocation = Spawns[0].position; //Address

        punters.Add(Temp);


    }


    private void SpawnPunters(int Remainder)
    {


       
        for(int i=NumberOfPunters; i<MaximumPunters; i++)
        {
            Remainder -= 1;
            SpawnPrefab();
            NumberOfPunters++;
            if (Remainder == 0) //Stop spawning them
            {
                break;
            }
        }


    }


    private void CheckStateOfPunters()
    {
        if(NumberOfPunters<MaximumPunters && Time.time-LastWaveTime>=TimeBetweenWaves) //If there is room to spawn punters
        {

            SpawnPunters(MaximumPunters - NumberOfPunters);
            LastWaveTime = Time.time;

        }
    }


    void CheckPuntersList()
    {
        punters = new List<Punter>();
        Punter[] temp = FindObjectsOfType<Punter>();

        foreach(Punter p in temp)
        {
            punters.Add(p);
        }
        NumberOfPunters = punters.Count;
    }

    public void Start()
    {
        SpawnPrefab();
    }

    public void FixedUpdate()
    {
        CheckPuntersList();
        CheckStateOfPunters();
        if(Input.GetKeyDown("a"))
        {
            //SpawnPrefab();
        }
    }

}
