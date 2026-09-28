using UnityEngine;

public class TowerInheritance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int _dmg;
    [SerializeField] private int _range;
    public void Attack()
    {
        //spawn bullet here
    }

    public void DmgTaken()
    {

    }
    
        private void OnCollisionEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            //_hp -= 
        }
    }
}

