using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotController : MonoBehaviour {

    [SerializeField] private bool isSelected = false;
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;
    Renderer rend;
    Transform target;

    public float speed = 2f;

    void Awake() {
        rend = GetComponent<Renderer>();
        rend.material = defaultMaterial;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
            DeselectObject();

        SetTarget();

        if (isSelected && target != null) {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);

            // if(Vector3.Distance(transform.position, target.position) < 0.1f) target.position *= -1f;
        }
    }

    void SetTarget() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            Debug.DrawLine(ray.origin, hit.point, Color.green);

            if(Input.GetMouseButton(0)) {
                target = hit.transform;
                Debug.Log("The target in now: " + target + " " + hit.point);
            }
        }
    }

    public void SelectObject(){
        isSelected = true;
        rend.material = highlightMaterial;
    }

    public void DeselectObject() {
        isSelected = false;
        rend.material = defaultMaterial;
    }

}
