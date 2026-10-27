using UnityEngine;

 class TowerInheritance : EnitityInheritance
{
    [SerializeField] protected int _dmg;
    [SerializeField] protected int _range;


    protected EnemyInheritance _enemy;
    public int Dmg
    {
        get
        {
            return _dmg;
        }
    }
    public void Start()
    {
        _enemy = FindAnyObjectByType<EnemyInheritance>();
    }
    public virtual void Attack()
    {
        //spawn bullet here
    }

    public virtual void DmgTaken()
    {
        _hp -= _enemy.Dmg;
    }

    public void Update()
    {
        Death();
    }
  
}
//make the target prioritisation of the towers based off of who is first through a list and adque (adque might not be it but it's simular)
