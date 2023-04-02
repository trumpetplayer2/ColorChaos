using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    public PlayerPower color;
    public AudioSource sfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            player.ChangeColor(color);
            if(sfx != null)
            {
                sfx.PlayOneShot(sfx.clip);
            }
        }
    }
}
