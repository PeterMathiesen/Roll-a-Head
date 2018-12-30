using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
    public int Lives;
    public GameObject LifeSprite;
    public GameObject PointText;

    private Rigidbody player;
    private Vector3 startLocation;
    private List<GameObject> lifeSprites = new List<GameObject>();
    private int points = 0;

    // Use this for initialization
    void Start() {
        player = GetComponent<Rigidbody>();
        startLocation = player.position;

        lifeSprites.Add(LifeSprite);
        int counter = 1;
        while (counter < Lives)
        {
            GameObject lifeSpriteClone = Instantiate(LifeSprite, LifeSprite.transform.parent);
            lifeSpriteClone.GetComponent<RectTransform>().position += new Vector3(120f*counter, 0, 0);
            lifeSprites.Add(lifeSpriteClone);
            counter += 1;
        }
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        float speed = 15;
        Vector3 move = new Vector3(moveX*speed, 0.0f ,moveY*speed);
        player.AddForce(move);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Burger")
        {
            points += 10;
            PointText.GetComponent<UnityEngine.UI.Text>().text = points.ToString();
            collision.gameObject.GetComponent<Target>().MoveToNewPosition();
            Debug.Log("Points" + points);
        }
    }

    public void CollideWithEnemy()
    {
        Lives = Lives - 1;
        Debug.Log("Lives left: " + Lives);
        if (Lives == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            player.position = startLocation;
            player.velocity = Vector3.zero;
            lifeSprites[lifeSprites.Count - 1].SetActive(false);
            lifeSprites.RemoveAt(lifeSprites.Count - 1);
        }
    }
}