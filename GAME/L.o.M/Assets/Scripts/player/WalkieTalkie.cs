using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkieTalkie : MonoBehaviour
{
    public GameObject Player;
    public AudioClip Walkie;
    AudioSource audioData;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Player.transform.position, this.transform.position) < 2)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioData.Play();
                Debug.Log("Spieler ist in Reichweite");
            }
        }

    }
}
