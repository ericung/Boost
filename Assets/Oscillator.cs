using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour {

    [SerializeField]
    Vector3 movementVector = new Vector3(10f, 10f, 10f);

    [SerializeField]
    float period = 2f;

    float movementFactor;
    const float tau = Mathf.PI * 2;
    Vector3 startingPosition;

	// Use this for initialization
	void Start ()
    {
        startingPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update ()
    {
        // set movement factor

        // protect against divide by zero
        if (period <= Mathf.Epsilon) { return;  }

        float cycles = Time.time / period;

        float rawSinWave = Mathf.Sin(cycles * tau);

        movementFactor = rawSinWave / 2f + 0.5f;
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
	}
}
