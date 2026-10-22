using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEditor.FilePathAttribute;

public class Hover : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    [SerializeField] private string _towerSpotTag;
    [SerializeField] private GameObject _towerPrefab;

    [SerializeField] private Color hoverdColor;
    [SerializeField] private Color unhoverdColor;

    private bool towerPlaced = false;

    void Start()
    {
        
    }

    // Update is called once per frame
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

                Instantiate(_towerPrefab, position, quaternion.identity);
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
}
