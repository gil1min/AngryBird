using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum BirdState
{
	Waiting,
	BeforeShoot,
	AfterShoot
}
public class Bird : MonoBehaviour
{
	public BirdState state = BirdState.BeforeShoot;
	private bool isMouseDown = false;
	public float maxDistance = 3f;
	public float flySpeed = 15;
	private Rigidbody2D rgd;
	// Start is called before the first frame update
	void Start()
	{
		rgd = GetComponent<Rigidbody2D>();
		rgd.bodyType = RigidbodyType2D.Static;
	}

	// Update is called once per frame
	void Update()
	{
		switch (state)
		{
			case BirdState.BeforeShoot:
				MoveControl();
				break;
			default:
				break;
		}
	}

	private void OnMouseDown()
	{
		if (state == BirdState.BeforeShoot)
		{
			isMouseDown = true;
			Slingshot.Instance.StartDraw(transform);
		}
	}

	private void OnMouseUp()
	{
		if (state == BirdState.BeforeShoot)
		{
			isMouseDown = false;
			Slingshot.Instance.EndDraw();
			Fly();
		}
	}

	private void MoveControl()
	{
		if (isMouseDown)
		{
			transform.position = GetMousePostion();
		}
	}

	private Vector3 GetMousePostion()
	{
		Vector3 centerPosition = Slingshot.Instance.GetCenterPosition();
		Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePosition.z = 0;
		Vector3 mouseDirection = mousePosition - centerPosition;
		float distance = mouseDirection.magnitude;
		if (distance > maxDistance)
		{
			mousePosition = mouseDirection.normalized * maxDistance + centerPosition;
		}
		return mousePosition;
	}

	private void Fly()
	{
		rgd.bodyType = RigidbodyType2D.Dynamic;
		rgd.velocity = (Slingshot.Instance.GetCenterPosition() - transform.position).normalized * flySpeed;
		state = BirdState.AfterShoot;
	}
}
