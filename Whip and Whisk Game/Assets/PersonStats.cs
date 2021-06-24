using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonStats : MonoBehaviour {

    public Animator person;

    public string PlayerName;

    public float maxHealth;
    public float currentHealth;
    public float healthIncreaseMulti = 0.25f;

    public int defencePoints;

    bool HadDied = false;

    public GameObject target;

    public Image HealthBoarder;

    public GameObject HeartSystem;
    GameObject instantHS;

	// Use this for initialization

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ApplyDamage(int amount)
    {
        currentHealth -= (amount - defencePoints);
    }

    public void ApplyHealth(int amount)
    {
        currentHealth += amount;
    }

    void Update()
    {
        if(currentHealth < 0 && !HadDied)
        {
            Debug.Log(PlayerName + " has fainted from the preasure of taste!");
            person.SetInteger("RandDie", Random.Range(0, 2));
            person.SetTrigger("HasDied");
            HadDied = true;

            target.GetComponent<ThirdPersonCamera>().HadDied = true;
            instantHS = Instantiate(HeartSystem, transform.position, Quaternion.identity);
            instantHS.transform.Rotate(new Vector3(-90f, 0f, 0f));
            instantHS.transform.position += new Vector3(0, 2f, 0);

        }
        if (!HadDied)
        {
            if(currentHealth < maxHealth)
            {
                currentHealth += 1 * healthIncreaseMulti;
            }

            if (HealthBoarder)
            {
                HealthBoarder.fillAmount = 1 - (currentHealth / maxHealth);
            }
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("been hit wow");
        if(other.CompareTag("Throw") || other.CompareTag("Bullet"))
        {
            Debug.Log("applying damage");
            ApplyDamage(other.GetComponent<WeaponStats>().DamageValue);

            //ApplyDamage(10);

            //ApplyDamage(10);
        }
    }
}
