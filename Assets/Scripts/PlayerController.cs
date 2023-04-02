using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.PlayerLoop.PreLateUpdate;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D Player;
    private float inX = 0f;
    private float inY = 0f;
    PlayerPower currentPower = PlayerPower.White;
    public Color[] PowerColorList;
    public float[] PowerSpeed;
    public string[] PowerLayer;
    public AudioSource sfx;
    
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        inX = Input.GetAxisRaw("Horizontal");
        inY = Input.GetAxisRaw("Vertical");

    }

    private void FixedUpdate()
    {
        if (Time.timeScale <= 0) { return; }
        Vector2 moveX = new Vector2(inX * movementSpeed, inY * movementSpeed);
        Player.velocity = moveX;
    }

    public void ChangeColor(PlayerPower color)
    {
        if(currentPower == color) { return; }
        spriteRenderer.color = PowerColorList[(int) color];
        movementSpeed = PowerSpeed[(int)color];
        gameObject.layer = LayerMask.NameToLayer(PowerLayer[(int)color]);
        currentPower = color;
        if(sfx != null)
        {
            sfx.PlayOneShot(sfx.clip);
        }
    }

    public PlayerPower getColor()
    {
        return currentPower;
    }
}
