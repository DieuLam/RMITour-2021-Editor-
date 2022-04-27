using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.AI;

public class SetNavigationTarget : MonoBehaviour
{

    [SerializeField]
    private TMP_Dropdown navigationTargetDropDown;
    [SerializeField]
    private List<Target> navigationTargetObjects = new List<Target>();

    private NavMeshPath path;   // current calculated path
    private LineRenderer line;  // line to display the path
    private Vector3 targetPosition = Vector3.zero;

    private bool lineToggle = false;
    public static Transform tempDes;

    // Start is called before the first frame update
    public void Start()
    {
        path = new NavMeshPath();
        line = transform.GetComponent<LineRenderer>();
        line.enabled = lineToggle;
    }

    // Update is called once per frame
    private void Update()
    {
        // if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        // {
        //     lineToggle = !lineToggle;
        // }

        if (lineToggle && targetPosition != Vector3.zero)
        {
            NavMesh.CalculatePath(transform.position, targetPosition, NavMesh.AllAreas, path);
            line.positionCount = path.corners.Length;
            line.SetPositions(path.corners);
        }
    }

    public void SetCurrentNavigationTarget(int selectedValue) {
        targetPosition = Vector3.zero;
        string selectedText = navigationTargetDropDown.options[selectedValue].text;
        Target currentTarget = navigationTargetObjects.Find(x => x.Name.Equals(selectedText));
        if (currentTarget != null) {
            targetPosition = currentTarget.PositionObject.transform.position;
            tempDes = currentTarget.PositionObject.transform;
            lineToggle = true;
            line.enabled = lineToggle;
        }
    }

    // public void ToggleVisibility() {
    //     lineToggle = !lineToggle;
    //     line.enabled = lineToggle;
    // }
}
