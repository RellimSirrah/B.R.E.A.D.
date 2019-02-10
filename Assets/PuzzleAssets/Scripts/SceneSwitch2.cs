using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwitch2 : MonoBehaviour {

    public void OnCollisionEnter2D(Collision2D col)
    {
        Application.LoadLevel("Scene4");
    }
}
