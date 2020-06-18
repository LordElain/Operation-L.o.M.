using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    public float m_rotationspeed = 10.0f;

    void Update()
    {
        this.transform.rotation *= Quaternion.Euler(0, 0, Time.deltaTime * m_rotationspeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        //Handle collection points here!
        CharacterControl PlayerScript = Player.GetComponent<CharacterControl>();
        if (other.gameObject.CompareTag("player"))
        {
            PlayerScript.playerMaxHealth--;
            PlayerScript.SlowDown();
            PlayerScript.score++;
            Destroy(this.gameObject);
        }
    }
}
