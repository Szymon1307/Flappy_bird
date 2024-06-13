using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class BirdController : MonoBehaviour
{
    public float JumpForce;
    public Rigidbody2D Rb2D;

    public static bool HasStarted;
    public static bool Gameover;

    public int Points;

    public GameObject GameOverScreen;
    public TextMeshProUGUI PointsTextField;
    public TextMeshProUGUI HighscorePointsTextField;

    public void Restart()
    {
       SceneManager.LoadScene("FlappyBird");
    }

    // Start is called before the first frame update
    void Start()
    {
        HasStarted = false;
        Gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        PointsTextField.text = Points.ToString();
        if (Gameover) return;
        
        if (Input.GetButtonDown("Jump"))
        {
            if (!HasStarted)
            {
                HasStarted = true;
                Rb2D.gravityScale = 1;
            }
            //In this case transform.up == new Vector2(0, 1)
            Rb2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
    }
 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Gameover = true;
        GameOverScreen.SetActive(true);

        var highscore = (PlayerPrefs.GetInt("Highscore")) ;

        if(highscore < Points)
        {
            highscore = Points;
            PlayerPrefs.SetInt("Highscore", Points);

        }
        HighscorePointsTextField.text = highscore.ToString();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PointsTrigger"))
        {
            Points++;
        }
    }
}
