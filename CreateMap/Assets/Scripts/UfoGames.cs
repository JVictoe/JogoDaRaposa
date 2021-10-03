using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoGames : MonoBehaviour
{

    public static UfoGames instance;
    public float positionX;
    public float positionY;
    public float positionZ;

    //[SerializeField] private SoundController _sound = default;
    //public static SoundController Sound { get { return instance._sound; } set {  } }

    private void Awake()
    {

        if(instance == null)
        {
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

}
