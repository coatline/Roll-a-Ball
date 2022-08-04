using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Text countText;
    public Text winText;

    public float speed;
    private int count;

    void CountText()
    {
        countText.text = "Score: " + count.ToString();
        if (count >= 14)
            winText.text = "YOU WIN!!!";
    }

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        CountText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Pick_Ups")
        {

            Destroy(collider.gameObject, 0);
            count++;
            CountText();
        }
    }


}
