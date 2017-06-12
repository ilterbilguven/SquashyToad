using UnityEngine;


public class FrogController : MonoBehaviour
{

	public float[] jumpSpeed = {200, 400, 700};
	public float jumpAngle;

	public int hopCount = 0;
	public int collisionCount = 0;

	public GameObject gameOverUI;
	public GameObject reticule;

	public bool gameOver;

	void Update ()
	{
		if (collisionCount > 0) hopCount = 0;

		if (Input.GetMouseButtonDown(0) && hopCount < jumpSpeed.Length && !gameOver)
		{
			GetComponent<Rigidbody>().AddForce(Vector3.RotateTowards(Vector3.ProjectOnPlane(GetComponentInChildren<Camera>().transform.forward, Vector3.up).normalized, Vector3.up, Mathf.Deg2Rad * jumpAngle, 0) * jumpSpeed[hopCount], ForceMode.VelocityChange);

			hopCount++;
		}
		


	}

	private void GameOver()
	{
		gameOverUI.SetActive(true);
		reticule.SetActive(true);
		gameOver = true;
		GetComponent<Rigidbody>().isKinematic = true;
	}
	private void OnCollisionEnter(Collision collision)
	{
		
		if (collision.collider.CompareTag("Lethal"))
		{
			GameOver();
		}
		else
		{
			collisionCount++;
		}
		
	}


	private void OnCollisionExit(Collision collision)
	{
		collisionCount--;
	}


}
