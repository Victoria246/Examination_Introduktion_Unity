using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public SpriteRenderer rend;
    public Color newColor;
    public Transform other;

    [Range(-+720, 720)]
    public float rotationSpeed;
    public float moveSpeed = 10;
    public int moveSpeedRandom;
    public float timer = 0;
    public int nextTime = 1;

    public float randomX;
    public float randomY;
    public float randomZ;
    Vector3 pos;


    // Use this for initialization
    void Start()
    {
        {
            // Gör så att skeppet spawnar på en random position innanför skärmen när spelet startar. 
            //Mellan -8 och 8 i x-led och -5 och 0 i y-led, eftersom den inte ska starta för långt upp eller utanför skärmen.  
            randomX = Random.Range(-8, 8);
            randomY = Random.Range(-5, 0);
            randomZ = -0.1f;
            pos = new Vector3(randomX, randomY, randomZ);
            transform.position = pos;
        }
        
        {
            randomHastighet();
        }
       
    }

    // // Gör så att hastigheten randomiseras när spelet startar.  

    void randomHastighet()
    {
        moveSpeedRandom = Random.Range(1, 30);
    }
    

    // Update is called once per frame
    void Update()
    {

        // När spelaren trycker D så svänger skeppet  höger och blir blått
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate( 0, 0, rotationSpeed * Time.deltaTime, Space.Self);
            rend.color = new Color(0.16f, 0.26f, 0.46f);
        }
        // När spelaren trycker A så svänger skeppet vänster och blir grönt  
        // Samt svänger långsammare åt vänster än åt höger dvs 1/3 saktare
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate( 0, 0, -rotationSpeed/3 * Time.deltaTime, Space.Self);
            rend.color = new Color(0.32f, 0.58f, 0.24f);
        }

        // När spelaren trycker S så flyger skeppet hälften så snabbt och när man släpper S så återgår den till normalt
        bool held = Input.GetKey(KeyCode.S);

        if (held)
        {
            transform.Translate(0, -moveSpeed/2 * Time.deltaTime, 0, Space.Self);
        }

        // Spelaren åker konstant framåt med hastigheten som moveSpeed har

        transform.Translate(0, moveSpeed * Time.deltaTime, 0);


        // När spelaren trycker Spacebar så får skeppet en random färg (dock ej osynlig).
        if (Input.GetKey(KeyCode.Space))
        {
            rend.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }


        // Timern printar ut värdet varje sekund
        timer += Time.deltaTime;
        int seconds;
            seconds = Mathf.RoundToInt(timer % 60);

        if (timer > nextTime) 
        {
            Debug.Log(string.Format("Timer:" + nextTime));
            nextTime++;
        }


    }

   
}
