using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class Player
{
private List<string> inventory = new List<string>();
public Player(List<string> items)
{
    inventory = items;
}
public List<string> GetItems()
{
    return inventory;
}



}
class Item
{
    public string Name;

    public Item(string name)
    {
        Name = name;
    }
}
class PartyMem
{
    public List<Item> Items = new List<Item>();

    public PartyMem(Item input)
    {
        Items.Add(input);
    }
}

 class CoolMan
{
    public List<string> LocalItems = new List<string>();
    public void AddMeHere(string Items)
    {
        LocalItems.Add(Items);
    }

}
public class EpicScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Jack has a potion and a sword
        var jacksItems = new List<string>();
        jacksItems.Add("potion");
        jacksItems.Add("sword");
        var jack = new Player(jacksItems);
        // Jill has all the same items as Jack, plus a helmet
        var jillsItems = jack.GetItems();
        jillsItems.Add("helmet");
        var jill = new Player(jillsItems);

        Debug.Log("EPIC GAMING");

        Item bob = new Item("Epic guy");
        Item bob2 = new Item("Epic dude");
        Item bob3 = new Item("Epic woman");




        List<PartyMem> Party = new List<PartyMem>();


        Party.Add(new PartyMem(bob));
        Party.Add(new PartyMem(bob2));
        Party.Add(new PartyMem(bob));
        Party.Add(new PartyMem(bob3));
        Party.Add(new PartyMem(bob2));
        Party.Add(new PartyMem(bob));
        Party.Add(new PartyMem(bob2));
        Party.Add(new PartyMem(bob));
        Party.Add(new PartyMem(bob3));
        Party.Add(new PartyMem(bob2));

        List<CoolMan> temp = new List<CoolMan>();
        temp.Add(new CoolMan());
        temp.Add(new CoolMan());
        temp.Add(new CoolMan());
        temp.Add(new CoolMan());
        temp.Add(new CoolMan());
        var partyItems = new List<string>();
        int i = 0;
        for (int partyMember = 0; partyMember < 5; ++partyMember)
        {
            for (int item = 0; item < 10; ++item)
            {
                var itemName = Party[partyMember].Items[item].Name;
                partyItems.Add(itemName);
            }
            //DisplayHeader("Items for member {0}:", partyMember);
            //DisplayItems(partyItems);
            temp[i].LocalItems = partyItems;
            i++;
        }


        Debug.Log("HSFhsafhsa");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
