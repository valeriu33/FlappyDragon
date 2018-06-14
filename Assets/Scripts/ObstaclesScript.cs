using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesScript : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private float _dragonXposition;
    private bool _isScoreAdded;

    private GameManagerScript _gameManager;

	// Use this for initialization
	void Start ()
	{
		_rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
	    _rigidbody2D.velocity = new Vector2(-2.5f, 0);

	    _dragonXposition = GameObject.Find("Dragon_1").transform.position.x;

	    _isScoreAdded = false;

	    _gameManager = GameObject.Find("GameManager")
	        .GetComponent<GameManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.x <= _dragonXposition)
	    {
	        if (!_isScoreAdded)
	        {
	            AddScore();
	            _isScoreAdded = true;
	        }
	    }

	    if (transform.position.x <= -10f)
	    {
            Destroy(gameObject);
	    }
	}

    private void AddScore()
    {
        _gameManager.GmAddScore();
    }
}
