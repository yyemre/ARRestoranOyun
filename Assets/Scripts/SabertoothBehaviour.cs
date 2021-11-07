using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SabertoothBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public ReticleBehaviour Reticle;
    public float Speed = 1.2f;
    public Animator animator;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        var trackingPosition = Reticle.transform.position;
        if (Vector3.Distance(trackingPosition, transform.position) < 0.1)
        {
            animator.SetInteger("Movement State", 0);
            return;
        }
        if (Vector3.Distance(trackingPosition, transform.position) < 0.3)
        {
            animator.SetInteger("Movement State", 1);
            Speed = 0.5f;

        }
        else
        {
            animator.SetInteger("Movement State", 2);
            Speed = 1.2f;
        }
        var lookRotation = Quaternion.LookRotation(trackingPosition - transform.position);
        transform.rotation =
            Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        transform.position =
            Vector3.MoveTowards(transform.position, trackingPosition, Speed * Time.deltaTime);
        
    }
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "BurgerTag")
        {
            animator.SetBool("Bite", true);
        }

        var Package = other.GetComponent<PackageBehaviour>();
        if (Package != null)
        {
            Destroy(other.gameObject);
        }
    }
}
