using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test2 : MonoBehaviour {

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
			StartCoroutine(CreateTree(point));
		}

	}

	IEnumerator CreateTree(Vector2 point)
	{
		yield return new WaitForSeconds(Random.Range(0.2f, 1.5f));

		float randomScale = Random.Range(0.5f, 1.5f);

		tree.transform.localScale = Vector3.one * randomScale;

		Instantiate(tree, new Vector3(point.x, 0f, point.y), Quaternion.identity);

		//StartCoroutine(Popup(tree));
		
		yield return null;

		
	}

	IEnumerator Popup(GameObject tree)
    {
		Vector3 initialScale = Vector3.zero;

		float randomScale = Random.Range(0.5f, 1.5f);

		for (float i = 0f; i <= randomScale; i += Time.deltaTime)
		{
			tree.transform.localScale = Vector3.Lerp(initialScale, Vector3.one * randomScale, i);
			Debug.Log(i);
			yield return null;
		}

	}

    void OnValidate() 
	{
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
