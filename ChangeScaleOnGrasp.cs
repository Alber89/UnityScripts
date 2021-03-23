using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class ChangeScaleOnGrasp : MonoBehaviour
{
    InteractionBehaviour interactionBehaviour;

    void Start()
    {
        //Assegno lo script alla variabile
        interactionBehaviour = GetComponent<InteractionBehaviour>();
        //Associo il cambiamento di scala al grasp
        interactionBehaviour.OnGraspBegin += cambiaScalaAlGrab;
        interactionBehaviour.OnGraspStay += cambiaScalaAlGrab;
    }

    private void cambiaScalaAlGrab()
    {
        //cambio la scala
        transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }
}
