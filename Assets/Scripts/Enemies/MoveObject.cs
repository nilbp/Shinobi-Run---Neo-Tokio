using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public enum MovementType { CONTINUOUS, PROGRESSIVE };

    [Header("This Transforms souldn't be childrens of the movable object")]
    public Transform[] points;

    public float speed;
    public float pointSensibility;
    public bool dontMove;

    [Header("If activateCondition is True you should drag a GameObject into conditionGO")]
    public bool activateCondition;
    public GameObject conditionGO;

    public MovementType movementType = (int)MovementType.CONTINUOUS;

    private int index = 0;


    void Start()
    {

    }

    void Update()
    {
        if (dontMove)
            return;

        if (movementType == MovementType.PROGRESSIVE)
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, points[index].position, Mathf.Abs(speed));

        else if (movementType == MovementType.CONTINUOUS)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, points[index].position, Time.deltaTime * Mathf.Abs(speed) * 100);



        if (Vector3.Distance(gameObject.transform.position, points[index].position) < pointSensibility)
        {
            if (index + 1 == points.Length)
                index = 0;

            else
                index++;
        }
    }
}
