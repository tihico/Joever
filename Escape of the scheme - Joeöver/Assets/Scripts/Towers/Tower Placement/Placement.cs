using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;
using static UnityEngine.Rendering.DebugUI;

public class Placement : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    [SerializeField] private string _mapTag;
    [SerializeField] private string _pathTag;
    [SerializeField] private GameObject _towerOne;
    [SerializeField] private GameObject _towerTwo;
    [SerializeField] private GameObject _towerThree;
    [SerializeField] private GameObject _towerFour;

    [SerializeField] private int _towerOneValue;
    [SerializeField] private int _towerTwoValue;
    [SerializeField] private int _towerThreeValue;
    [SerializeField] private int _towerFourValue;

    private int _towerSelected = 0;

    private Rescources rescources;

    /*Dit script zorgt ervoor dat je towers kan plaatsen als je 1 van ze selecteert met de GUI.
    Het gebruikt je muis position om te bepalen waar je de tower plaatst.*/

    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D? raycastHit2D.collider.transform : null;

        if (nextHoverObject && nextHoverObject.CompareTag(_mapTag))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = raycastHit2D.transform.position;

                rescources = GameObject.FindAnyObjectByType<Rescources>();

                if (_towerSelected == 1 && rescources.CheckResources() >= _towerOneValue)
                {
                    Instantiate(_towerOne, mouseRay.origin, quaternion.identity);

                    rescources.GainRecources(-_towerOneValue);
                    _towerSelected = 0;
                }
                else if (_towerSelected == 2 && rescources.CheckResources() >= _towerTwoValue)
                {
                    Instantiate(_towerTwo, mouseRay.origin, quaternion.identity);

                    rescources.GainRecources(-_towerTwoValue);
                    _towerSelected = 0;
                }
            }
        }
        else if (nextHoverObject && nextHoverObject.CompareTag(_pathTag))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = raycastHit2D.transform.position;

                rescources = GameObject.FindAnyObjectByType<Rescources>();

                if (_towerSelected == 3 && rescources.CheckResources() >= _towerThreeValue)
                {
                    Instantiate(_towerThree, mouseRay.origin, quaternion.identity);

                    rescources.GainRecources(-_towerThreeValue);
                    _towerSelected = 0;
                }
                else if (_towerSelected == 4 && rescources.CheckResources() >= _towerFourValue)
                {
                    Instantiate(_towerFour, mouseRay.origin, quaternion.identity);

                    rescources.GainRecources(-_towerFourValue);
                    _towerSelected = 0;
                }
            }
        }
    }


    public void TowerOne()
    {
        _towerSelected = 1;
    }

    public void TowerTwo()
    {
        _towerSelected = 2;
    }

    public void TowerThree()
    {
        _towerSelected = 3;
    }

    public void TowerFour()
    {
        _towerSelected = 4;
    }
}
