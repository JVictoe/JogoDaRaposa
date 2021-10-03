using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaController : MonoBehaviour
{

    private float vel = 3;
    public Player alvo;

    //public static BalaController instance;

    public float Vel
    {
        get { return vel; }
        set { vel = value; }
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

        if (transform.position.y > UfoGames.instance.positionY)
        {
            transform.position += Vector3.down * vel * Time.deltaTime;
        }
        else if (transform.position.y < UfoGames.instance.positionY)
        {
            transform.position += Vector3.up * vel * Time.deltaTime;

        }
    }

    // Update is called once per frame
    void Update()
    {
        BalaSegue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("player"))
        {
            alvo.anim.SetTrigger("Hurt");
            LifeController.instance.SetLifeAmount(0.5f);
            Destroy(gameObject);
        }
    }

}
