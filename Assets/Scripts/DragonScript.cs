using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonScript : MonoBehaviour
{

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private float _jumpForce;
    public bool isAlive;

	// Use this for initialization
	void Start ()
	{
	    isAlive = true;

	    _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	    _animator = gameObject.GetComponent<Animator>();

	    _jumpForce = 10f;
	    _rigidbody2D.gravityScale = 5f;
	}
	
	// Update is called once per frame
	void Update () {
	    if (isAlive)
	    {
	        if (Input.GetMouseButton(0) || Input.anyKey)
	        {
                Flap();
	        }
            CheckIfDragonVisibleOnScreen();
	    }
	}

    void Flap()
    {
        _rigidbody2D.velocity = new Vector2(0, _jumpForce);

        _animator.SetTrigger("Flap");
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Obstacles")
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }

    void CheckIfDragonVisibleOnScreen()
    {
        if (Mathf.Abs(gameObject.transform.position.y) > 4.78)
        {
            isAlive = false;
            Time.timeScale = 0f;
        }
    }
}

//+-4.78
