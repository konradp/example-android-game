using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    Rigidbody2D rb;
    float x, y;
    Vector3 bounced;
    public float ballSpeed = 60f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        x = Random.Range(-3f,3f)* ballSpeed;
        y = Random.Range(-3f, 3f) * ballSpeed;
        bounced = new Vector3(x, y);
        rb.AddForce(bounced);
	}
	
	void Update () {

    }
    void SwitchPosition(int scenario)
    {
        Debug.Log(bounced);
        switch (scenario)
        {
            case (0):
                bounced = Vector3.Reflect(this.transform.position, Vector3.up);
                break;
            case (1):
                bounced = Vector3.Reflect(this.transform.position, Vector3.right);
                break;
            case (2):
                bounced = Vector3.Reflect(this.transform.position, Vector3.down);
                break;
            case (3):
                bounced = Vector3.Reflect(this.transform.position, Vector3.left);
                break;
            default:
                break;
        }
        bounced *= ballSpeed;
        Debug.Log(bounced);
        rb.Sleep();
        rb.WakeUp();
        rb.AddForce(bounced);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            int check = collision.GetComponent<Wall>().placement;
            SwitchPosition(check);
        }
    }
}
