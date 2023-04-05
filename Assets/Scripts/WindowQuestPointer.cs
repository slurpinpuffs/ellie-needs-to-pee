using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class WindowQuestPointer : MonoBehaviour
{
    private Vector3 targetPosition;
    [SerializeField] public RectTransform pointerRectTransform;
    [SerializeField] public GameObject firstObjective;

    private void Awake() {
        setObjective(firstObjective);
    }

    private void Update() {
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = UtilsClass.GetAngleFromVectorFloat(dir);
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen = targetPositionScreenPoint.x <= 0 || targetPositionScreenPoint.x >= Screen.width || targetPositionScreenPoint.y <= 0 || targetPositionScreenPoint.y >= Screen.height;
        Debug.Log(isOffScreen + " " + targetPositionScreenPoint);

        if (isOffScreen){
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= 0) cappedTargetScreenPosition.x = 0f;
            if (cappedTargetScreenPosition.x >= Screen.width) cappedTargetScreenPosition.x = Screen.width;
            if (cappedTargetScreenPosition.y <= 0) cappedTargetScreenPosition.y = 0f;
            if (cappedTargetScreenPosition.y >= Screen.height) cappedTargetScreenPosition.y = Screen.height;
        }
    }

    public void setObjective(GameObject obj){
        targetPosition = obj.transform.position;
    }
}
