using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public float MoneyAmount;

    public Chair Owner;

    public ManagerMan ManagerMan;

    // Start is called before the first frame update
    void Start()
    {
        ManagerMan = FindObjectOfType<ManagerMan>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            
            ManagerMan.TotalMoney += MoneyAmount;

            Destroy(gameObject);
        }
    }
}
