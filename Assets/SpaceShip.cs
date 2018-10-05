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
    public float speed;

    // Player Movement Variables/....
    public static int movespeed = 1;
    public Vector3 userDirection = Vector3.right;

    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(5f * Time.deltaTime, 0, 0, Space.World);
            rend.color = new Color(0.16f, 0.26f, 0.46f);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-5f * Time.deltaTime, 0, 0, Space.World);
            rend.color = new Color(0.32f, 0.58f, 0.24f);
        }
        if (Input.GetKey(KeyCode.S))
            // Fråga Felix varför den bara kan slow motion höger och inte vänster. 
        {
            transform.Translate(-+2.5f * Time.deltaTime, 0, 0, Space.World);
        }


        {
            transform.Translate(userDirection * movespeed * Time.deltaTime);
            //transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        
	}
}
