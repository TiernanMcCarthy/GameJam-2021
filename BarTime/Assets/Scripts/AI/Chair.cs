using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : StateObject
{

    public bool Occupied;

    public Table Owner;

    public Money CashPrefab;



    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    public void DropMoney(float Amount)
    {
        Money Temp = Instantiate(CashPrefab, transform.position + new Vector3(0,0.2f,0), CashPrefab.transform.rotation);
        Temp.MoneyAmount = Amount;
    }

    public override bool Move()
    {
        throw new System.NotImplementedException();
    }
}
