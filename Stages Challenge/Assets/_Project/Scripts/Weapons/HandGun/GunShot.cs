using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class GunShot : Shot
{
    private void OnCollisionEnter(Collision other)
    {
        GameObject go = other.collider.gameObject;
        Enemy enemy = go.GetComponentInParent<Enemy>();

        if(go.layer == 9 || go.layer == 10)
        {
            enemy.Death(go.layer);
        }

        Destroy(gameObject);
    }
}
