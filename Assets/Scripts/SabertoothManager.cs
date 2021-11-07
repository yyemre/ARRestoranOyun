using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SabertoothManager : MonoBehaviour
{
    public GameObject CarPrefab;
    public ReticleBehaviour Reticle;
    public DrivingSurfaceManager DrivingSurfaceManager;

    public SabertoothBehaviour SB;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (SB == null && WasTapped() && Reticle.CurrentPlane != null)
        {

            var obj = GameObject.Instantiate(CarPrefab);
            SB = obj.GetComponent<SabertoothBehaviour>();
            SB.Reticle = Reticle;
            SB.transform.position = Reticle.transform.position;
            DrivingSurfaceManager.LockPlane(Reticle.CurrentPlane);
        }


    }
    private bool WasTapped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            return true;
        }

        if (Input.touchCount == 0)
        {
            return false;
        }

        var touch = Input.GetTouch(0);
        if (touch.phase != TouchPhase.Began)
        {
            return false;
        }

        return true;
    }
}
