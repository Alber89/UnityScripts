using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class RiconoscimentoMani : MonoBehaviour
{
    LeapProvider provider;
    // Start is called before the first frame update
    void Start()
    {
        provider = FindObjectOfType<LeapProvider>() as LeapProvider;
    }

    // Update is called once per frame
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
            if (hand.IsLeft && hand.IsRight)
            {
                Debug.Log("Both hand are present");
            }
            
        }

    }
}
