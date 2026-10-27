using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class TowerGUI : MonoBehaviour
{
    Vector3 mousePosition;
    RaycastHit2D raycastHit2D;
    Transform prevHoverObject, nextHoverObject;

    [SerializeField] private string _towerTag;

    [SerializeField] private GameObject _gui;

    private string _selectedTower;

    private bool _guiCheck = false;

    void Update()
    {
        mousePosition = Input.mousePosition;

        Ray mouseRay = Camera.main.ScreenPointToRay(mousePosition);

        prevHoverObject = nextHoverObject;

        raycastHit2D = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);
        nextHoverObject = raycastHit2D ? raycastHit2D.collider.transform : null;

        if (nextHoverObject && nextHoverObject.CompareTag(_towerTag))
        {
            if (Input.GetMouseButtonDown(0) && !_guiCheck)
            {
                _gui.SetActive(true);
                _guiCheck = true;
            }
        }
    }

    public void GuiCheck()
    {
        _guiCheck = false;
    }

    public void SellTower()
    {
        _selectedTower = raycastHit2D.transform.gameObject.name;
        //Debug.Log(_selectedTower);
        //Destroy(GameObject.Find(_selectedTower));
    }
}
