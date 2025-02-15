using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    protected float m_health = 75f;
    public float m_healthMax = 75f;

    virtual public float GetHealth()
    {
        return m_health;
    }

    void Start()
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

    private void Die()
    {
        PlayerManager.instance.upScore();
        gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision _other)
    {
        Debug.Log("collision");
        if (_other.gameObject.tag != "Projectil")return;
        if (this.gameObject.tag == _other.gameObject.tag)return;
        if (!(_other.gameObject.TryGetComponent<Projectil>(out Projectil projectile)))return;
        if (!_other.gameObject.TryGetComponent<Life>(out Life life))return;


        if (projectile.bTakeDamage)
        {
            life.TakeDamage(projectile.GetDamage());
        }
        TakeDamage(projectile.GetDamage());
        Debug.Log(projectile.GetDamage());


    }
    void Update()
    {
        //Debug.Log(m_health);
    }
}
