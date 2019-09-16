using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Ennemi : MonoBehaviour, Damage{
    public int LifeTotal = 1;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TakeDamage(int Degat)
    {
        LifeTotal -= Degat;
        if (LifeTotal <= 0)
        {
            Die();
        }
    }
    public abstract void Die();
    
    protected void SetLife(int NewLifeTotal)
    {
        LifeTotal = NewLifeTotal;
    }
}
