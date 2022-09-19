using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        float randomPosX = Random.Range(-50f, 50f);
        float randomPosZ = Random.Range(-50f, 50f);
        Vector3 randomPosition = new Vector3(randomPosZ, 1f,randomPosZ);  
        GameObject playerObj
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
