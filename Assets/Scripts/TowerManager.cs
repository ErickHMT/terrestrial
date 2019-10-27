using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TowerManager : MonoBehaviour {

    public float towerRadius = 3f;
    static int towerCompletion;

    [SerializeField] private Text t_text;

    private void Awake() {
        towerCompletion = 0;
    }

    private void Update() {
        GameObject closests = GetClosestRobots();
        // TODO verificar quantidade de robos próximos e incrementar torre

        // DISPLAY TOWER COMPLETION
        t_text.text = $"Tower: {towerCompletion}%";
    }

    GameObject GetClosestRobots() {
        GameObject[] robots = GameObject.FindGameObjectsWithTag("Selectable");

        GameObject closest = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach(GameObject potentialTarget in robots) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            
            if(dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;

                // TODO encontrar meio de identificar robos no raio da torre
                closest = potentialTarget;
            }
        }

        return closest;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, towerRadius);
    }
}
