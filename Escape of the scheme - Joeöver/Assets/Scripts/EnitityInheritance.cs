using UnityEngine;

abstract class EnitityInheritance : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private int _hp;
    [SerializeField] private string _name;
    [SerializeField] private GameObject _gameObject;

    public void death()
    {
        if(_hp <= 0)
        {
            Destroy (gameObject);
        }
    }
}
