using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour {
          
    // Use this for initialization
    

    // Update is called once per frame
    IEnumerator Start () {
        Vector2 pointA = transform.position;
        Vector2 pointB = new Vector2(transform.position.x,transform.position.y+5f);
        while (true) {
            yield return StartCoroutine(MoveObject(transform, pointA, pointB, 1));
            yield return new WaitForSeconds(0.5f);
            yield return StartCoroutine(MoveObject2(transform, pointB, pointA, 1));
            yield return new WaitForSeconds(1.5f);
        }
        
       
    }

    IEnumerator MoveObject(Transform thisTransform, Vector2 startPos, Vector2 endPos, float time)
    {
        float i = 0.0f;
        float rate = 1.0f / time;
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
        float rate = 5.0f / time;
        while (i < 1.0f)
        {
            i += Time.deltaTime * rate;
            thisTransform.position = Vector2.Lerp(startPos, endPos, i);
            yield return null;
        }
    }
}
