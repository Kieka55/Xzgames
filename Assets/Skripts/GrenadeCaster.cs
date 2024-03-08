using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public Rigidbody GrenadePrefab;
    public Transform GrenadeSourceTransform;
    public float force = 10;
    
    void Start()
    {
       
    }

    
    void Update()
    {
        DropGranata();
    }

    private void DropGranata()
    {
        if(Input.GetMouseButtonDown(1))
        {
            var grenade = Instantiate(GrenadePrefab);
            grenade.transform.position = GrenadeSourceTransform.position;
            grenade.GetComponent<Rigidbody>().AddForce(GrenadeSourceTransform.forward   *   force);
        }
    }
}
