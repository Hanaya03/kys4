using System;
using Cysharp.Threading.Tasks;
using Interactables;
using UnityEngine;

public class LightUp : MonoBehaviour
{
    private float alphaLevel;
    [SerializeField] private SpriteRenderer sprite;

    public async void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.TryGetComponent(out InvItem script)) return;
        if (script.interactive.guid != "Items/Candle") return;
        float distance = 0;
        while (col && distance < 2)
        {
            distance = Vector2.Distance(transform.position, col.transform.position);
            if (distance < 0.5) { alphaLevel = 255/255f; }
            else if (distance < 1) { alphaLevel = 155/255f; }
            else if (distance < 1.5) { alphaLevel = 25/255f; }
            else { alphaLevel = 5/255f; }
            await UniTask.Yield();
        }
        alphaLevel = 0;
        sprite.color = new Color(255,255,255,0);
    }

    // Update is called once per frame
    void Update()
    {
        const float tolerance = 0.01f; if (Math.Abs(sprite.color.a - alphaLevel) < tolerance) return;
        var newAlpha = sprite.color.a;
        if (sprite.color.a < alphaLevel) { newAlpha += 0.1f/255f;  }
        else { newAlpha -= 0.1f/255f; }
        sprite.color = new Color(255,255,255,newAlpha);
    }
}
