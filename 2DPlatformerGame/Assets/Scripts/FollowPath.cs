using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FollowPath_State
{
    Idle = 0,
    Move,
}
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

    private int direction;
    public int Direction => direction;

    public FollowPath_State State {private set; get;} = FollowPath_State.Idle;

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

        SetDirection(a.x, b.x);
        State = FollowPath_State.Idle;

        while (percent < 1)
        {
            percent += Time.deltaTime / moveTime;
            target.position = Vector3.Lerp(a, b, percent);
            yield return null;
        }
    }

    private void SetDirection(float start, float end)
    {
        if (end - start != 0) direction = (int)Mathf.Sign(end - start);
        else direction = 0;
    }
    public void Stop()
    {
        StopAllCoroutines();
    }
}
