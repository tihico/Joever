using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] protected float _dmg;
    [SerializeField] protected float _attackCooldown;
    [SerializeField] protected int _goldGain;
    protected bool _attack = false;
    //private bool _barricadeDetected = false;
    protected Rescources _rescources;
    protected TowerInheritance _tower;


    public float Dmg
    {
        get 
        {
           return _dmg; 
        }
    }
    private void Start()
    {
       _rescources = FindAnyObjectByType<Rescources>();

    }
    private void OnTriggerStay2D(Collider2D collision)
    { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
        //print(collision.gameObject.name);
        if (collision.CompareTag("Tower") || collision.CompareTag("Barricade"))
        {
            _tower = collision.GetComponent<TowerInheritance>();  
            Debug.Log("Dmged tower");

            //the boolean makes sure that the startcoroutine isn't constantly activated
            if (!_attack)
                StartCoroutine(Attack(_attackCooldown));
        }
        

        
    }


    
  public virtual IEnumerator Attack(float attackCooldown)
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

    public void GoldDrop()
    {
        _rescources.GainRecources(_goldGain);
    }
    public override void Death()
    {
        if (_hp <= 0)
        {
            GoldDrop();
            Destroy(gameObject);
        }

    }
    public void DmgTaken(float Dmg) 
    //make it so it defaults on BULLETS and change the layers so that towers can't hit eachother this way later bulelts CAN hit the tower :D but you'll have to add enemy to the tag props.
    {

        _hp -= Dmg;
       // _hp -= _barricade.Dmg;

    }
}
