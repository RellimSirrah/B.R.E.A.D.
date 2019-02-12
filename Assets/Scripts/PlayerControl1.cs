using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerControl1 : MonoBehaviour
{
    public GameObject heart1, heart2, heart3, heart4, heart5;
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
    Rigidbody2D rb; 

    private SpriteRenderer spriteRenderer; 

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grounded = false;
        isJumping = false;
        speed = 12f;
        speed_crouch = speed/2;
        health_max = 5f;
        health = 3f;
        spriteRenderer = GetComponent<SpriteRenderer>( ); // we are accessin g  the SpriteRenderer that is attached to the Gameobject
        if (spriteRenderer.sprite == null) // if the sprite on spriteRenderer is null then
            spriteRenderer.sprite = right;
    }


    public void Update()
    {
        switch (health)
        {
            case 5:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(true);
                break;
            case 4:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(true);
                heart5.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart5.gameObject.SetActive(false);
                break;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isJumping == false)
            {
                rb.AddForce(Vector2.up * 25f, ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    public void FixedUpdate()
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

        if (Input.GetKey(KeyCode.A))
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
            if (spriteRenderer.sprite == right)
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
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x-0.25f,transform.position.y-0.9f), -Vector2.up,0.5f);
        RaycastHit2D hit2 = Physics2D.Raycast(new Vector2(transform.position.x + 0.25f, transform.position.y - 0.9f), -Vector2.up, 0.5f);
        if (hit.collider != null && hit.transform.tag == "enemy")
        {
            rb.AddForce(Vector2.up * 25f, ForceMode2D.Impulse);
            Destroy(hit.transform.gameObject);
            Debug.Log("hit Left");
        }
        else if (hit2.collider != null && hit2.transform.tag == "enemy")
        {
            rb.AddForce(Vector2.up * 25f, ForceMode2D.Impulse);
            Destroy(hit2.transform.gameObject);
            Debug.Log("hit Right");
        }
        else if(col.collider.tag == "enemy")
        {
            health--;
        }

        if (col.gameObject.layer == 8)
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




