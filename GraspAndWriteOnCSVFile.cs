using Leap.Unity.Interaction;
using System;
using System.IO;
using System.Text;
using UnityEngine;

public class GraspAndWriteOnCSVFile : MonoBehaviour
{
    //Variabili rotazione iniziale
    Quaternion startRotationMartello;
    Quaternion startRotationSega;
    //Variabili oggetti
    GameObject martello;
    GameObject sega;
    //Variabile di tipo dello script
    private InteractionBehaviour interactionBehaviour;  
    //Variabili bool
    private bool martelloPosizionato = false;
    private bool segaPosizionata = false;

    void Start()
    {
        //Assegno gli oggetti in scena alle variabili
        martello = GameObject.Find("Martello");
        sega = GameObject.Find("Sega");
        //Prendo la rotazione iniziale di entrambi
        startRotationMartello = martello.transform.rotation;
        startRotationSega = sega.transform.rotation;
        //Alla variabile assegno lo script
        interactionBehaviour = GetComponent<InteractionBehaviour>();
    }

    private void WriteOnFileCSV()
    {
        //Creo un oggetto di tipo StringBuilder
        StringBuilder csv = new StringBuilder();
        //Assegno un determinato percorso
        string filePath = @"C:\Users\WK_Alberico\Documents\File.csv";
        string attrezzo;
        string pos;
        string newLine;
        //Se l'oggetto è il martello, entra nell'if
        if(gameObject.CompareTag("Martello"))
        {
            //Assegno le stringhe alle variabili locali
            attrezzo = "Martello";
            pos = "Oggetto posizionato nell'area";
            //Creo una riga con più colonne
            newLine = String.Format("{0};{1}", attrezzo, pos);
            csv.AppendLine(newLine);    //Aggiunge effettivamente la riga allo StringBuilder
        }
        //Se l'oggetto è la sega, entra nell'if
        else if(gameObject.CompareTag("Sega"))
        {
            //Assegno le stringhe alle variabili locali
            attrezzo = "Sega";
            pos = "Oggetto posizionato nell'area";
            //Creo una riga con più colonne
            newLine = String.Format("{0};{1}", attrezzo, pos);
            csv.AppendLine(newLine);    //Aggiunge effettivamente la riga allo StringBuilder
        }
        //Se l'oggetto è la sega, entra nell'if
        else if (gameObject.CompareTag("Vite"))
        {
            //Assegno le stringhe alle variabili locali
            attrezzo = "Vite";
            pos = "Oggetto posizionato nell'area";
            //Creo una riga con più colonne
            newLine = String.Format("{0};{1}", attrezzo, pos);
            csv.AppendLine(newLine);    //Aggiunge effettivamente la riga allo StringBuilder
        }

        //Aggiungi testo al file
        File.AppendAllText(filePath, csv.ToString());
        //Leggo tutto il testo da file
        string dataFromRead = File.ReadAllText(filePath);
        Debug.Log(dataFromRead);    //Mostro nella console di Unity ciò che è scritto nel file
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Se l'oggetto entra nell'area di collisione definita
        if (collision.gameObject.CompareTag("Area"))
        {
            //Se l'oggetto è il martello e non è stato posizionato, entra nell'if
            if(gameObject.CompareTag("Martello") && !martelloPosizionato)
            {
                //L'oggetto viene posizionato in questa posizione fissa
                gameObject.transform.position = new Vector3(-0.253f, 0.705f, -0.516f);
                //L'oggetto prende la rotazione iniziale dopo essere stato posato
                gameObject.transform.rotation = startRotationMartello;
                //Ruoto l'oggetto di 180 gradi
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Bool che indica posizionamento
                martelloPosizionato = true;
                //Chiamo la funzione per scrivere su file CSV
                WriteOnFileCSV();
            }
            //Se l'oggetto è la sega e non è stato posizionato, entra nell'if
            if (gameObject.CompareTag("Sega") && !segaPosizionata)
            {
                //L'oggetto viene posizionato in questa posizione fissa
                gameObject.transform.position = new Vector3(0.189f, 0.705f, -0.662f);
                //L'oggetto prende la rotazione iniziale dopo essere stato posato
                gameObject.transform.rotation = startRotationSega;
                //Ruoto l'oggetto di 180 gradi
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Bool che indica posizionamento
                segaPosizionata = true;
                //Chiamo la funzione per scrivere su file CSV
                WriteOnFileCSV();
            }
            //Se l'oggetto è la sega e non è stato posizionato, entra nell'if
            if (gameObject.CompareTag("Vite") && !segaPosizionata)
            {
                //L'oggetto viene posizionato in questa posizione fissa
                gameObject.transform.position = new Vector3(-0.134f, 0.705f, -0.622f);
                //L'oggetto prende la rotazione iniziale dopo essere stato posato
                gameObject.transform.rotation = startRotationSega;
                //Ruoto l'oggetto di 180 gradi
                gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                //Bool che indica posizionamento
                segaPosizionata = true;
                //Chiamo la funzione per scrivere su file CSV
                WriteOnFileCSV();
            }
        }
    }
}
