using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Interactables;
using UnityEngine;
using TMPro;

namespace HUD
{
    public class hudManager : MonoBehaviour
    {
        private bool isKeyboardLocked = false;
        private TextMeshProUGUI tmpUI;
        private  GameObject textObject;
        private int startingItemDisplayIndex;
        private int maxItemDisplayCount = 8;
        private int screenWidth = 1920;
        public List<GameObject> itemList = new List<GameObject>();
        public List<string> itemGUIDList = new List<string>();
        private int usingItem;
        [SerializeField] private AudioSource audio;

        // Start is called before the first frame update
        void Start()
        {
            for(int x = 0; x < maxItemDisplayCount; x++){
                GameObject itemDisplayPostion = new GameObject("ItemPosition" + x);
                itemDisplayPostion.transform.SetParent(transform.GetChild(1));
                Vector3 newPos = itemDisplayPostion.transform.position;
                newPos.x = (screenWidth/(maxItemDisplayCount * 2)) + x * (screenWidth/maxItemDisplayCount);
                newPos.y = 160;
                itemDisplayPostion.transform.position = newPos;
            }
            textObject = new GameObject("TextMeshProUI");
            textObject.transform.SetParent(transform.GetChild(1), false);
            tmpUI = textObject.AddComponent<TextMeshProUGUI>();

            tmpUI.GetComponent<RectTransform>().sizeDelta = new Vector2(1920, 320);
            tmpUI.enableWordWrapping = true;
            Vector3 newTextPos = textObject.transform.position;
            newTextPos.x = 960;
            newTextPos.y = 160;
            textObject.transform.position = newTextPos;
            
            tmpUI.fontSize = 48;
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
            if(Input.GetKeyDown("tab")){
                if(!isKeyboardLocked)
                    invertHudStatus();
            }
        }
    
        public void addToInventory(GameObject toAdd){
            Debug.Log("Adding item!");
            CollectAudio();
            itemList.Add(toAdd);
            itemGUIDList.Add(toAdd.GetComponent<InvItemClick>().data.guid);
            if(itemList.Count - 1 < maxItemDisplayCount){
                GameObject newItem = Instantiate(itemList[itemList.Count - 1], transform.GetChild(1));
                newItem.transform.position = transform.GetChild(1).GetChild(itemList.Count - 1).position;
            }
        }
    
        public void removeFromInventory(int index)
        {
            int startIndex = index;
            itemList.RemoveAt(index);
            if(index >= startingItemDisplayIndex && index < startingItemDisplayIndex + maxItemDisplayCount){
                for(int x = index - startingItemDisplayIndex + maxItemDisplayCount; 
                    x < index - startingItemDisplayIndex + 2*maxItemDisplayCount && x < itemList.Count + maxItemDisplayCount + 1; x++){
                    Destroy(transform.GetChild(1).GetChild(x).gameObject);
                }
                if (startingItemDisplayIndex + maxItemDisplayCount == itemList.Count + 1)
                {
                    if (startingItemDisplayIndex > 0) {startingItemDisplayIndex--;}
                    startIndex = startingItemDisplayIndex;
                }
                for(int x = startIndex; x < startingItemDisplayIndex + maxItemDisplayCount && x < itemList.Count; x++){
                    GameObject newItem = Instantiate(itemList[x], transform.GetChild(1));
                    newItem.transform.position = transform.GetChild(1).GetChild(x - startIndex).position;
                }
            } 
        }
        
        public void removeFromInventory()
        {
            int startIndex = usingItem;
            itemList.RemoveAt(usingItem);
            itemGUIDList.RemoveAt(usingItem);
            if(usingItem >= startingItemDisplayIndex && usingItem < startingItemDisplayIndex + maxItemDisplayCount){
                for(int x = usingItem - startingItemDisplayIndex + maxItemDisplayCount + 1; 
                    x < usingItem - startingItemDisplayIndex + 2*maxItemDisplayCount + 1 && x < itemList.Count + maxItemDisplayCount + 2; x++){
                    Destroy(transform.GetChild(1).GetChild(x).gameObject);
                }
                if (startingItemDisplayIndex + maxItemDisplayCount == itemList.Count + 1)
                {
                    if (startingItemDisplayIndex > 0) {startingItemDisplayIndex--;}
                    startIndex = startingItemDisplayIndex;
                }
                for(int x = startIndex; x < startingItemDisplayIndex + maxItemDisplayCount && x < itemList.Count; x++){
                    GameObject newItem = Instantiate(itemList[x], transform.GetChild(1));
                    newItem.transform.position = transform.GetChild(1).GetChild(x - startingItemDisplayIndex).position;
                }
            } 
        }
    
        public void shiftInventoryRight(){
            if(itemList.Count > maxItemDisplayCount &&  startingItemDisplayIndex + maxItemDisplayCount < itemList.Count){
                startingItemDisplayIndex++;
                for(int x = 0; x < maxItemDisplayCount; x++){
                    Destroy(transform.GetChild(1).GetChild(maxItemDisplayCount + x).gameObject);
                    GameObject newItem = Instantiate(itemList[startingItemDisplayIndex + x], transform.GetChild(1));
                    newItem.transform.position = transform.GetChild(1).GetChild(x).position;
                }
            }
        }
    
        public void shiftInventoryLeft(){
            if(startingItemDisplayIndex > 0){
                startingItemDisplayIndex--;
                for(int x = 0; x < maxItemDisplayCount; x++){
                    Destroy(transform.GetChild(1).GetChild(maxItemDisplayCount + x).gameObject);
                    GameObject newItem = Instantiate(itemList[startingItemDisplayIndex + x], transform.GetChild(1));
                    newItem.transform.position = transform.GetChild(1).GetChild(x).position;
                }
            }
        }
        
