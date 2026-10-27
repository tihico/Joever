using UnityEngine;

 class BarricadeInheritance : TowerInheritance
{
 [SerializeField] private int _armor;
    public override void DmgTaken()
    {
        _hp -= _enemy.Dmg / _armor;
        Attack();
    }

    public override void Attack()
    {
       _dmg = _enemy.Dmg / 3;
    }

    //currently doesn't get dmged by the enemy does get detected tho so it's propably an instantiation problem so add a 
}
