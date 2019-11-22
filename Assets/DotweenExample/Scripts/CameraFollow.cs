using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject target; //set pare car as target

    //strength and duration of shake
    [SerializeField] private float strength, duration;

    private Vector3 offset;
    private bool shaking = false;

    // Start is called before the first frame update
    void Start()
    {
        //get the tdistance offset on all axis
        offset = transform.position - target.transform.position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            shaking = true;
            Camera.main.DOShakePosition(duration, strength, 10, 90, true).OnComplete(() => shaking = false);
        }

        //if target in not null
        if (target != null && !shaking)
            transform.position = target.transform.position + offset;//we add the offset to target pos and set camera transform
    }
}
