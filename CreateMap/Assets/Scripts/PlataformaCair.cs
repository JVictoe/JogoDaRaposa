using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCair : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = default;
    public float time = 2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name.Equals("player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.mass = 50f;
            rb.gravityScale = 0.5f;
            Destroy(gameObject, 03f);
        }
    }
}
