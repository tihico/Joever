using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerInfo : MonoBehaviour
{
    [SerializeField] private int _value;
    private Rescources rescources;

    /*Dit script zit op elke tower en zorgt ervoor dat je elke tower een unieke value kan geven--
    van resources die je terug krijgt als je de tower verkoopt.*/

    public void Destroy()
    {
        Destroy(gameObject);

        rescources = GameObject.FindAnyObjectByType<Rescources>();
        rescources.GainRecources(_value);
    }
}
