using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    protected float m_health = 75f;
    protected float m_healthMax = 75f;

    virtual public float GetHealth()
    {
        return m_health;
    }
    virtual public void SetHealth()
    {
        m_health = m_healthMax ;
    }

    virtual public void TakeDamage(float damage)
    {
        m_health -= damage;
    }
    void Update()
    {
        //afficher la vie
    }
}
