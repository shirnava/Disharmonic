using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvManager : MonoBehaviour
{
    public static InvManager Instance;
    public List<ItemData> Items = new List<ItemData>();

    public Transform ItemContent;
    public GameObject InventoryItem;
    [SerializeField] GameObject NoItemsText;
    public bool hasWonFirstDay, hasWonSecondDay, hasWonThirdDay = false;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        
    }

    public void Add(ItemData item)
    {
        Items.Add(item);
    }

    // Update is called once per frame
    public void ListItems()
    {

        if(Items.Count==0)
        {
            NoItemsText.gameObject.SetActive(true);
        }
        else
        {
            NoItemsText.gameObject.SetActive(false);
        }
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem,ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<Text>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.displayName;
            itemIcon.sprite = item.icon;
        }
    }
}
