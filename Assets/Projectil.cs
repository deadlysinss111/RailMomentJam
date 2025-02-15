using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField]private float speed = 1000;
    private Vector3 direction;
    public int damage = 10;
    private float lifeTime = 0;
    public bool haveLifeTime = true;
    public bool bTakeDamage = true;


    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int _damage)
    {
        damage = _damage;
    }
    void Start()
    {
        Rigidbody.AddForce(direction * speed);
        SetDamage(damage);
    }

    // Update is called once per frame
    void Update()
    {
        if (haveLifeTime) {
            lifeTime += Time.deltaTime;
            if (lifeTime >= 1)
            {
                Destroy(this.gameObject);
            }
        }

    }
}
