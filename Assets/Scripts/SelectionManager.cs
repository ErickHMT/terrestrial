using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour {

    [SerializeField] private string selectableTag = "Selectable";
    private Transform _selection;

    void Update() {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out var hit, 100)) {

            // Debug.DrawLine(ray.origin, hit.point, Color.red);
            var selection = hit.transform;

            if(isSelectable(selection) && Input.GetMouseButton(0)) {
                RobotController selectableController = selection.GetComponent<RobotController>();
                if (selectableController != null) selectableController.SelectObject();
            }
        }
    }

    private bool isSelectable(Transform selection) {
        return selection.CompareTag(selectableTag);
    }
}
