using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlechaController : MonoBehaviour
{
    private float vel = 3;
    public Player alvo;
    public bool lado;
    [SerializeField] private SpriteRenderer img = default;
    //public static BalaController instance;

    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }

    private void Start()
    {
        img.flipX = lado;
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
        Destroy(gameObject, 0.5f);
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
            LifeController.instance.SetLifeAmount(0.5f);
            Destroy(gameObject);
        }
    }
}
