using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;
    public int Dmg
    {
        get 
        {
           return _dmg; 
        }
    }

    private TowerInheritance _tower;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            _tower.DmgTaken();
        }
    }

    public void DmgTaken() //make it so it defaults on BULLETS and change the layers so that towers can't hit eachother this way later bulelts CAN hit the tower :D but you'll have to add enemy to the tag props.
    {

    }

}
