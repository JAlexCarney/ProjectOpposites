using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public struct ActionPad {
        public GameObject Marker;
        public GameObject Pad;
        public Vector3 MarkerPosition;

        public ActionPad(GameObject m, GameObject p, Vector3 mp) {
            Marker = m;
            Pad = p;
            MarkerPosition = mp;
        }
    }

    public GameObject Visual;
    public float moveSpeed = 5f;
    public Turtle turtle;
    public Hotbar hotbar;
    public GameObject[] prefabs;
    public GameObject markerPrefab;
    public Transform prefabContainer;
    public Queue<ActionPad> actionPads;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRender;
    private Vector2 movement;
    private bool playing = false;

    void Start()
    {
        actionPads = new Queue<ActionPad>();
        rb = GetComponent<Rigidbody2D>();
        spriteRender = Visual.GetComponent<SpriteRenderer>();
    }

    private void PlacePrefabDestroyMarker(ActionPad PadToPlace)
    {
        Destroy(PadToPlace.Marker);
        GameObject Pad = Instantiate(PadToPlace.Pad, prefabContainer);
        Pad.transform.position = PadToPlace.MarkerPosition;
        movement = Vector2.zero;
    }

    private void Update()
    {
        if (playing) {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hotbar.Select(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hotbar.Select(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hotbar.Select(2);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hotbar.Select(3);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hotbar.Select(4);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hotbar.Select(5);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hotbar.Select(6);
            }
        }

        if (Input.GetMouseButtonDown(0)) 
        {
            if (!playing)
            {
                playing = true;
                turtle.StartWalking();
                hotbar.Show();
            }
            else 
            {
                Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject marker = Instantiate(markerPrefab, prefabContainer);
                marker.transform.position = new Vector3(worldPosition.x, worldPosition.y, 0f);
                ActionPad actionPad = new ActionPad(marker, prefabs[hotbar.selected], marker.transform.position);
                actionPads.Enqueue(actionPad);
            }
        }
    }

    void FixedUpdate()
    {
        if (actionPads.Count > 0) {
            Vector3 goalPosition = actionPads.Peek().MarkerPosition;
            Vector2 distanceToGoal = new Vector2(goalPosition.x - transform.position.x, goalPosition.y - transform.position.y);
            if (distanceToGoal.magnitude > 0.5f)
            {
                movement = distanceToGoal.normalized;
            }
            else
            {
                PlacePrefabDestroyMarker(actionPads.Dequeue());
            }

            // physics
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
