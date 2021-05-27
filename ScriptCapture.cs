using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCapture : MonoBehaviour
{
    string folder = "C:/Users/WK_Alberico/Desktop/Workspace Unity 2018.4.14/CaptureFrames/Assets/Screenshots";
    int frameRate = 1;

    void Start()
    {
        StartCoroutine(TestCoroutine());    //Posso richiamare anche il nome della funzione come stringa: "TestCoroutine"
        Time.captureFramerate = frameRate;
        System.IO.Directory.CreateDirectory(folder);
    }

    IEnumerator TestCoroutine()
    {
        while(true)
        {
            Debug.Log("Attesa");
            yield return new WaitForSeconds(500.0f);    //Aspetta 5 secondi
            Debug.Log("Attesa finita");
            string timeStamp = DateTime.Now.ToString("yyyyMMddTHHmmss");
            string name = string.Format("{0}/{1:D04} shot.png", folder, timeStamp);
            ScreenCapture.CaptureScreenshot(name);
            Debug.Log("Screenshot Fatto");
        }
    }
}
