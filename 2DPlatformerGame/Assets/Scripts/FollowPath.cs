using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    Transform[] wayPoints;

    [SerializeField]
    float waitTime;

    [SerializeField]
    float timeOffset;

    private int wayPointCount;
    private int currentIndex = 0;

    private void Awake()
    {
        target.position = wayPoints[currentIndex].position;
        wayPointCount = wayPoints.Length;

        currentIndex++;

        StartCoroutine(nameof(Process));
    }

    private IEnumerator Process()
    {
        while (true)
        {
            yield return StartCoroutine(MoveAToB(target.position, wayPoints[currentIndex].position));

            yield return new WaitForSeconds(waitTime);
            if (currentIndex < wayPointCount - 1) currentIndex++;
            else currentIndex = 0;
        }
    }

    private IEnumerator MoveAToB(Vector3 a, Vector3 b)
    {
        float percent = 0;
        float moveTime = Vector3.Distance(a, b) * timeOffset;
        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;
            target.position = Vector3.Lerp(a, b, percent);
            yield return null;
        }
    }
}
