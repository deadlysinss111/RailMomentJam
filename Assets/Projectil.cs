using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] private Rigidbody Rigidbody;
    [SerializeField]private float speed = 1;
    [SerializeField]private int MaxHitpoint = 1;
    private Vector3 direction;
    private float lifeTime = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Cible")
        {
            MaxHitpoint--;
            if (MaxHitpoint <= 0)
            {
                Destroy(this.gameObject);
            }
            print("Enter");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        lifeTime+= Time.deltaTime;
        Debug.Log(lifeTime);
        if (lifeTime >= 1)
        {
            Debug.Log("Destroy");
            Destroy(this.gameObject);
        }
    }
}
