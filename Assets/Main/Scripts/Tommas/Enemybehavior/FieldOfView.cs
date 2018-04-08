using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour {
    public float viewRadius;
    [Range(0,360)]
    public float viewAngel;

    public LayerMask targetMask;
    public LayerMask obstiaclMask;

    [HideInInspector]
    public List<Transform> visableTargets = new List<Transform>();

    void Start() {
        StartCoroutine("FindTargetsWithDealy", .2f);
    }

    IEnumerator FindTargetsWithDealy(float dealy) {
        while (true) {
            yield return new WaitForSeconds(dealy);
            FindVisibleTargets();
        }
    } 
    
    void FindVisibleTargets() {
        visableTargets.Clear(); 
        Collider[] targetInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);
        
        for (int i = 0; i < targetInViewRadius.Length; i++) {
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if(Vector3.Angle(transform.forward, dirToTarget) < viewAngel / 2) {
                float distToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, obstiaclMask)) {
                    // Enable Enemy Behavior
                    EnemyBehavior.ISTargetInRange = true; 
                    visableTargets.Add (target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDeg, bool angleISGlobal) {
        if (!angleISGlobal) {
            angleInDeg += transform.eulerAngles.y; 
    }
        return new Vector3(Mathf.Sin(angleInDeg * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDeg * Mathf.Deg2Rad));
}


}
