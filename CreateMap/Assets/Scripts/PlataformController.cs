using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{

    [SerializeField] private SliderJoint2D slider = default;
    public JointMotor2D aux;

    // Start is called before the first frame update
    void Start()
    {
        aux = slider.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (slider.limitState == JointLimitState2D.LowerLimit)
        {
            aux.motorSpeed = 1;
            slider.motor = aux;
        }
        else if (slider.limitState == JointLimitState2D.UpperLimit)
        {
            aux.motorSpeed = -1;
            slider.motor = aux;
        }
    }
}
