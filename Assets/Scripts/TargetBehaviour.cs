using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class TargetBehaviour : MonoBehaviour
{
    ARRaycastManager RaycastManager;
    public TargetManager TargetManager;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        count++;
        this.transform.position = TargetManager.CarVecGen();
    }

    // Update is called once per frame
    void Update()
    {
    }
}
