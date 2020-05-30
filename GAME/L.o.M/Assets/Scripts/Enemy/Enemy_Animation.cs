using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation : MonoBehaviour
{
    public EnemyControl Enemy;
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GetComponent<EnemyControl>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
