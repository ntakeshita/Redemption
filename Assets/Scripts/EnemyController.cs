using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	// Type of Enemy: melee - 0, ranged - 1
	public int type;
	private int health;
	private float speed;
	public LayerMask Colliders;    

	private CircleCollider2D circle_collider;

	// Use this for initialization
	void Start () {
	
		this.health = 10;
		circle_collider = GetComponent <CircleCollider2D> ();

	}
	
	// Update is called once per frame
	void Update () {
		Move();
		Attack();
	}
	

	void Attack() {
		return;
	}

	/* Moves character in direction based on Best_Move() heuristics.
	 */
	void Move() {

		// Replace below on when direction choosing implemented. //
		Vector2 move_direction = Best_Move();

		// Checks if direction is valid to move in.
		Vector2 start = transform.position;
		Vector2 end = start + move_direction;

		circle_collider.enabled = false;
		RaycastHit2D hit = Physics2D.Linecast (start, end, Colliders);
		circle_collider.enabled = true;

		Vector2 new_position;
		
		// If ray did not detect a collision then move to that position.
		if (hit.transform == null) {
			new_position = Vector2.MoveTowards(start, end, .5f);
		} else {
			new_position = Vector2.zero;
		}

		GetComponent<Rigidbody2D>().MovePosition(new_position);

	}

	/* NOT IMPLEMENTED!
	 * Based on factors (yet to be determined) will choose best direction.
	 */
	Vector2 Best_Move() {
		return new Vector2(0, 20);
	}

	// Called upon being damaged.
	public void Hit(int damage) {
		health -= damage;
	}
}
