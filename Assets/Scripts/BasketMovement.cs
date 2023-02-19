using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketMovement : MonoBehaviour
{
    public float speed;
    public Transform[] patrolPoints;
    int currentPointIndex;

    void Update()
    {
        if(transform.position != patrolPoints[currentPointIndex].position){
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
        }else{
            if(currentPointIndex + 1 < patrolPoints.Length){
                currentPointIndex++;
            }else{
                currentPointIndex = 0;
            }
        }
    }
}
