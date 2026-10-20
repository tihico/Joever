using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;

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
        _tower = FindAnyObjectByType<TowerInheritance>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            
            Debug.Log("Dmged tower");
            _tower.DmgTaken();
            //doesn't specify a gameObject

        }
    }

    /*
    Forgot the get component and it doesn't know wich gameobject it 'touches'
    */

    /*   This is better used for the bullet
    private void OnCollision2D(Collision2D collision)
    {
        if (collision)
    }
    */
    public void DmgTaken() //make it so it defaults on BULLETS and change the layers so that towers can't hit eachother this way later bulelts CAN hit the tower :D but you'll have to add enemy to the tag props.
    {

    }

}
