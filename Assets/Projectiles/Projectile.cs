using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField] private float speed = 1000;
    [SerializeField] private int damage = 1;
    [SerializeField] private float lifeTimeMax = 1;  
    [SerializeField] private bool haveLifeTime = true;
    
    private float currentLifeTime = 0;

    public int GetDamage()
    {
        return damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (haveLifeTime) {
            currentLifeTime += Time.deltaTime;
            if (currentLifeTime >= lifeTimeMax)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
