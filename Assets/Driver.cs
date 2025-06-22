using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.Mathematics;

public class Driver : MonoBehaviour
{
  [SerializeField] float steerSpeed = 400;
  [SerializeField] float moveSpeed = 15;
  [SerializeField] float slowSpeed = 9;
  [SerializeField] float boostSpeed = 20;
  void Start()
  {
    
  }

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

  void OnTriggerEnter2D(Collider2D collision)
  {
    if(collision.tag == "Boost")
    {
      Destroy(collision.gameObject, 0.001f);
      moveSpeed = boostSpeed;
    }
  }

  void OnCollisionEnter2D(Collision2D collision)
  {
    moveSpeed = slowSpeed;
  }

}
