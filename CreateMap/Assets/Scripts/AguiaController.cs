using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AguiaController : MonoBehaviour
{
    [SerializeField] private Animator anim = default;
    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject positionBala;
    [SerializeField] private Player alvo;
    [SerializeField] private Transform[] limits = default;
    [SerializeField] private SpriteRenderer aguia = default;
    [SerializeField] private bool visaoV = default;
    [SerializeField] private float raio = default;
    [SerializeField] private LayerMask layerV = default;
    private bool chamado = true;
    private WaitForSeconds tempo = new WaitForSeconds(1);
    private WaitForSeconds tempoAtaque = new WaitForSeconds(3);

    private float velMove = 2f;
    

    public float movimentFlip;

    bool face;
    public bool pontoAtaque;
    bool triggerBool = false;
    bool ataqueTrue = false;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);
        pontoAtaque = Physics2D.OverlapCircle(transform.position, raio/2 + 1 , layerV);

        if (visaoV)
        {
            var relativeP = transform.InverseTransformPoint(alvo.transform.position);

            if(relativeP.x <= 0.0f)
            {
                aguia.flipX = false;
                face = true;
            }
            else if(relativeP.x > 0.0f)
            {
                aguia.flipX = true;
                face = false;
            }
        }

        if(!pontoAtaque)
        {
            if (face)
            {
                rb.velocity = new Vector2(-velMove, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(velMove, rb.velocity.y);
            }
            triggerBool = true;
        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            if(triggerBool)
            {
                UfoGames.instance.positionX = alvo.transform.position.x;
                UfoGames.instance.positionY = alvo.transform.position.y;
                UfoGames.instance.positionZ = alvo.transform.position.z;
                triggerBool = false;
            }
            Atacar();
            
        }
        

        VerificaColisao();

    }

    void Atacar()
    {
        if(GameObject.FindWithTag("BalaAguia") == null)
        {
            GameObject balaInst = Instantiate(bala, positionBala.transform.position, Quaternion.identity);
            balaInst.GetComponent<BalaController>().alvo = alvo;
            balaInst.GetComponent<BalaController>().Vel *= 1;
            Destroy(balaInst, 3f);
        }
        
    }

    void Flip()
    {
        //face = !face;

        //Vector3 tempScale = transform.localScale;

        aguia.flipX = !face;

        //transform.localScale = tempScale;
    }

    void VerificaColisao()
    {
        if(transform.position.x >= limits[0].position.x && chamado)
        {
            face = true;
            StartCoroutine(ChamaFlip());
        }
        else if(transform.position.x <= limits[1].position.x)
        {
            face = false;
            StartCoroutine(ChamaFlip());
        }
    }

    IEnumerator ChamaFlip()
    {
        Flip();
        chamado = false;
        yield return tempo;
        chamado = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raio/2 + 1);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("player") && !triggerBool)
    //    {
    //        triggerBool = true;
    //        Debug.LogError("entrei qunatas vezers ????");
    //        UfoGames.instance.positionX = alvo.transform.position.x;
    //        UfoGames.instance.positionY = alvo.transform.position.y;
    //        UfoGames.instance.positionZ = alvo.transform.position.z;
    //        rb.simulated = false;
    //        InvokeRepeating(nameof(Atacar), 0f, 5f);
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("player"))
    //    {
    //        newMusic = true;
    //        newMusicController = true;
    //    }
    //}
}
