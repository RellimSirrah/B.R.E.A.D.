using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl1 : MonoBehaviour
{

    bool grounded;
    bool isJumping;
    float speed;
    float speed_crouch;
    public float health;
    public float health_max;
    public Sprite right;
    public Sprite left;
    public Sprite right_crouch;
    public Sprite left_crouch;
    public Sprite right_jump;
    public Sprite left_jump;
    public Sprite right_punch;
    public Sprite left_punch;

    private SpriteRenderer spriteRenderer; 

    public void Start()
    {
        grounded = false;
        isJumping = false;
        speed = 12f;
        speed_crouch = speed/2;
        health_max = 3f;
        health = 5f;
        spriteRenderer = GetComponent<SpriteRenderer>( ); // we are accessin g  the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = right;
    }


    public void Update()
    {
        if(health <= 0f)
        {
            Application.LoadLevel("GameOver");
        }

        if (transform.position.y < -20)
        {
            isJumping = false;
            Application.LoadLevel(Application.loadedLevel);
        }
        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        if(Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spriteRenderer.sprite = left_crouch;
                transform.Translate(-Vector2.right * speed_crouch * Time.deltaTime);
            }
            else
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                spriteRenderer.sprite = left;
                transform.Translate(-Vector2.right * speed * Time.deltaTime);
            }
        }
        else 
        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                spriteRenderer.sprite = right_crouch;
                transform.Translate(Vector2.right * speed_crouch * Time.deltaTime);
            }
            else
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                spriteRenderer.sprite = right;
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
        }
        else 
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (spriteRenderer.sprite == left)
            {
                spriteRenderer.sprite = left_crouch;
            }
            else 
            if(spriteRenderer.sprite == right)
            {
                spriteRenderer.sprite = right_crouch;
            }
        }
        else 
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            if (spriteRenderer.sprite == left_crouch)
            {
                spriteRenderer.sprite = left;
            }
            else 
            if (spriteRenderer.sprite == right_crouch)
            {
                spriteRenderer.sprite = right;
            }
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isJumping==false)
            {
                rb.AddForce(Vector2.up * 25f, ForceMode2D.Impulse);
                isJumping = true;
            }
        }

        if (Input.GetKey(KeyCode.V))
        {
            if (spriteRenderer.sprite == left || spriteRenderer.sprite == left_crouch || spriteRenderer.sprite == left_jump)
            {
                spriteRenderer.sprite = left_punch;
                // Insert code for killing enemies
            }
            else 
            if (spriteRenderer.sprite == right || spriteRenderer.sprite == right_crouch || spriteRenderer.sprite == right_crouch)
            {
                spriteRenderer.sprite = right_punch;
                // Insert code for killing enemies
            }
        }
        else
        if (!Input.GetKey(KeyCode.V) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.LeftShift))
        {
            if (spriteRenderer.sprite == left_punch)
            {
                spriteRenderer.sprite = left;
            }
            else
            if (spriteRenderer.sprite == right_punch)
            {
                spriteRenderer.sprite = right;
            }
        }

    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "ground")
        {
            isJumping = false;
        }
        if (col.collider.tag == "item")
        {
            if (health < health_max)
            {
                health++;
            }
        }
        if (col.collider.tag == "enemy")
        {
            health--;
        }
        if (col.collider.tag == "proj" && !Input.GetKey(KeyCode.LeftShift))
        {
            health--;
        }
        if(col.collider.tag == "Alton" && Input.GetKey(KeyCode.V))
        {
            Application.LoadLevel("Finish");
        }
    }



}




