using System.Collections.Generic;
using UnityEngine;

public class hudManager : MonoBehaviour
{  
    private int startingItemDisplayIndex;
    private int maxItemDisplayCount = 4;
    public List<GameObject> itemList = new List<GameObject>();
    [SerializeField] GameObject arrowObject;
    [SerializeField] GameObject bloodVialObject;
    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x < maxItemDisplayCount; x ++){
            GameObject itemDisplayPostion = new GameObject("ItemPosition" + x);
            itemDisplayPostion.transform.SetParent(transform.GetChild(0));
            Vector3 newPos = itemDisplayPostion.transform.position;
            newPos.x = 240 + x * 480;
            newPos.y = 270;
            itemDisplayPostion.transform.position = newPos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            removeFromInventory(startingItemDisplayIndex);
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            shiftInventoryLeft();
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            shiftInventoryRight();
        }
        if(Input.GetKeyDown("space")){
            if(itemList.Count % 2 == 0){
                addToInventory(arrowObject);
            }else{
                addToInventory(bloodVialObject);
            }
        }
    }

    public void addToInventory(GameObject toAdd){
        itemList.Add(toAdd);
        if(itemList.Count - 1 < maxItemDisplayCount){
            GameObject newItem = Instantiate(itemList[itemList.Count - 1], transform.GetChild(0));
            newItem.transform.position = transform.GetChild(0).GetChild(itemList.Count - 1).position;
        }
    }

    public void removeFromInventory(int index)
    {
        int startIndex = index;
        itemList.RemoveAt(index);
        if(index >= startingItemDisplayIndex && index < startingItemDisplayIndex + maxItemDisplayCount){
            for(int x = index - startingItemDisplayIndex + maxItemDisplayCount; 
                x < index - startingItemDisplayIndex + 2*maxItemDisplayCount && x < itemList.Count + maxItemDisplayCount + 1; x++){
                Destroy(transform.GetChild(0).GetChild(x).gameObject);
            }
            if (startingItemDisplayIndex + maxItemDisplayCount == itemList.Count + 1)
            {
                if (startingItemDisplayIndex > 0) {startingItemDisplayIndex--;}
                startIndex = startingItemDisplayIndex;
            }
            for(int x = startIndex; x < startingItemDisplayIndex + maxItemDisplayCount && x < itemList.Count; x++){
                GameObject newItem = Instantiate(itemList[x], transform.GetChild(0));
                newItem.transform.position = transform.GetChild(0).GetChild(x - startIndex).position;
            }
        } 
    }

    public void shiftInventoryRight(){
        if(itemList.Count > maxItemDisplayCount &&  startingItemDisplayIndex + maxItemDisplayCount < itemList.Count){
            startingItemDisplayIndex++;
            for(int x = 0; x < maxItemDisplayCount; x++){
                Destroy(transform.GetChild(0).GetChild(maxItemDisplayCount + x).gameObject);
                GameObject newItem = Instantiate(itemList[startingItemDisplayIndex + x], transform.GetChild(0));
                newItem.transform.position = transform.GetChild(0).GetChild(x).position;
            }
        }
    }

    public void shiftInventoryLeft(){
        if(startingItemDisplayIndex > 0){
            startingItemDisplayIndex--;
            for(int x = 0; x < maxItemDisplayCount; x++){
                Destroy(transform.GetChild(0).GetChild(maxItemDisplayCount + x).gameObject);
                GameObject newItem = Instantiate(itemList[startingItemDisplayIndex + x], transform.GetChild(0));
                newItem.transform.position = transform.GetChild(0).GetChild(x).position;
            }
        }
    }
}
