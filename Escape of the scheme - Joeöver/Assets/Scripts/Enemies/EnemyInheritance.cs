using UnityEngine;

abstract class EnemyInheritance : EnitityInheritance
{

    private EnitityInheritance _enity;
    private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tower"))
        {
            KillTower();
        }
    }

    public void KillTower()
    {
       // if(_enity.Hp <= 0)
       // {
            Destroy (gameObject);
       // }
    }
    
}
