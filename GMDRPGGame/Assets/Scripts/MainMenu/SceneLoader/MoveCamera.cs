using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    [SerializeField]
    private float moveTo = 15;

    [SerializeField]
    private int timeToMoveCamera = 5;
    void Start()
    {
        StartCoroutine(LerpPositionRight(new Vector3(moveTo, mainCamera.transform.position.y, mainCamera.transform.position.z), timeToMoveCamera));
    }
    IEnumerator LerpPositionRight(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = mainCamera.transform.position;
        while (time < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPosition;
        StartCoroutine(LerpPositionLeft(new Vector3(-moveTo, mainCamera.transform.position.y, mainCamera.transform.position.z), timeToMoveCamera));
    }

    IEnumerator LerpPositionLeft(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = mainCamera.transform.position;
        while (time < duration)
        {
            mainCamera.transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        mainCamera.transform.position = targetPosition;
        StartCoroutine(LerpPositionRight(new Vector3(moveTo, mainCamera.transform.position.y, mainCamera.transform.position.z), timeToMoveCamera));
    }
}
