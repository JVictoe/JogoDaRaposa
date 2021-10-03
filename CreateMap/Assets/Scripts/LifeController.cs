using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeController : MonoBehaviour
{

    [SerializeField] private Life life = default;
    [SerializeField] private Player player = default;

    public static LifeController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {
        life = FindObjectOfType<Life>();
        player = FindObjectOfType<Player>();
    }

    public void SetLifeAmount(float danoRecebido)
    {
        for(int i = 0; i < life.vida.Length; i++)
        {
            if(life.vida[i].fillAmount > 0)
            {
                life.vida[i].fillAmount -= danoRecebido;
                return;
            }
        }

        VerificaVidas();
    }

    public void VerificaVidas()
    {
        int aux = 0;

        for (int i = 0; i < life.vida.Length; i++)
        {
            if (life.vida[i].fillAmount <= 0)
            {
                aux++;
            }
            
        }

        if (aux >= 4)
        {
            player.Death();
        }
    }
}
