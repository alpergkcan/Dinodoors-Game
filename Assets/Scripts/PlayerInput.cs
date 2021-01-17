using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerInput : MonoBehaviour
{
    public float JumpSpeed,AxeSpeed,timeEnemy,AxeCd;

    public GameObject AxePrefab;
    public GameObject DeathScreen;
    public GameObject[] Enemies;
    public TextMeshProUGUI text;
    public static float MSForDoors = 10f;
    public GameObject Viking;
    public GameObject Yilann;
    public PolygonCollider2D walkcol;
    public CapsuleCollider2D crawlcol;

    public static bool dead = false;
    private bool canThrow = true;
    private Rigidbody2D rb;
    private bool grounded = true;
    private float timeforspawn = 0f,timeforthrow = 0f,timeforspeedup = 0f;
    private int score;

    private void Awake()
    {
        Time.timeScale = 1f;
        MSForDoors = 10f;
        dead = false;

    }

    private void Start()
    {
      
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!dead)
        {
            UpdateScore();

            timeforspeedup += Time.deltaTime;
            if (timeforspeedup > 5)
            {
                timeforspeedup -= 5;
                MSForDoors += 1;
                timeEnemy *= 0.94f;
            }


            timeforspawn += Time.deltaTime;
            if (timeforspawn > timeEnemy)
            {
                timeforspawn -= timeEnemy;
                SpawnEnemy();
            }


            timeforthrow += Time.deltaTime;
            if (timeforthrow > AxeCd)
            {
                timeforthrow -= AxeCd;
                canThrow = true;
            }

            if (transform.position.y > -3.3) grounded = false;
            else grounded = true;

            if (rb.velocity.y < 0)
            {
                rb.velocity = new Vector2(0, rb.velocity.y - 30f * Time.deltaTime);
            }

            if (canThrow && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) ) ThrowAxe();
            if (grounded &&  (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))  ) Jump();
            if (grounded && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))) Crouch();
            else
            {
                Viking.SetActive(true);
                walkcol.enabled = true;
                Yilann.SetActive(false);
                crawlcol.enabled = false;
            }
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.R)) UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }
        
    }

    private void UpdateScore()
    {
        score++;
        text.text = "Score: " + Convert.ToString(score);
    }

    void Crouch()
    {
        Yilann.SetActive(true);
        Viking.SetActive(false);
        crawlcol.enabled = true;
        walkcol.enabled = false;
    }


    private void Jump()
    {
        rb.velocity = Vector2.up * JumpSpeed;
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0f;
            dead = true;
            DeathScreen.SetActive(true);
            
        }
    }
  

    private void ThrowAxe()
    {
        if (Yilann.activeSelf) return;
        canThrow = false;
        GameObject CurrentAxe = Instantiate(AxePrefab,transform.position,Quaternion.identity);
        CurrentAxe.GetComponent<Rigidbody2D>().velocity = Vector2.right * AxeSpeed;
        Destroy(CurrentAxe, 4.2f);
    }

    

    private void SpawnEnemy()
    {
        GameObject SecondNext = Instantiate(Enemies[UnityEngine.Random.Range(0, 3)]);
    }
}
