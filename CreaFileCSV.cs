using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreaFileCSV : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        createFileCSV();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void createFileCSV()
    {
        //Creo un oggetto di tipo StringBuilder
        StringBuilder csv = new StringBuilder();

        //Creo i nomi delle colonne
        string nome = "Nome";
        string cognome = "Cognome";
        string luogo = "Luogo";
        //Creo una riga con più colonne
        string newLine = String.Format("{0};{1};{2}", nome, cognome, luogo);
        csv.AppendLine(newLine);    //Aggiunge effettivamente la riga allo StringBuilder
        
        //Creo il file in un determinato percorso
        string filePath = @"C:\Users\Albe1\Documents\File.csv";
        
        //Ciclo che implica quante righe aggiungere
        for(int i = 0; i < 3; i++)
        {
            //Posso modificare le variabili ad ogni iterazione del ciclo
            nome = "Alberico" + i;  //L'indice serve solo per tenere il conto del numero di righe, si può omettere
            cognome = "Ciriello" + i;
            luogo = "Roma" + i;

            //Creo una riga con più colonne
            newLine = String.Format("{0};{1};{2}", nome, cognome, luogo); 
            csv.AppendLine(newLine);    //Aggiunge effettivamente la riga allo StringBuilder
        }
        //Scrivo il testo su file
        File.WriteAllText(filePath, csv.ToString());
        Debug.Log("File creato");

        //Leggo il testo da file
        string dataFromRead = File.ReadAllText(filePath);
        Debug.Log(dataFromRead);    //Mostro nella console di Unity
    }
}
