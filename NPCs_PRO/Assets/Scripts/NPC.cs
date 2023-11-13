using System;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private float turnSpeed = 90f;
    [SerializeField] private int startingHp = 100;
    [SerializeField] private UnityEngine.UI.Slider hpBarSlider = null;
    [SerializeField] private ParticleSystem deathParticlePrefab = null;
    [SerializeField] private int currentHp;

    //Variables to assign for production 
    public GameObject blueObj;
    public GameObject blackObj; 

    private void Start()
    {
        currentHp = startingHp;

        //Checking to see if the blue and black objects have been assigned
        if(blueObj != null)
        {
            //Check to see if the blue object has a blue tag name
            if(blueObj.CompareTag("Blue"))
            {
                Debug.Log("The blue object is assigned. Press Space to Destroy");
            }
            else
            {
                Debug.Log("The blue object does not have the tag...");
            }
        }

        if(blackObj != null)
        {
            if(blackObj != null)
            {
                Debug.Log("The black object is assigned. Press E to destroy");
            }
            else
            {
                Debug.Log("The black object does not have a tag...");
            }
        }
    }
    private void Update()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
        transform.Rotate(0f, turnSpeed * Time.deltaTime, 0f);
        hpBarSlider.transform.LookAt(Camera.main.transform);

        //Having different buttons to destroy for different objects
        
    }
    internal void TakeDamage(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException("Invalid Damage amount specified: " + amount);

        currentHp -= amount;

        UpdateUI();

        if (currentHp <= 0)
            Die();
    }

    private void UpdateUI()
    {
        var currentHpPct = (float)currentHp / (float)startingHp;

        hpBarSlider.value = currentHpPct;
    }

    private void Die()
    {
        PlayDeathParticle();
        GameObject.Destroy(this.gameObject);
    }

    private void PlayDeathParticle()
    {
        var deathparticle = Instantiate(deathParticlePrefab, transform.position, deathParticlePrefab.transform.rotation);
        Destroy(deathparticle, 4f);
    }

    

}