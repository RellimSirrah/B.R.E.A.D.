using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl2 : MonoBehaviour
{

    
    public LayerMask groundLayer;
    public Transform groundCheck;
    bool grounded;
    bool isJumping;
    float speed;


    public void Start()
    {
        grounded = false;
        isJumping = false;
        speed = 4f;
    }
        
    


    void Update()
{
        if (transform.position.y < -5)
        {
            isJumping = false;
            Application.LoadLevel(Application.loadedLevel);
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
    if (Input.GetKey(KeyCode.RightArrow))
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    else if (Input.GetKey(KeyCode.LeftArrow))
    {
        transform.Translate(-Vector2.right * speed * Time.deltaTime);
    }

    if (Input.GetKeyDown(KeyCode.UpArrow))
    {
        if (isJumping == false)
        {
            rb.AddForce(Vector2.up * 5.0f, ForceMode2D.Impulse);
            isJumping = true;
        }
    }
}

public void OnCollisionEnter2D(Collision2D col)
{
    if (col.collider.tag == "ground")
    {
        isJumping = false;
    }
        if (col.collider.tag == "spider")
        {
            isJumping = false;
            Application.LoadLevel(Application.loadedLevel);
        }
    }
   
}
