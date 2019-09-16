using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    Rigidbody rbd;
    public int LifeSpan = 3;
    public int BulletSpeed = 1;
    public int BulletDamage = 1;
    private float TimeLeftToLive;
	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
        TimeLeftToLive = LifeSpan;
	}
	
	// Update is called once per frame
	void Update () {
        rbd.MovePosition(rbd.position + transform.forward * BulletSpeed * Time.deltaTime);
        ApplyLifeSpan();

    }
    private void ApplyLifeSpan()
    {
        TimeLeftToLive -= Time.deltaTime;
        if (TimeLeftToLive <0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter(Collider otherObject)
    {
        Damage damge = otherObject.gameObject.GetComponentInParent<Damage>();
        if (damge != null)
        {
            damge.TakeDamage(BulletDamage);
        }
        Die();
    }
}
