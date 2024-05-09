using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private int fullhealth;
    public int exp = 0;
    public int maxHealth=100;
    public int maxExp = 100;
    public int level = 0;
    public int baseExp;
    public int baseLevel = 0;
    public int baseMaxExp = 0;

    private void Start()
    {

        Finish scenes = FindObjectOfType<Finish>().GetComponent<Finish>();
        if(scenes.lvl != 0)
        {
            level = PlayerPrefs.GetInt("level", 0);
            exp = PlayerPrefs.GetInt("exp", 0);
            maxExp = PlayerPrefs.GetInt("maxExp", 100);
            health = 100 + 50 * level;
            maxHealth = 100 + 50 * level;
        }
        else
        {
            health = 100;
            maxHealth = 100;
            level = 0;
            exp = 0;
            maxExp = 100;
        }    
        fullhealth = health;
        baseExp = this.exp;
        baseMaxExp = this.maxExp;
        baseLevel = this.level;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int amount)
    {
        if (amount < 0) 
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }
        this.health -= fullhealth * (100-amount)/100;

        if(health <= 0)
        {
            PlayerLife life = this.GetComponent<PlayerLife>();
            Base(baseLevel,baseExp,baseMaxExp);
            life.Die();
        }
    }

    public void Healing(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > maxHealth;

        if(wouldBeOverMaxHealth)
        {
            this.health = maxHealth;
        }
        else
        {
            this.health += amount;
        }
        
    }

    public void Experience(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative exp");
        }

        bool wouldBeOverMaxHealth = this.exp + amount > maxExp;

        if (wouldBeOverMaxHealth)
        {
            level++;
            this.exp = this.exp + amount - maxExp;
            this.maxExp += 200;
            this.maxHealth += 50;
            this.health += 50;
            this.fullhealth += 50;
            PlayerPrefs.SetInt("level", level);
            PlayerPrefs.SetInt("maxExp", this.maxExp);
        }
        else
        {
            this.exp += amount;
        }
        PlayerPrefs.SetInt("exp",exp);
    }

    public void Base(int level,int exp, int maxExp)
    {
        PlayerPrefs.SetInt("level", level);
        PlayerPrefs.SetInt("maxExp", maxExp);
        PlayerPrefs.SetInt("exp", exp);
    }    
}