        public void invertHudStatus()
        {
            if(inputManager.IsInputLocked){
                inputManager.UnlockInput();
            }else{
                inputManager.LockInput();
            }
            GameObject child = transform.GetChild(1).gameObject;
            child.SetActive(!child.activeSelf);
        }

        public void SetUsingItem(int index)
        {
            usingItem = index;
        }

        public void CollectAudio()
        {
            audio.Play();
        }

        public async void Inspect(Interactives interactive)
        {
            if(interactive != null){
                invertHudStatus();
                changeText(interactive.interactive.inspectMessage[0]);
                hideItems();
                await WaitForMouseClick();
                showItems();
                invertHudStatus();
            }
        }
        
        private async UniTask WaitForMouseClick()
        {
            while (!Input.GetMouseButtonDown(0))
            {
                await UniTask.Yield(); // Yields control back to the caller until the next frame
            }
            // Wait until the mouse button is released to prevent accidental skips
            while (Input.GetMouseButton(0))
            {
                await UniTask.Yield();
            }
        }
        
        public void changeText(string newText)
        {
            tmpUI.text = newText;
        }

        public async void displayText(string newText)
        {
            lockKeyboard();
            invertHudStatus();
            changeText(newText);
            hideItems();
            await WaitForMouseClick();
            invertHudStatus();
            showItems();
            unlockKeyboard();
        }

        public void hideItems(){
            transform.GetChild(1).GetChild(8).gameObject.SetActive(true);
            for(int x = 9; x < transform.GetChild(1).childCount; x++){
                transform.GetChild(1).GetChild(x).gameObject.SetActive(false);
            }
        }

        public void showItems(){
            transform.GetChild(1).GetChild(8).gameObject.SetActive(false);
            for(int x = 9; x < transform.GetChild(1).childCount; x++){
                transform.GetChild(1).GetChild(x).gameObject.SetActive(true);
            }
        }

        private void lockKeyboard(){
            isKeyboardLocked = true;
        }
        private void unlockKeyboard(){
            isKeyboardLocked = false;
        }

        public async void introSequence(){
            inputManager.LockInput();
            lockKeyboard();
            transform.GetChild(0).gameObject.SetActive(true);
            // transform.GetChild(1).gameObject.SetActive(false);
            TextMeshProUGUI textComponent = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
            textComponent.text = "You're an FBI agent investigating a missing child last seen near an isolated Oregon woodland residence. Heavy rain pounds against the trees, and weather forecasts warn of flooding within hours. As part of the investigation, you begin by quickly scanning the outer perimeter of the suspected residence for signs of a break-in or property damage. If the home appears vacant, you’ll proceed to investigate inside.";
            await WaitForMouseClick();
            textComponent.text = "Circling the property, you spot a half-shattered window, barricaded with broomsticks. Glass shards are scattered on the ground below, half-buried in the muddy grass. Concerned, you make a mental note of the potential intrusion and proceed to the front door.";
            await WaitForMouseClick();
            textComponent.text = "Reaching the door, you knock firmly and call out,";
            await WaitForMouseClick();
            textComponent.text = "  \"Hello! This is Special Agent Dan Horn with the FBI.\" ";
            await WaitForMouseClick();
            textComponent.text = "No response.";
            await WaitForMouseClick();
            textComponent.text = " \"Hello! FBI! Is anyone home?\" ";
            await WaitForMouseClick();
            textComponent.text = "Silence.";
            await WaitForMouseClick();
            textComponent.text = " \"Coming in!\"";
            await WaitForMouseClick();
            textComponent.text = "You reach for the doorknob. But just as your fingers brush the metal, a loud shatter erupts to your right. You whip around to see a figure dressed in black, wearing a deer mask, leveling a shotgun at you through a freshly shattered window.";
            await WaitForMouseClick();
            textComponent.text = " \"Shit!\"";
            await WaitForMouseClick();
            textComponent.text = "Instinctively, you reach into your jacket pocket for your gun, but before you can draw it, there’s a sharp impact to the side of your head, and everything goes black.\n The deer-masked figure, wielding a shotgun loaded with a beanbag round, watches as you collapse. Standing over you, he mutters, ";
            await WaitForMouseClick();
            textComponent.text = " \"They always try to survive. Don’t fear death… for it will free you.\"";
            await WaitForMouseClick();

            transform.GetChild(0).gameObject.SetActive(false);

            invertHudStatus();
            inputManager.LockInput();
            tmpUI.text = "A grinding rumble suddenly wakes you. You find yourself inside a bathtub. Looking around you, you find meat dangling off wires hooked onto the ceiling of the room. Shocked, you reach for your gun but find nothing. ";
            await WaitForMouseClick();
            tmpUI.text = "You control your panic and stand up. Your brain pulsates with pain and feel lightheaded. Presumably from the bean bag. Walking feels overwhelmingly abnormal however. You reach the door and slowly turn the knob.";
            await WaitForMouseClick();
            tmpUI.text = "It's locked.";
            await WaitForMouseClick();
            tmpUI.text = "You have to find a way out.";
            await WaitForMouseClick();
            tmpUI.text = "That deer...";
            await WaitForMouseClick();
            invertHudStatus();
            unlockKeyboard();
            inputManager.UnlockInput();

            unlockKeyboard();
        }
    }
}

