using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalas : MonoBehaviour
{

    private float vel = 3;
    public bool lado;

    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }

    private void Start()
    {
        SoundController.instance.SoundEffectsController(Sound.tiro);
    }

    void Move()
    {
        if (lado)
        {
            transform.position += Vector3.right * vel * Time.deltaTime;
        }
        else if (!lado)
        {
            transform.position -= Vector3.right * vel * Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("Aguia"))
    //    {
    //        Debug.LogError("Entrou aqui e matoooo a aguia ????");
    //        Destroy(collision.gameObject);
    //    }
    //}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Aguia"))
        {
            Debug.LogError("Entrou aqui e matoooo a aguia ????");
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
