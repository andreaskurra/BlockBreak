using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundWin : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    private SpriteRenderer spriteR;
    // Start is called before the first frame update
    void Start()
    {
        spriteR = GetComponent<SpriteRenderer>();
        Sprite spr = sprites[UnityEngine.Random.Range(0, sprites.Length)];
        spriteR.sprite = spr;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
