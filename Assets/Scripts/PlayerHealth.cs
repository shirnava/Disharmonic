using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public float damage = 50;
    public float hitPause = 5f;
    public float hitCounter;
    public bool attackDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        if (hitCounter > 0)
        {
            hitCounter -= Time.deltaTime;
            attackDisabled = true;

        }
        if (hitCounter <= 0)
        {
            attackDisabled = false;
        }
    }

    public void takeDamage()
    {
        if (hitCounter <= 0)
        {
            if (currentHealth >= 50)
            {
                currentHealth -= damage;
                hitCounter = hitPause;
                FindObjectOfType<AudioManager>().Play("spirit");

                if(currentHealth == 0)
                {
                    Destroy(GameObject.FindWithTag("Ddme"));
                    Destroy(GameObject.FindWithTag("TestThrowCube"));
                    SceneManager.LoadScene("MainMenu");
                }
            }

        }
    }
}
