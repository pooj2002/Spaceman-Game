using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMeteor : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject waypoint;
    [SerializeField] private float speed = 4f;

    [SerializeField] private GameObject spawnManager;

    void Start()
    {
       waypoint = GameObject.Find("waypoint-end");
       spawnManager = GameObject.Find("meteor-spawn-waypoint");  
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, waypoint.transform.position, Time.deltaTime * speed);
        Debug.Log(transform.position-waypoint.transform.position);
        if(Mathf.Abs((transform.position-waypoint.transform.position).magnitude) <= 3f){
            // Debug.Log("Heloooooo");
            Destroy(gameObject);
            spawnManager.GetComponent<SpawnMeteor>().Spawn();
        }
    }
}
