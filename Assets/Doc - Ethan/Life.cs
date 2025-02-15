using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    protected float m_health = 75f;
    protected float m_healthMax = 75f;
    public float damageAmount = 10f;

    virtual public float GetHealth()
    {
        return m_health;
    }

    virtual public void SetHealth()
    {
        m_health = m_healthMax;
    }

    virtual public void TakeDamage(float damage)
    {
        m_health -= damage;
        Debug.Log($"collision on health: {m_health}");
        if (m_health <= 0)
        {
            Die();
            Debug.Log($"die: {m_health}");
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
    void OnCollisionEnter(Collision _other)
    {
        if (_other.gameObject.tag != "Obstacle")
        {
            return;
        }
        TakeDamage(damageAmount);
    }
}
