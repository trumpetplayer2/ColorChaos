using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHole : MonoBehaviour
{
    bool isFilled = false;
    public GameObject hole;
    public Sprite box;
    public AudioSource sfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Box")
        {
            if (!isFilled)
            {
                Destroy(collision.gameObject);
                isFilled = true;
                hole.layer = this.gameObject.layer;
                SpriteRenderer spriteRenderer = hole.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = box;
                spriteRenderer.color = Color.gray;
                sfx.PlayOneShot(sfx.clip);
                Destroy(this.gameObject);
            }
        }
    }
}
