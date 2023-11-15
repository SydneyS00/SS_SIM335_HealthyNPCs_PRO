using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class NPCMain : MonoBehaviour
{
    //NPC Main Script from following tutorial
    [SerializeField]
    private int _startingHP = 100;
    [SerializeField]
    private ParticleSystem deathParticlePrefab; 

    private int _currentHP;

    private float CurrentHpPct { get { return (float)_currentHP / (float)_startingHP; } }

    public event Action<float> OnHPPctChanged = delegate { };
    public event Action OnNPCDied = delegate { }; 


    internal void TakeDamage (int amount)
    {
        GetComponent<Health>().TakeDamage(amount); 
    }

    private void Start()
    {
        _currentHP = _startingHP;
    }

    private void Die()
    {
        OnNPCDied();
        GameObject.Destroy(this.gameObject); 
    }


}
