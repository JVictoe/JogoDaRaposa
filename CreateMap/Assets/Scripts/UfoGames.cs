using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoGames : MonoBehaviour
{

    public static UfoGames instance;
    public float positionX;
    public float positionY;
    public float positionZ;

    private void Awake()
    {

        if(instance == null)
        {
            Debug.LogError("Veio aquiii");
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
