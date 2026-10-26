using UnityEngine;

public class DestroyTower : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    [SerializeField] private string _towerTag;

    [SerializeField] private GameObject Gui;

    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;
    }

    public void Sell()
    {
        if (nextHoverObject && nextHoverObject.CompareTag(_towerTag))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Destroy(gameObject);
            }
        }
    }
}
