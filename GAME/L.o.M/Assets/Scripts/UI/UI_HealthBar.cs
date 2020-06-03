using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class UI_HealthBar : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Following;
    public GameObject Player;

    //LEBENSBALKEN
    public GameObject Leben0;
    public GameObject Verloren0;

    public GameObject Leben1;
    public GameObject Verloren1;

    public GameObject Leben2;
    public GameObject Verloren2;

    public GameObject Leben3;
    public GameObject Verloren3;

    public GameObject Leben4;
    public GameObject Verloren4;

    //ALERTA ALERTA
    public GameObject Alert;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Canvas HUDScript = HUD.GetComponent<Canvas>();
        Follow_R FollowScript = Following.GetComponent<Follow_R>();
        CharacterControl PlayerScript = Player.GetComponent<CharacterControl>();
        Canvas AlertScript = Alert.GetComponent<Canvas>();

        // LEBENSBALKEN

        Canvas Leben0Script = Leben0.GetComponent<Canvas>();
        Canvas Verloren0Script = Verloren0.GetComponent<Canvas>();

        Canvas Leben1Script = Leben1.GetComponent<Canvas>();
        Canvas Verloren1Script = Verloren1.GetComponent<Canvas>();

        Canvas Leben2Script = Leben2.GetComponent<Canvas>();
        Canvas Verloren2Script = Verloren2.GetComponent<Canvas>();

        Canvas Leben3Script = Leben3.GetComponent<Canvas>();
        Canvas Verloren3Script = Verloren3.GetComponent<Canvas>();

        Canvas Leben4Script = Leben4.GetComponent<Canvas>();
        Canvas Verloren4Script = Verloren4.GetComponent<Canvas>();


        /*
                if (PlayerScript.playerHealth == 5)
                {
                    HUDScript.enabled = true;

                }
                else if(PlayerScript.playerHealth == 4)
                {
                    Leben0Script.enabled = false;
                    Verloren0Script.enabled = true;
                }
                else if (PlayerScript.playerHealth == 3)
                {
                    Leben1Script.enabled = false;
                    Verloren1Script.enabled = true;
                }
                else if(PlayerScript.playerHealth == 2)
                {
                    Leben2Script.enabled = false;
                    Verloren2Script.enabled = true;
                }
                else if (PlayerScript.playerHealth == 1)
                {
                    Leben3Script.enabled = false;
                    Verloren3Script.enabled = true;
                }
                else if(PlayerScript.playerHealth == 0)
                {
                    Leben4Script.enabled = false;
                    Verloren4Script.enabled = true;
                }
                */

        // ALERTA ALERTA
        if (FollowScript.detectPlayer == true)
        {
            AlertScript.enabled = true;
        }
        else
        {
            AlertScript.enabled = false;
        }
    }
}
