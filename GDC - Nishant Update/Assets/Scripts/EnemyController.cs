using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class EnemyController : MonoBehaviour {

    Transform target;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;
    public GameObject playButton;

    
    

    public float EnemySpeed = 0.15f;
    public float timeLeft = 60f;

    private bool gameLost = false;
    private bool gameWon = false;


    // Use this for initialization
    void Start () {
        target = PlayerManager.instance.player.transform;

	}
	
	// Update is called once per frame
	void Update () {
        if (!gameLost || !gameWon)
        {
            transform.LookAt(target.transform);
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, EnemySpeed);
        }
        

        if ((int)timeLeft > 0 && !gameLost)
        {
            if (!playButton.activeSelf)
            {
                timeLeft -= Time.deltaTime;
                timeText.text = (int)timeLeft + " seconds left";
            }
            
        }
        else if(!gameLost)
        {
            // you win
            gameWon = true;
            if (!playButton.activeSelf)
            {
                winText.gameObject.SetActive(true);
                playButton.gameObject.SetActive(true);
            }
                
        }
        
        


    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RigidBodyFPSController")
        {
            // game over
            gameLost = true;
            if (!playButton.activeSelf)
            {
                gameOverText.gameObject.SetActive(true);
                playButton.gameObject.SetActive(true);
            }
        }
    }

    public void onClick()
    {
        SceneManager.LoadScene(1);
    }
}
