using UnityEngine;

abstract class EnitityInheritance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int _hp;

    public virtual void DmgTaken()
    {

    }
}
