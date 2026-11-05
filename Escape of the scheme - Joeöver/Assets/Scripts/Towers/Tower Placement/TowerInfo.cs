using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerInfo : MonoBehaviour
{
    [SerializeField] private int _value;
    private Rescources rescources;


    void Start()
    {

    }

    public void Destroy()
    {
        Destroy(gameObject);

        rescources = GameObject.FindAnyObjectByType<Rescources>();
        rescources.GainRecources(_value);
    }
}
