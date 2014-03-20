﻿using UnityEngine;
using System.Collections;

public class TransformShaker : MonoBehaviour
{
    public Shaker position;
    public Vector3 positionMultiplier = Vector3.one;
    public Shaker rotation;

	Vector3 initialPosition;
	Quaternion initialRotation;

	void Awake ()
	{
		initialPosition = transform.localPosition;
		initialRotation = transform.localRotation;
	}

    void Update ()
    {
        position.Update (Time.deltaTime);
        rotation.Update (Time.deltaTime);
        transform.localPosition = initialPosition + Vector3.Scale (position.Position, positionMultiplier);
		transform.localRotation = rotation.YawPitch * initialRotation;
    }

    public void Reshake ()
    {
        position.Reset ();
        rotation.Reset ();
    }
}
