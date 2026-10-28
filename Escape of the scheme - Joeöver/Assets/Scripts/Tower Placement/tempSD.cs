using UnityEngine;

public class tempSD : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    [SerializeField] private string _towerTag;

    public void doExitGame()
    {
        Debug.Log("Attempt to delete ", gameObject);
        Destroy(gameObject);
    }
}

//    void Update()
//    {
//        mousePosition = Input.mousePosition;

//        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

//        prevHoverObject = nextHoverObject;

//        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
//        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

//        if (nextHoverObject && nextHoverObject.CompareTag(_towerTag))
//        {
//            if (Input.GetMouseButtonDown(0))
//            {
//                Destroy(gameObject);
//            }
//        }
//    }
//}
