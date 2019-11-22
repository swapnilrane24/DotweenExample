using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotate : MonoBehaviour
{
    //final angle object rotate to
    [SerializeField] private Vector3 finalAngle;
    //ease type to decide the movement
    [SerializeField] private Ease ease;

    //target angle the object has to rotate
    private Vector3 currentTargetAngle;
    // Start is called before the first frame update
    void Start()
    {
        //set he target angle to final angle
        currentTargetAngle = finalAngle;
        RotateObj(currentTargetAngle);
    }

    //method which rotate object to given angle
    void RotateObj(Vector3 angle)
    {
        //rotate object to givent angle
        transform.DORotate(angle, 1f).SetEase(ease).OnComplete(() => RotateObj(currentTargetAngle));
        //change the target angle
        currentTargetAngle = currentTargetAngle == finalAngle ? Vector3.zero : finalAngle;

    }
}
