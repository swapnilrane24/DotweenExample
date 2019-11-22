using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    //final position object will move
    [SerializeField] private Vector3 finalPos;
    //ease type to decide the movement
    [SerializeField] private Ease ease;

    //originalPos store initial position of object, targetPos store nect target position
    private Vector3 originalPos, currentTargetPos;

    // Start is called before the first frame update
    void Start()
    {
        //set originalPos
        originalPos = transform.position;
        //set next target position
        currentTargetPos = finalPos;
        //move object
        MoveObj(currentTargetPos);
    }

    //method to move the object
    void MoveObj(Vector3 pos)
    {
        //move object to target position in give time
        transform.DOMove(pos, 2f).SetEase(ease).OnComplete(() => MoveObj(currentTargetPos)).SetDelay(0.5f);
        //set the target position
        currentTargetPos = currentTargetPos == finalPos ? originalPos : finalPos;
    }
}
