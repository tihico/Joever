using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;
    private EnitityInheritance _enity;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            //make it deal dmg
        }
    }
    
}
