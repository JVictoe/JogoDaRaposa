using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb = default;
    public Animator anim = default;
    //[SerializeField] private MoveBackground[] moveBackground = default;

    public float speed;
    public float jumpForce;

    float movimentFlip;
    public bool face = true;
    public bool isGround;

    [SerializeField] private Transform checkPeDireito = default;
    [SerializeField] private Transform checkPeEsquerdo = default;
    [SerializeField] private GameObject bala = default;
    [SerializeField] private GameObject posicaoBala = default;

    public float radius;

    public LayerMask ground;

    public int nJump;

    Vector3 moviment;

    void Start()
    {
        
    }


    void Update()
    {

        anim.SetFloat("SpeedX", Mathf.Abs(movimentFlip));
        anim.SetFloat("SpeedY", rb.velocity.y);
        anim.SetBool("isGround", isGround);

        if (Input.GetKeyDown(KeyCode.Mouse0)) Atacar();

        movimentFlip = Input.GetAxis("Horizontal");

        Move();
        CheckInput();
        CheckGround();
    }

    void Atacar()
    {
        GameObject balaInst = Instantiate(bala, posicaoBala.transform.position, Quaternion.identity);
        balaInst.GetComponent<MoveBalas>().Vel *= 10;
        balaInst.GetComponent<MoveBalas>().lado = face;
        Destroy(balaInst, 3f);
    }

    private void FixedUpdate()
    {
        if (movimentFlip > 0 && !face) Flip();
        else if (movimentFlip < 0 && face) Flip();
    }

    void Move()
    {
        moviment = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += moviment * Time.deltaTime * speed;

        //if (movimentFlip > 0)
        //{
        //    for (int i = 0; i < moveBackground.Length; i++)
        //    {
        //        if (moveBackground[i].speed > 0)
        //        {
        //            moveBackground[i].speed = moveBackground[i].speed * -1;
        //        }
        //        moveBackground[i].MoveCenario();
        //    }
        //}
        //else if (movimentFlip < 0)
        //{
        //    for (int i = 0; i < moveBackground.Length; i++)
        //    {
        //        if (moveBackground[i].speed < 0)
        //        {
        //            moveBackground[i].speed = moveBackground[i].speed * -1;
        //        }

        //        moveBackground[i].MoveCenario();
        //    }
        //}


    }

    void Jump()
    {
        nJump--;

        rb.velocity = Vector2.up * jumpForce;

        if (isGround && Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.velocity = Vector2.up * jumpForce;
            isGround = false;
        }
    }

    void Flip()
    {
        face = !face;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkPeDireito.position, radius);
        Gizmos.DrawSphere(checkPeEsquerdo.position, radius);
    }

    void CheckInput()
    {
        if (isGround)
        {
            nJump = 1;
        }

        if(Input.GetKeyDown(KeyCode.Space) && nJump > 0)
        {
            Jump();
        }
    }

    void CheckGround()
    {
        isGround = Physics2D.OverlapCircle(checkPeDireito.position, radius, ground);
        isGround = Physics2D.OverlapCircle(checkPeEsquerdo.position, radius, ground);
    }

}