using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

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

    private int _towerSelected = 1;

    private bool towerPlaced = false;

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

            if (Input.GetMouseButtonDown(0) && !towerPlaced)
            {
                Vector3 position = raycastHit2D.transform.position;

                if (_towerSelected == 1)
                {
                    Instantiate(_towerOne, position, quaternion.identity);
                }
                else if (_towerSelected == 2)
                {
                    Instantiate(_towerTwo, position, quaternion.identity);
                }
                else if (_towerSelected == 3)
                {
                    Instantiate(_towerThree, position, quaternion.identity);
                }
                else if (_towerSelected == 4)
                {
                    Instantiate(_towerFour, position, quaternion.identity);
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
