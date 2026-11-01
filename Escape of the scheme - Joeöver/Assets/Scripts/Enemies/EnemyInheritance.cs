using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;
    [SerializeField] private float _attackCooldown;
    private bool _attack = false;
    //private bool _barricadeDetected = false;

    private TowerInheritance _tower;


    public int Dmg
    {
        get 
        {
           return _dmg; 
        }
    }
    private void Start()
    {
       // _tower = FindAnyObjectByType<TowerInheritance>();
       // _barricade = FindAnyObjectByType<BarricadeInheritance>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
        print(collision.gameObject.name);
        if (collision.CompareTag("Tower") || collision.CompareTag("Barricade"))
        {
            _tower = collision.GetComponent<TowerInheritance>();  
            Debug.Log("Dmged tower");

            //the boolean makes sure that the startcoroutine isn't constantly activated
            if (!_attack)
                StartCoroutine(Attack(_attackCooldown));
        }
        

        
    }


    
    IEnumerator Attack(float attackCooldown)
    {
        _attack = true;
        yield return new WaitForSeconds(attackCooldown);
        //_tower.DmgTaken();
        _tower.DmgTaken(_dmg);
        _attack = false;     
    }
   


    public void Update()
    {
        Death();  
        //add coin increase / spawn here
    }

    public void DmgTaken(float Dmg) 
    //make it so it defaults on BULLETS and change the layers so that towers can't hit eachother this way later bulelts CAN hit the tower :D but you'll have to add enemy to the tag props.
    {

        _hp -= Dmg;
       // _hp -= _barricade.Dmg;

    }
}
