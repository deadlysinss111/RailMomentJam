using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField] private ParticleSystem ParticleS;
    protected float m_health = 75f;
    public float m_healthMax = 75f;

    virtual public float GetHealth()
    {
        return m_health;
    }

    void Start()
    {
        if (ParticleS != null)
        {
            //set position of particle system
            ParticleS.SetParticles(new ParticleSystem.Particle[] { new ParticleSystem.Particle() { position = transform.position } }, 1);
        }
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
        if (ParticleS != null)
        {
            ParticleS.Play();
        }
        PlayerManager.instance.upScore();
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision _other)
    {
        CheckForDamage(_other.gameObject);
    }

    private void OnTriggerEnter(Collider other) 
    {
        CheckForDamage(other.gameObject);
    }

    private void CheckForDamage(GameObject _other)
    {
        Debug.Log("Collision with tag: " + _other.gameObject.tag);

        if (gameObject.CompareTag("player Life"))
        {
            TakeDamage(1);
            Debug.Log("player collision Life");
            return;
        }

        if (_other.gameObject.tag != "Projectil")
            return;

        if (this.gameObject.tag == _other.gameObject.tag)
            return;

        if (!(_other.gameObject.TryGetComponent<Projectile>(out Projectile projectile)))
            return;

        TakeDamage(projectile.GetDamage());
    }

    void Update()
    {
        //Debug.Log(m_health);
    }
}
