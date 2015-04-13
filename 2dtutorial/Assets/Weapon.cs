using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float Damage = 10;
	public LayerMask whatToHit;

	public Transform bulletTrailPrefab;
	float timeToSpanEffect = 0f;
	public float spawnRate = 10;
	float timeToFire = 0;
	Transform firePoint;

	public Transform muscleFlashPrefab;

	// Use this for initialization
	void Awake () {
		firePoint = transform.FindChild ("FirePoint");
		if (firePoint == null) {
			Debug.LogError ("No firePoint? WHAT?!");
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot();
			}
		}
		else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1/fireRate;
				Shoot();
			}
		}
	}
	
	void Shoot () {
		Vector2 mousePosition = new Vector2 (Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		Vector2 firePointPosition = new Vector2 (firePoint.position.x, firePoint.position.y);
		RaycastHit2D hit = Physics2D.Raycast (firePointPosition, mousePosition-firePointPosition, 100, whatToHit);
		if (Time.time >= timeToSpanEffect) {
						Effect ();
			timeToSpanEffect = Time.time + 1/spawnRate;
				}
		Debug.DrawLine (firePointPosition, (mousePosition-firePointPosition)*100, Color.cyan);
		if (hit.collider != null) {
			Debug.DrawLine (firePointPosition, hit.point, Color.red);
			Debug.Log ("We hit " + hit.collider.name + " and did " + Damage + " damage.");
		}
	}

	void Effect(){
		Instantiate (bulletTrailPrefab,firePoint.position,firePoint.rotation);
		Transform clone = (Transform)Instantiate (muscleFlashPrefab,firePoint.position,firePoint.rotation);
		clone.parent = firePoint;
		float size = Random.Range (0.6f,0.9f);
		clone.localScale = new Vector3 (size, size, 0);
		Destroy (clone.gameObject,0.02f);
	}
}
