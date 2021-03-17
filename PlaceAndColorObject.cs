using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;   //Per poter richiamare gli script delle interazioni

public class PlaceAndColorObject : MonoBehaviour
{
    Quaternion startRotation;          //Variabile rotazione iniziale
    GameObject axe_handle;             //Variabile di tipo GameObject a cui assegnare successivamente l'oggetto esistente
    GameObject axe_top;

    private InteractionBehaviour interactionBehaviour;  //La variabile di tipo dello script

    void Start()
    {
        //Prendo la rotazione iniziale
        startRotation = transform.rotation;
        //Alla variabile di tipo GameObject assegno l'oggetto esistente
        axe_handle = GameObject.Find("Axe_Handle");
        axe_top = GameObject.Find("Axe_Top");
        //Alla variabile assegno il componente dello script
        interactionBehaviour = GetComponent<InteractionBehaviour>();
        //Associo il metodo di inizio grasp al metodo di cambio colore
        interactionBehaviour.OnGraspBegin += colorObjectGrasped;
        //Associo il metodo di fine grasp al metodo di cambio colore
        interactionBehaviour.OnGraspEnd += colorObjectNotGrasped;
    }

    void Update()
    {
        //Non serve inserire nulla
    }

    private void colorObjectGrasped()
    {
        var axe_hColor = axe_handle.GetComponent<MeshRenderer>();    //Prendo la componente del MeshRenderer
        axe_hColor.material.SetColor("_Color", Color.red);           //Setto il colore sulla variabile
        var axe_tColor = axe_top.GetComponent<MeshRenderer>();
        axe_tColor.material.SetColor("_Color", Color.red);
    }
    private void colorObjectNotGrasped()
    {
        var axe_hColor = axe_handle.GetComponent<MeshRenderer>();    //Prendo la componente del MeshRenderer
        axe_hColor.material.SetColor("_Color", Color.blue);          //Setto il colore sulla variabile
        var axe_tColor = axe_top.GetComponent<MeshRenderer>();       //Prendo la componente del MeshRenderer
        axe_tColor.material.SetColor("_Color", Color.blue);              //Setto il colore sulla variabile
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Se l'oggetto entra nell'area di collisione definita
        if (collision.gameObject.CompareTag("NewAxePosition"))
        {
            //L'oggetto viene posizionato in questa posizione fissa
            gameObject.transform.position = new Vector3(0.3f, 0.965f, -1.3f);
            //L'oggetto prende la rotazione iniziale dopo essere stato posato
            gameObject.transform.rotation = startRotation;
        }
    }
}
