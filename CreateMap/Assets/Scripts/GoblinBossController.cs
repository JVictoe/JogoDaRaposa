using System.Collections;
using UnityEngine;

public class GoblinBossController : MonoBehaviour
{
    [SerializeField] private Animator anim = default;
    [SerializeField] private Rigidbody2D rb = default;
    [SerializeField] private GameObject bala;
    [SerializeField] private GameObject positionBala;
    [SerializeField] private Player alvo;
    [SerializeField] private Transform[] limits = default;
    [SerializeField] private SpriteRenderer goblin = default;
    [SerializeField] private bool visaoV = default;
    [SerializeField] private float raio = default;
    [SerializeField] private LayerMask layerV = default;
    private bool chamado = true;
    private WaitForSeconds tempo = new WaitForSeconds(1);
    private WaitForSeconds tempoAtaque = new WaitForSeconds(3);

    private float velMove = 2f;
    bool face;
    public bool pontoAtaque;
    bool triggerBool = false;

    void Start()
    {
        Physics2D.IgnoreLayerCollision(7, 7);
        anim.SetTrigger("andar");
    }

    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);
        pontoAtaque = Physics2D.OverlapCircle(transform.position, raio / 2 + 1, layerV);

        if (visaoV)
        {
            var relativeP = transform.InverseTransformPoint(alvo.transform.position);

            triggerBool = relativeP.x < 0f;

            if (relativeP.x <= 0.0f)
            {
                goblin.flipX = true;
                face = false;
            }
            else if (relativeP.x > 0.0f)
            {
                goblin.flipX = false;
                face = true;
            }
        }

        if (!pontoAtaque)
        {
            anim.SetTrigger("andar");
            if (!face)
            {
                rb.velocity = new Vector2(-velMove, rb.velocity.y);
            }
            else
            {
                rb.velocity = new Vector2(velMove, rb.velocity.y);
            }
            //triggerBool = true;
        }
        else
        {
            
            rb.velocity = new Vector2(0, 0);
            anim.SetTrigger("atirar");
            UfoGames.instance.positionX = alvo.transform.position.x;
            UfoGames.instance.positionY = alvo.transform.position.y;
            UfoGames.instance.positionZ = alvo.transform.position.z;
            //triggerBool = false;

            Atacar();
        }

        VerificaColisao();
    }

    void Atacar()
    {
        if (GameObject.FindWithTag("Flecha") == null)
        {
            GameObject balaInst = Instantiate(bala, positionBala.transform.position, Quaternion.identity);
            balaInst.GetComponent<FlechaController>().alvo = alvo;
            balaInst.GetComponent<FlechaController>().Vel *= 1.5f;
            Destroy(balaInst, 3f);
        }
    }

    void Flip()
    {
        goblin.flipX = !face;
    }

    void VerificaColisao()
    {
        if (transform.position.x >= limits[0].position.x && chamado)
        {
            face = false;
            StartCoroutine(ChamaFlip());
        }
        else if (transform.position.x <= limits[1].position.x)
        {
            face = true;
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
        Gizmos.DrawWireSphere(transform.position, raio / 2 + 1);
    }
}
