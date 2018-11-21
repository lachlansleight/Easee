using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaseTester : MonoBehaviour
{

	public Easeee.EaseType EaseType;
	public int EasePower;
	[Range(0.1f, 30f)] public float Duration = 5f;
	
	public void Start ()
	{
		StartCoroutine(DoEase());
	}

	private IEnumerator DoEase()
	{
		var startPosition = transform.position;
		var endPosition = transform.position;
		endPosition.x *= -1;

		for (var i = 0f; i < 1f; i += Time.deltaTime / Duration) {
			transform.position = Vector3.Lerp(startPosition, endPosition, Easeee.Ease(EaseType, EasePower, i));
			yield return null;
		}

		transform.position = endPosition;

		yield return new WaitForSeconds(0.5f);
		StartCoroutine(DoEase());
	}
}
