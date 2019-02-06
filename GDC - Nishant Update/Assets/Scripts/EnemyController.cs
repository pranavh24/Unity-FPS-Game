using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour {

    Transform target;

    public float EnemySpeed = 0.15f;


	// Use this for initialization
	void Start () {
        target = PlayerManager.instance.player.transform;

	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, target.transform.position, EnemySpeed);
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "RigidBodyFPSController")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Game Over!");
        }
    }
}
