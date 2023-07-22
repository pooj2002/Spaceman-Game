using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMeteor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject meteor;
    void Start()
    {
        Spawn();
    }
    public void Spawn(){
        Instantiate(meteor,transform.position,Quaternion.identity);
    }


}
