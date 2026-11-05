using UnityEngine;

abstract class BarricadeInheritance : TowerInheritance
{
 [SerializeField] private float _armor;
   // private bool _attack = false;
    public override void DmgTaken(float Dmg)
    {     
        _hp -= Dmg / _armor;
        Attack(Dmg);
    }

    public void Attack(float Dmg)
    {
        Debug.Log("reflecting dmg");
       
            _dmg = _enemy.Dmg / 1.3f;
            _enemy.DmgTaken(_dmg);
    }
    //fixed the reflection dmg after a long hour of work xd, thigns i did wrong forgor enemy tag, was juggeling the Attack(); between the triggerstay and dmgtaken aka INSTA kill when i started it fixed that 1 quik. and i had to put 1.3f but had 3f :/
    private void OnTriggerStay2D(Collider2D collision)
    { //by THE component setting select collision continious & never sleeping to make the ontriggerstay act continiously+   
        print(collision.gameObject.name);
        if (collision.CompareTag("Enemy") || CompareTag("Hidden"))
        {
            _enemy = collision.GetComponent<EnemyInheritance>();
            
        }
    }

    

    //currently doesn't get dmged by the enemy does get detected tho so it's propably an instantiation problem so add a 
}
