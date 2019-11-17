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
        // if (Input.GetMouseButtonDown(0))   // move when left mouse button clicked
        if (Input.GetMouseButton(0))   // move when left mouse button is held down
        {
            MoveToCursor();
        }
        UpdateAnimator();
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

    private void UpdateAnimator()
    {
        // Get global velocity from Nav Mesh Agent
        // Convert it to local velocity of the character (InverseTransformDirection())
        //    local velocity is from the rotational orientation of the character
        // Pass local speed into value of blend tree

        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);
        float speed = localVelocity.z;
        GetComponent<Animator>().SetFloat("forwardSpeed", speed);
    }
}
