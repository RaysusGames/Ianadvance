using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    private bool stageComplete;
    public bool gameStarted;
    [SerializeField] private float sideSwipeForce = 5f;
    [SerializeField] private float launchForce = 5f;
    private Vector3 launchVector;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //StartCoroutine(AutoKeepMoving());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildLaunchForce(Vector3 launcherPos)
    {
        launchVector = rb.position - launcherPos;
        //rb.AddForce(launcherPos - rb.position, ForceMode.Impulse);
        //StartCoroutine(AutoKeepMoving());
    }
    public void LaunchBall()
    {
        rb.AddForce(launchVector * launchForce, ForceMode.Impulse);
        StartCoroutine(AutoKeepMoving());
    }
    public void PushForce(Vector2 force)
    {
        rb.AddForce(new Vector3(force.x * sideSwipeForce, 0f, force.y), ForceMode.Force);
    }

    private IEnumerator AutoKeepMoving()
    {
        while (!stageComplete)
        {
            if (rb.velocity.z < 5f)
            {
                rb.AddForce(Vector3.forward * 2f, ForceMode.Force);
                yield return null;
            }
            else
            {
                yield return null;
            }
        }        
    }
}
