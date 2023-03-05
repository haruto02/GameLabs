using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    public GameObject explosion, playerExplosion;
    private GameController gameController;
    public int score = 10;
    void Start()
    {
        GameObject controller = GameObject.Find("GameController");
        if (controller != null)
        {
            gameController = controller.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Game controller not found");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary") return;
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        gameController.addScore(score);
        Destroy(gameObject);
        Destroy(other.gameObject); 
    }
}
