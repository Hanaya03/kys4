using System;
using UnityEngine;

namespace Interactables.Data
{
    [CreateAssetMenu(menuName = "Interactable/ItemData")]
    public class ItemData : InteractiveData
    {
        [Serializable]    
        public class ItemCombinations
        {
            public string itemID;
            public InvItem.CombinationFunctions function;
            public bool consumeItem;
            public string giveID;
        }

        [SerializeField] public ItemCombinations[] combinations;

    }

    
}

