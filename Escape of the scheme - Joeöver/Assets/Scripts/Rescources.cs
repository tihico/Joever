using TMPro;
using UnityEngine;

public class Rescources : MonoBehaviour
{
    [SerializeField] private int _rescources;
    [SerializeField] private GameObject _text;


    public void GainRecources(int ammount)
    {
        _rescources += ammount;

        //rescource display for the UI
        _text.GetComponent<TextMeshProUGUI>().text = $"Rescources: {_rescources}";
    }
}
