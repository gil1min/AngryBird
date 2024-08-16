using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
	public static Slingshot Instance { get; private set; }
	private LineRenderer leftRenderer;
	private LineRenderer rightRenderer;
	private Transform leftPoint;
	private Transform rightPoint;
	private Transform centerPoint;
	private bool isDrawing = false;
	private Transform birdTransform;
	private void Awake()
	{
		Instance = this;

		leftRenderer = transform.Find("LeftLine").GetComponent<LineRenderer>();
		rightRenderer = transform.Find("RightLine").GetComponent<LineRenderer>();
		leftPoint = transform.Find("LeftPoint");
		rightPoint = transform.Find("RightPoint");
		centerPoint = transform.Find("CenterPoint");
	}
	// Start is called before the first frame update
	void Start()
	{
		

		HideLine();
	}

	// Update is called once per frame
	void Update()
	{
		if (isDrawing)
		{
			Draw();
		}
	}

	public void StartDraw(Transform birdTransform)
	{
		isDrawing = true;
		this.birdTransform = birdTransform;
		ShowLine();
	}

	public void EndDraw()
	{
		isDrawing = false;
		HideLine();
	}

	public void Draw()
	{
		Vector3 birdPosition = birdTransform.position;
		birdPosition = (birdPosition - centerPoint.position).normalized * 0.4f + birdPosition;
		leftRenderer.SetPosition(0, birdPosition);
		leftRenderer.SetPosition(1, leftPoint.position);
		rightRenderer.SetPosition(0, birdPosition);
		rightRenderer.SetPosition(1, rightPoint.position);
	}

	public Vector3 GetCenterPosition()
	{
		return centerPoint.transform.position;
	}

	private void HideLine()
	{
		rightRenderer.enabled = false;
		leftRenderer.enabled = false;
	}

	private void ShowLine()
	{
		rightRenderer.enabled = true;
		leftRenderer.enabled = true;
	}
}
