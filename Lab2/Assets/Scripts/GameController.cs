using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    
    private int numPickUp = 10;
    private LineRenderer lineRenderer;
    private GameObject player; // begin point
    private float minDistance = 0;
    private GameObject end;
    private GameObject previousEnd = null;
    private enum State { 
        Normal,
        Distance,
        Vision,
    }
    private State currentState;

    public int count = 0;
    public Color previousColor;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI playerPos;
    public TextMeshProUGUI playerVelocity;
    public TextMeshProUGUI Distance;
    public List<GameObject> pickUps;
    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material.color = Color.white;
        lineRenderer.startWidth = 0.5f;
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void FixedUpdate()
    {
        lineRenderer.SetPosition(0, player.transform.position);
        calculateDistaneFrom2Point();
        lineRenderer.SetPosition(1, end.transform.position);
    }

    public void SetCountText()
    {
        scoreText.text = "Score:" + count.ToString();
        if (count >= numPickUp)
        {
            winText.text = "You Win!!!";
        }
    }

    private void calculateDistaneFrom2Point()
    {
        for (int i = 0; i < pickUps.Count; i++)
        {
            float disForm2Point = Vector3.Distance(pickUps[i].transform.position, player.transform.position);
            if (i == 0)
            {
                minDistance = disForm2Point;
                this.end = pickUps[i];
                this.previousEnd = this.end;
            }
            else if (disForm2Point < minDistance)
            {
                this.previousEnd = this.end;
                this.end = pickUps[i];
                minDistance = disForm2Point;
            }

            if (this.previousEnd == this.end)
            {
                continue;
            }
            else
            {
                this.previousEnd.GetComponent<Renderer>().material.color = previousColor;
                this.end.GetComponent<Renderer>().material.color = Color.blue;
                Distance.text = this.end.name + " : " + disForm2Point.ToString();
            }
        }
    }


}
