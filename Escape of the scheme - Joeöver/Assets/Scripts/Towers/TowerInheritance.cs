using UnityEngine;

 class TowerInheritance : EnitityInheritance
{
    [SerializeField] private int _dmg;
    [SerializeField] private int _range;

    private EnemyInheritance _enemy;
    public void Attack()
    {
        //spawn bullet here
    }

    public void DmgTaken()
    {
        _hp -= _enemy.Dmg;
    }

  
}
//make the target prioritisation of the towers based off of who is first through a list and adque (adque might not be it but it's simular)
