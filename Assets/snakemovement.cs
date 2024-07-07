using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class snakemovement : MonoBehaviour
{
    [SerializeField]
    public GameObject node;
    private List<GameObject> body;

    Vector2 direction = Vector2.down;
    private bool eatfood=false;
    private bool dead = false;
    private int foodCount = 0;

    [SerializeField]
    private float startWaitTime = 0.2f;
    private float waitToMove;
    private int level;

    //LinkedList<GameObject> body = new LinkedList<GameObject>();
    private foodcreator Foodcreator;
    //private AudioSource audioSource;

    [SerializeField]
    private int levelUpRate = 2;
    private int score = 0;

    

    // Start is called before the first frame update
    private void Awake()
    {
        //audioSource = GetComponent<AudioSource>();
        waitToMove = startWaitTime;
        body = new List<GameObject>();

        Foodcreator = FindObjectOfType<foodcreator>();
    }

    
    IEnumerator Start()
    {
        while (true)
        {
            Move();
            yield return new WaitForSeconds(waitToMove);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
        {
            direction = Vector2.left;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            direction = Vector2.right;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            direction = Vector2.up;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            direction = Vector2.down;
        }

        if(waitToMove > 0.02f)
        {
            level = 1 + foodCount / levelUpRate;
            waitToMove = startWaitTime - level/100f;

        }
    }

    private void Move()
    {
        if (dead) return;
        var curheadpostion = transform.position;
        transform.Translate(direction);
        if (eatfood)
        {
            var newNode = Instantiate(node, curheadpostion, Quaternion.identity);
            body.Insert(0,newNode);
            eatfood = false;
            while (!Foodcreator.CreateFoodPosition(body)) { };


        }
        else
        {
            if (body.Count == 0) return;
            var tail = body[body.Count-1];
            tail.transform.position = curheadpostion;
            body.RemoveAt(body.Count-1);
            body.Insert(0,tail);
        
        }



        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Food")
        {
            eatfood = true;
            //audioSource.Play();

            Destroy(collision.gameObject);
            foodCount++;
            score += level;



        }
        else
        {
            dead = true;
        }
    }

    public int GetLevel()
    {
        return level;
    }

    public int GetScore()
    {
        return score;
    }

}
