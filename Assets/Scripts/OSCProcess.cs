using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using extOSC;

public class OSCProcess : MonoBehaviour
{

    public OSCReceiver oscReceiver;
    public OSCTransmitter oscTransmitter;
    public AsteroidDodger asteroidDodger;

    public int PhotoInMin = 0;
    public int PhotoInMax = 1023;
    public float PhotoOutMin = 0.0f;
    public float PhotoOutMax = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
       oscReceiver.Bind("/photo", TraiterMessagePhoto); // dit comment ca va s'appeler
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TraiterMessagePhoto(OSCMessage message)
    {
        // Traiter un entier et l’appliquer à une propriété (flux continu)

        // Récupérer la valeur du premier argument en taant qu’entier :
        int valeur = message.Values[0].IntValue;

        // Deboguer
        // Debug.Log("Reçu : " + message.Address + " " + valeur);

        // Ajustement de la valeur
        float ajustee = (
            ((float)valeur - PhotoInMin) / (PhotoInMax - PhotoInMin) * (PhotoOutMax - PhototOutMin) + PhotoOutMin
        );
        
        // DESTINATION
        asteroidDodger.SetShipY(ajustee);
        // faut dire le SetShipY ye ou/ dans quel script pour ensuite nommer la fonction 
    }

}
