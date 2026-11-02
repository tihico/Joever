using UnityEngine;

public class Rescources : MonoBehaviour
{
    [SerializeField] private int _rescources;



    public void GainRecources(int ammount)
    {
        _rescources += ammount;
    }
}
