using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthBar : MonoBehaviour
{
    public GameObject HUD;
    public GameObject Following;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Canvas HUDScript = HUD.GetComponent<Canvas>();
        Follow FollowScript = Following.GetComponent<Follow>();
        CharacterControl PlayerScript = Player.GetComponent<CharacterControl>();

        if (PlayerScript.playerHealth == 5)
        {
            HUDScript.Hea
        }


    }
}
