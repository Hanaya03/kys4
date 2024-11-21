using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Interactable/SceneState")]
[Serializable]
public class SceneState : ScriptableObject
{
    public Combination[] Combinations;
    public Sprite background;
    public SceneState[] nextScenes;

    [Serializable]
    public class Combination
    {
        public string ItemID;
        public string EntityID;
    }
}

