using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class RiconoscimentoMani : MonoBehaviour
{
    LeapProvider provider;

    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    void Update()
    {
        Frame frame = provider.CurrentFrame;
        foreach (Hand hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                Debug.Log("Left hand is present");
            }
            else if (hand.IsRight)
            {
                Debug.Log("Right hand is present");
            }
        }
        
    }
}
