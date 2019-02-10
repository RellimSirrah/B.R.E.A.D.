using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Boss : MonoBehaviour
{
    public GameObject item;
    public GameObject player;
    private Vector3 offset;
    float health;
    // Start is called before the first frame update


    // Update is called once per frame


    IEnumerator Start()
    {
        health = 3f;
        Vector2 pointA = transform.position;
        Vector2 pointB = new Vector2(transform.position.x + 5f, transform.position.y);
        while (true)
        {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1));
            yield return new WaitForSeconds(0.1f);
            yield return StartCoroutine(MoveObject2(transform, pointB, pointA, 1));
            yield return new WaitForSeconds(0.1f);
        }


    }

    IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
    {
        float i = 0.0f;
        float rate = 2.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector2.Lerp(startPos, endPos, i);
            yield return null;
        }
    }

    IEnumerator MoveObject2(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
    {
        float i = 0.0f;
        float rate = 2.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector2.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
