using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WASD_rb : MonoBehaviour
{

    //variables 
    public float forceAmt = 2f;

    private int i = 8;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        { 
            rb.AddForce(Vector2.right * forceAmt);
        }
        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(Vector2.down * forceAmt);
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector2.left * forceAmt);
        }
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * forceAmt);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Coin1")
        {
            SceneManager.LoadScene("Level1");
        }
        if (collision.transform.tag == "Death")
        {
            SceneManager.LoadScene(1);
        }
        if (collision.transform.tag == "End")
        {
            SceneManager.LoadScene(1);
        }
    }
}
