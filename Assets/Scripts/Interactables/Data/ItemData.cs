using System;
using UnityEngine;

namespace Interactables.Data
{
    /// <summary> Data for an item object - GUID, inspect message, and a list of item-static combinations.</summary>
    [CreateAssetMenu(menuName = "Interactable/ItemData")]
    public class ItemData : InteractiveData
    {
        /// <summary> An item-to-static combination. Includes the <see cref="staticID"/>, the <see cref="function"/>, the boolean
        /// <see cref="consumeItem"/>, and the <see cref="giveID"/>
        /// </summary>
        [Serializable]    
        public class ItemCombinations
        {
            [Tooltip("The ID of the static entity the item can be dragged onto.")]
            public string staticID;
            [Tooltip("The function that will run when this combination is used.")]
            public InvItem.CombinationFunctions function;
            [Tooltip("Whether the item is consumed after use.")]
            public bool consumeItem;
            [Tooltip("Whether the Static is consumed after interaction.")]
            public bool consumeStatic;
            [Tooltip("The ID of the item to give after this combination is used, if applicable.")]
            public string giveID; 
        }

        [Tooltip("List of item-to-static combinations available for this item.")]
        [SerializeField] public ItemCombinations[] combinations;
        [SerializeField] public GameObject prefab;
        [SerializeField] public AudioClip[] audio;

    }

    
}

