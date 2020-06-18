using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameTrigger : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 2)
        {
            CharacterControl PlayerScript = Player.GetComponent<CharacterControl>();
            PlayerScript.gameEnd = true;
        }
    }
}
