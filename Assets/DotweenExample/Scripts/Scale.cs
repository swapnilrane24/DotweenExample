using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Scale : MonoBehaviour
{
    //list of scaling sequence
    [SerializeField] private ScaleData[] scaleDatas;

    //index to identify current scale data
    private int currentIndex = 0;
    void Start()
    {
        ScaleObj();
    }

    //method which scale the object
    void ScaleObj()
    {
        //if currentIndex is greater or equal to scaleDatas array length
        if (currentIndex >= scaleDatas.Length)
        {
            //set the currentIndex to 0
            currentIndex = 0;
        }

        //set the scale of object
        transform.DOScale(scaleDatas[currentIndex].scale, scaleDatas[currentIndex].time).OnComplete(() => ScaleObj());
        //increase index by 1
        currentIndex++;
    }


}

//custom class for ScaleData
[System.Serializable]
public class ScaleData
{
    //time to scale
    public float time;
    //final scale value
    public Vector3 scale;
}