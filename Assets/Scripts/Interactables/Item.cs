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
        [SerializeField] public GameObject itemObject;
        
        
    }
}

