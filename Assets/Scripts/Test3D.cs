using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test3D : MonoBehaviour {

	public Vector3 startingPoint = Vector3.zero;
	public float radius = 1;
	public Vector3 regionSize = Vector3.one;
	public int rejectionSamples = 30;
	public float displayRadius =1;

	public GameObject tree;

	List<Vector3> points;


    private void Start()
    {

		foreach (Vector3 point in points)
		{
			StartCoroutine(CreateTree(point));

		}

	}

	IEnumerator CreateTree(Vector3 point)
	{
		yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));

		float randomScale = Random.Range(0.5f, 1.5f);

		tree.transform.localScale = Vector3.one * randomScale;

		Instantiate(tree, new Vector3(point.x, point.y, point.z) + startingPoint, Quaternion.identity);
		
		yield return null;

		
	}

    void OnValidate() 
	{
		points = PoissonDiscSampling3D.GeneratePoints(radius, regionSize, rejectionSamples);

		
	}

	void OnDrawGizmos() {
		
		Gizmos.DrawWireCube(new Vector3(regionSize.x/2,regionSize.y/2, regionSize.z/2) + startingPoint, new Vector3(regionSize.x, regionSize.y, regionSize.z));

		if (points != null) {
			foreach (Vector3 point in points) {
				Vector3 position = new Vector3(point.x, point.y, point.z) + startingPoint;
				Gizmos.DrawSphere(position, displayRadius);
			}
		}
	}
}
