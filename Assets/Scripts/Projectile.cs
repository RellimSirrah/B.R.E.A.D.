using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D toaster;
    public float projectileSpeed = 20000f;
    // Start is called before the first frame update
    IEnumerator Start()
    {

        while (true)
        {
            yield return StartCoroutine(Fire());
            yield return new WaitForSeconds(1.5f);
        }


    }

    IEnumerator Fire()
    {
        Rigidbody2D thing = Instantiate(toaster, new Vector3(transform.position.x-5f, transform.position.y, transform.position.z), transform.rotation) as Rigidbody2D;
        thing.GetComponent<Rigidbody2D>().AddForce(Vector3.left * projectileSpeed);
        yield return null;
    }
}
