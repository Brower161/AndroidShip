using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider))]

public class ShipMove : MonoBehaviour
{
    //static public int boost = 12;
    static public bool shieldActivated = false;
    static private bool haveBoost = true;
    static public float time2die = 1.5f;
    static public float score;
    private bool imDead = false;

    [SerializeField] private Rigidbody2D shipRigi;
    [SerializeField] private Animator shipAnim;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject boom;
    static public SpriteRenderer spriteRenderer;

    [SerializeField] private Vector2 moveInput;
    [SerializeField] private float moveSpeed;

    private float minX, maxX, minY, maxY;

    private AudioSource shieldDef;

    


    private void Start()
    {
        time2die = 1.5f;
        GetComponent<Rigidbody2D>();
        shipAnim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        shieldDef = GetComponent<AudioSource>();
      


        Vector3 esquinaInferiorIzq = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 esquinaSuperiorDer = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        minX = esquinaInferiorIzq.x;
        maxX = esquinaSuperiorDer.x;
        minY = esquinaInferiorIzq.y;
        maxY = esquinaSuperiorDer.y;

        haveBoost = true;
    }
    private void FixedUpdate()
    {
        if(haveBoost == true)
        {
            shipRigi.velocity = moveInput * moveSpeed;
            //animator.SetBool("isRunning", true);
        }

        if(haveBoost == false)
        {
            shipAnim.Play("NaveSinGasolina");
            moveSpeed = 0;
        }

        Vector3 posicion = transform.position;
        posicion.x = Mathf.Clamp(posicion.x, minX, maxX);
        posicion.y = Mathf.Clamp(posicion.y, minY, maxY);
        transform.position = posicion;

        if (shieldActivated == false)
        {
            shield.SetActive(false);
        }
        else
        {
            shield.SetActive(true);
        }

        if(imDead == true)
        {
            time2die -= Time.deltaTime;
            if (time2die <= 0)
            {
                score = Tiempo1.contador;
                Debug.Log("Cagaste");
                UIManagerScript.retryMenu();
            }
        }
    }
    
    private void OnMovement(InputValue inputValue)
    {
        moveInput = inputValue.Get<Vector2>();
    }

    static public void die()
    {
        haveBoost = false;
        spriteRenderer.enabled = false;
    }

    static public void noBoost()
    {
        haveBoost = false;
    }

    public void Boom()
    {
        boom.SetActive(true);
        imDead = true;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "PowerUp")
        {
            shieldActivated = true;
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Boost")
        {
            UIManagerScript.pickBoost();
            //Debug.Log(boost);
            Destroy(col.gameObject);
        }

        if (col.gameObject.tag == "Enemy" && imDead == false)
        {
            if(shieldActivated == true)
            {
                shieldDef.Play();
                shield.SetActive(false);
                shieldActivated = false;
                Destroy(col.gameObject);
            }
            else
            {

                
                imDead = true;
                boom.SetActive(true);
                Destroy(col.gameObject);

                

            }
        }
    }
}
