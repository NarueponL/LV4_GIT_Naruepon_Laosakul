using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    private int score;
    public Text scoreText;
    public Text winner;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;
        SetScoreText();
        winner.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");  
        float moveVertical = Input.GetAxis("Vertical");      
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (score >= 9)
        {
            rb.AddForce(movement * 0);

        }
        else
        {
            rb.AddForce(movement * speed);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("cube"))
        {
            other.gameObject.SetActive(false);  
            score++; 
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        scoreText.text = "Score : " + score.ToString();
        if (score >= 9)
        {
            winner.text = "You Win!";

        }
    }
}
