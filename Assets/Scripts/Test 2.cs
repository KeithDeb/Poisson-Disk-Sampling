using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

	public float radius = 1;
	public Vector2 regionSize = Vector2.one;
	public int rejectionSamples = 30;
	public float displayRadius =1;

	public GameObject tree;

	List<Vector2> points;


    private void Start()
    {

		foreach (Vector2 point in points)
		{

			Instantiate(tree, new Vector3(point.x, 0f, point.y), Quaternion.identity);

			float randomScale = Random.Range(0.5f, 1.5f);
			tree.transform.localScale = Vector3.one * randomScale;
		}

	}

    void OnValidate() {
		points = PoissonDiscSampling.GeneratePoints(radius, regionSize, rejectionSamples);


	}

	void OnDrawGizmos() {

		Gizmos.DrawWireCube(new Vector3(regionSize.x/2,0f,regionSize.y/2), new Vector3(regionSize.x, 0f, regionSize.y));

		if (points != null) {
			foreach (Vector2 point in points) {
				Vector3 position = new Vector3(point.x, 0f, point.y);
				Gizmos.DrawSphere(position, displayRadius);
			}
		}
	}
}
