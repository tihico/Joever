using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerInfo : MonoBehaviour
{
    [SerializeField] private int _tower;

    void Start()
    {

    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
