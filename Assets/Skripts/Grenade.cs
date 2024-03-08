using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public GameObject explosionPrefab;
    public float deley = 3;
    private void OnCollisionEnter(Collision collision)
    {
        Invoke("Explosion", deley);
    }

    private void Explosion()
    {
        Destroy(gameObject);
        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
