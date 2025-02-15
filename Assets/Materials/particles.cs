using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particles : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    // Start is called before the first frame update
    void Start()
    {
    }
    public void OnEnable()
    {
        _particleSystem.Play();
    }
    public void positionparticul(Transform _transform)
    {
        _particleSystem.transform.position = _transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
