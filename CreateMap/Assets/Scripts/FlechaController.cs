using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaController : MonoBehaviour
{
    private float vel = 3;
    public Player alvo;
    private Transform t;
    //public static BalaController instance;

    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }

    private void Start()
    {

    }

    void BalaSegue()
    {

        if (transform.position.x > UfoGames.instance.positionX)
        {
            transform.position += Vector3.left * vel * Time.deltaTime;
        }
        else if (transform.position.x < UfoGames.instance.positionX)
        {
            transform.position += Vector3.right * vel * Time.deltaTime;
        }

    }

    void DestroiBala()
    {
        if (transform.position.x == UfoGames.instance.positionX && transform.position.y == UfoGames.instance.positionY)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        BalaSegue();
        DestroiBala();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player"))
        {
            alvo.anim.SetTrigger("Hurt");
            Destroy(gameObject);
        }
    }
}
