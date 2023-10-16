using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    
    public Rigidbody rb;
    
    Animator animator;
    
    // buraya playerýma bir kuvvet vermem gerek
    public float speed = 30f;

    public float leftrightSpeed = 30f;

    bool isDead = false;

    

    private void Start()
    {
        animator = GetComponent<Animator>();
       rb=GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        //input alýcaz ve level boundry kontrol edicez sonra force edicez
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * leftrightSpeed);
            }

        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.right * Time.deltaTime * leftrightSpeed);
            }
        }


    }
    public void Die()
    {
        isDead = true;
        Debug.Log("öldü");
        animator.SetTrigger("Die");
        speed = 0;
        StartCoroutine(TimeForLoad());
    }

    private IEnumerator TimeForLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    } 
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Trap")
         Die(); 
        if (isDead)
        {
            BreakableWalls._bulletDmg = 5;
            CollectableController.coinCount = 0;
        }
            

        if (other.gameObject.CompareTag("coin"))
        {
            Debug.Log("topladý");
            CollectableController.coinCount++;
            Destroy(other.gameObject);
        }
    }


}
