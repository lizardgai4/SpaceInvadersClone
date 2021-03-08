using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] //technique for making sure there isn't a null reference during runtime if you are going to use get component
public class BulletDown : MonoBehaviour
{
    private Rigidbody2D myRigidbody2D;
    //public GameObject UI;

    public float speed = -5;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        Fire();
    }

    // Update is called once per frame
    private void Fire()
    {
        myRigidbody2D.velocity = Vector2.up * speed;
        //Debug.Log("Wwweeeeee");
    }

    private void OnCollisionEnster(Collision collision)
    {
        //Debug.Log("Crash");
        //var selectionRenderer = transform.GetComponent<Renderer>();
        if (collision.gameObject.name.StartsWith("Player") || collision.gameObject.name.StartsWith("Barricade"))
        {
            //GameObject.Find("UI").GetComponent<UIScript>().scorePoints(100, 0);
            //Debug.Log("Block destroyed");
            Destroy(collision.gameObject);
            return;
        }
    }
}
