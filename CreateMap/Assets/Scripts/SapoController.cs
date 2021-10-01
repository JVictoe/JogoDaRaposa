using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SapoController : MonoBehaviour
{
    [SerializeField] private Animator anim = default;
    [SerializeField] private SliderJoint2D slider = default;
    [SerializeField] private Rigidbody2D rb = default;
    //[SerializeField] private GameObject bala;
    //[SerializeField] private GameObject positionBala;
    [SerializeField] private Player alvo;

    public float jumpForce;

    public JointMotor2D aux;

    public float movimentFlip;

    bool face = true;

    // Start is called before the first frame update
    void Start()
    {
        aux = slider.motor;
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("x", Mathf.Abs(movimentFlip));
        anim.SetFloat("y", rb.velocity.y);
        


        Debug.LogError("Jump force ???? " + movimentFlip);
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = 1;
            slider.motor = aux;
            Flip();
        }
        
        if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = -1;
            slider.motor = aux;
            Flip();
        }
    }

    void Jump()
    {
        //rb.velocity = Vector2.up * jumpForce;

        
        rb.velocity = Vector2.up * jumpForce;
    }

    void Flip()
    {
        face = !face;
        Vector3 tempScale = transform.localScale;
        tempScale.x *= -1;
        transform.localScale = tempScale;
        Debug.LogError("face " + face);
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.name.Equals("player"))
    //    {
    //        Debug.LogError("entrei qunatas vezers ????");
    //        slider.enabled = false;
    //        rb.simulated = false;
    //        InvokeRepeating(nameof(Atacar), 0f, 5f);
    //    }
    //}
}
