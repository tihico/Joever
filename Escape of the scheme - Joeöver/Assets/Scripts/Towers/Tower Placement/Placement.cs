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

    [SerializeField] private string _towerSpotTag;
    [SerializeField] private GameObject _towerOne;
    [SerializeField] private GameObject _towerTwo;
    [SerializeField] private GameObject _towerThree;
    [SerializeField] private GameObject _towerFour;

    [SerializeField] private Color hoverdColor;
    [SerializeField] private Color unhoverdColor;

    [SerializeField] private int _towerOneValue;
    [SerializeField] private int _towerTwoValue;
    [SerializeField] private int _towerThreeValue;
    [SerializeField] private int _towerFourValue;

    private int _towerSelected = 1;

    private Rescources rescources;

    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D? raycastHit2D.collider.transform : null;

        if (nextHoverObject && nextHoverObject.CompareTag(_towerSpotTag))
        {
            nextHoverObject.GetComponent<SpriteRenderer>().color = hoverdColor;

            if (Input.GetMouseButtonDown(0))
            {
                Vector3 position = raycastHit2D.transform.position;

                rescources = GameObject.FindAnyObjectByType<Rescources>();

                if (_towerSelected == 1 && rescources.Test() >= _towerOneValue)
                {
                    Instantiate(_towerOne, position, quaternion.identity);

                    rescources.GainRecources(-_towerOneValue);
                }
                else if (_towerSelected == 2 && rescources.Test() >= _towerTwoValue)
                {
                    Instantiate(_towerTwo, position, quaternion.identity);

                    rescources.GainRecources(-_towerTwoValue);
                }
                else if (_towerSelected == 3 && rescources.Test() >= _towerThreeValue)
                {
                    Instantiate(_towerThree, position, quaternion.identity);

                    rescources.GainRecources(-_towerThreeValue);
                }
                else if (_towerSelected == 4 && rescources.Test() >= _towerFourValue)
                {
                    Instantiate(_towerFour, position, quaternion.identity);

                    rescources.GainRecources(-_towerFourValue);
                }
            }

        }
        else
        {
            if (prevHoverObject && prevHoverObject.CompareTag(_towerSpotTag))
            {
                prevHoverObject.GetComponent<SpriteRenderer>().color = unhoverdColor;
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
