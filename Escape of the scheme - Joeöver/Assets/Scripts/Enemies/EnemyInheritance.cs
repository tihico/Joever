using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;
    [SerializeField] private float _attackCooldown;
    private bool _attack = false;
    private bool _slowAttack = false;

    private TowerInheritance _tower;
    private BarricadeInheritance _barricade;


    public int Dmg
    {
        get 
        {
           return _dmg; 
        }
    }
    private void Start()
    {
        _tower = FindAnyObjectByType<TowerInheritance>();
        _barricade = FindAnyObjectByType<BarricadeInheritance>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
        print(collision.gameObject.name);
        if (collision.CompareTag("Tower"))
        {
            
            Debug.Log("Dmged tower");

            //the boolean makes sure that the startcoroutine isn't constantly activated
            if (!_attack)
                StartCoroutine(Attack(_attackCooldown));
        }

        if (collision.CompareTag("Barricade"))
        {

            float _prolongedCooldown = _attackCooldown * 1.5f;

            Debug.Log("Dmged tower");

            //the boolean makes sure that the startcoroutine isn't constantly activated
            if (!_slowAttack)
                StartCoroutine(Attack2(_prolongedCooldown));
        }
    }


    
    IEnumerator Attack(float attackCooldown)
    {
        _attack = true;
        yield return new WaitForSeconds(attackCooldown);
        _tower.DmgTaken();
        _attack = false;     
    }
    IEnumerator Attack2(float prolongedCooldown)
    {
        _slowAttack = true;
        yield return new WaitForSeconds(prolongedCooldown);
        _barricade.DmgTaken();
        _slowAttack = false;
    }


    public void Update()
    {
        Death();  
        //add coin increase / spawn here
    }

    public void DmgTaken() 
    //make it so it defaults on BULLETS and change the layers so that towers can't hit eachother this way later bulelts CAN hit the tower :D but you'll have to add enemy to the tag props.
    {
        _hp -= _tower.Dmg;
    }
}
