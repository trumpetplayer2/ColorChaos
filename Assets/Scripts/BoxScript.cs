using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public Rigidbody2D body;
    public float pushMass;
    public float noPushMass;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PlayerController player = collision.GetComponent<PlayerController>();
            if(player.getColor() == PlayerPower.Red)
            {
                body.mass = pushMass;
            }
            else
            {
                body.mass = noPushMass;
            }
        }
    }
}
