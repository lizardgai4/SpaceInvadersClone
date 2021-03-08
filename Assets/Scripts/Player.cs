using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 5f;
    public string leftValue;
    public string rightValue;
    public GameObject bullet;
    public Transform shottingOffset;

    private float fireRate = 0.25f;
    private float fireTimer = 0f;
    private bool canFire = true;

    // update is called once per frame
    void Update()
    {
        if (!canFire) {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRate) {
                canFire = true;
                fireTimer = 0.0f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            canFire = false;
            GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
            //Debug.Log("Bang!");
            Destroy(shot, 3f);
        }

        //temporary variable to store positions
        Vector3 pos = transform.position;

        //move left
        if (Input.GetKey(leftValue) && pos.z <= 4)
        {
            pos.x -= speed * Time.deltaTime;
        } //move right
        else if (Input.GetKey(rightValue) && pos.z >= -4)//or max calues aren't reached || Input.mousePosition.y >= Screen.height - panBorderThickness)
        {
            pos.x += speed * Time.deltaTime;
        }

        transform.position = pos;
    }
}
