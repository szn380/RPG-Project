using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform target;
    // Ray lastRay;    // last ray we shot 
   

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))   // if left mouse button clicked
        {
            MoveToCursor();
        }
    }

    private void MoveToCursor() 
    {
        // Debug.DrawRay(lastRay.origin, lastRay.direction * 100);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool hasHit = Physics.Raycast(ray, out hit);   // position of ray cast hit stored in "hit"
        if (hasHit)
        {
            NavMeshAgent agent = GetComponent<NavMeshAgent>(); 
            agent.destination = hit.point;
        }
    }
}
