using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity.Interaction;

public class PinchToGrow : MonoBehaviour
{
    Controller controller;  //Fornisce dati dal LEAP controller
    InteractionBehaviour interactionBehaviour;  //Fornisce informazioni sullo stato dell'oggetto in Unity

    //Inizializzo nello start
    void Start()
    {
        controller = new Controller();
        interactionBehaviour = GetComponent<InteractionBehaviour>();
    }

    void FixedUpdate()
    {
        if(controller.IsConnected)
        {
            //Prende un frame dal controller ad ogni update
            Frame frame = controller.Frame();
            //Se il numero di frame ottenuti è > 1 e sono due le mani che grabbano l'oggetto entro nell'if
            if(frame.Hands.Count > 1 && interactionBehaviour.graspingHands.Count == 2)
            {
                //Prendo le mani dai frame e li assegno ad una lista
                List<Hand> hands = frame.Hands;
                //Assegno le prime mani ottenute a due oggetti di tipo Hand
                Hand firstHand = hands[0];
                Hand secondHand = hands[1];
                //Accedo alla punta del dito di ogni mano
                List<Finger> firstFingers = firstHand.Fingers;
                List<Finger> secondFingers = secondHand.Fingers;
                //Assegno le prime dita a due oggetti di tipo Finger
                Finger firstFinger = firstFingers[0];
                Finger secondFinger = secondFingers[1];
                //Distanza tra le dita delle due mani
                float distanza;
                distanza = firstFinger.TipPosition.DistanceTo(secondFinger.TipPosition);
                //Aggiusto la distanza a qualcosa di più utilizzabile
                distanza = distanza * 0.001f;
                //La scala dell'oggetto sarà sempre correlata alla distanza tra i palmi delle mani dell'utente
                this.transform.localScale = new Vector3(distanza, distanza, distanza);
            }
        }
    }
}
