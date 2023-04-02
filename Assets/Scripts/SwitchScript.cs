using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public Color toggledColor;
    public GameObject[] affectedObjects;
    public GameObject[] counteredObjects;
    public AudioSource sfx;
    bool isToggled = false;
    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        toggled();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if (player == null) { return; }
            //Player Entered, and must be Yellow due to Layer. Therefore, trigger
            isToggled = !isToggled;
            Color temp = spriteRenderer.color;
            spriteRenderer.color = toggledColor;
            toggledColor = temp;
            //Reset Player power, they discharged
            player.ChangeColor(PlayerPower.White);
            sfx.PlayOneShot(sfx.clip);
            toggled();
        }
    }

    private void toggled()
    {
        foreach(GameObject obj in affectedObjects)
        {
            //Run the results on them, for now we'll hide, though eventually we'll call an attatched script rather than Game Object to animate open (If time)
            obj.SetActive(!isToggled);
        }
        foreach(GameObject obj in counteredObjects)
        {
            obj.SetActive(isToggled);
        }
    }
}
