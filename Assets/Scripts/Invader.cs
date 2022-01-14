using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invader : MonoBehaviour
{
    [SerializeField] private Sprite[] animationSprites;
    [SerializeField] private float animationTime;

    private SpriteRenderer spriteRenderer;
    private int animationFrame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprites), this.animationTime, this.animationTime);
    }

    private void AnimateSprites()
    {
        animationFrame++;

        if (animationFrame >= animationSprites.Length)
        {
            animationFrame = 0;
        }

        spriteRenderer.sprite = animationSprites[animationFrame];
    }
}
