using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetManager : MonoBehaviour
{
    public GameObject TargetPrefab;
    public SabertoothManager STManager;
    public bool isInstantiated;
    public Text score;
    public Vector3 CarVec;
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (STManager.SB != null  && !isInstantiated)
        {
            CarVec = CarVecGen();
            obj  = GameObject.Instantiate(TargetPrefab);
            isInstantiated = true;
            obj.GetComponent<TargetBehaviour>().TargetManager = this;

            obj.transform.position = CarVec; 

            
        }

        score.text = "Score : " + obj.GetComponent<TargetBehaviour>().count;

    }

    public Vector3 CarVecGen()
    {
        return STManager.SB.gameObject.transform.position + new Vector3(Random.Range(-.75f, .75f), 0.1f, Random.Range(-.75f, .75f));
    }

}
