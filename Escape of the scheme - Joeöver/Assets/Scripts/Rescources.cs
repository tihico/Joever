using TMPro;
using UnityEngine;

public class Rescources : MonoBehaviour
{
    [SerializeField] private int _resources;
    [SerializeField] private TextMeshProUGUI _text;

    void Start()
    {
        _text.text = $"Resources: {_resources}";
    }

    public void GainRecources(int amount)
    {
        _resources += amount;

        ChangeText();
    }

    public int Test()
    {
        return _resources;
    }

    public void ChangeText()
    {
        //resource display for the UI
        _text.text = $"Resources: {_resources}";
    }
}
