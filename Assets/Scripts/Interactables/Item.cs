using System;
using HUD;
using Interactables.Components;
using TriInspector;
using UnityEngine;

namespace Interactables
{
    [RequireComponent(typeof(Collectable))]
    [HideMonoScript]
    public class Item : Interactives
    {
        [Tooltip("The item's corresponding UI Object: Assets/Prefabs/InvUI")]
        [SerializeField] public GameObject itemObject;
        
        
    }
}

