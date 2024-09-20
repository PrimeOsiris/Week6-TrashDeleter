using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallLauncher : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject Projectile;
    public float launchSpeed = 10f;
    public LineRenderer lineRenderer;
    public int linePoints = 175;
    public float TimeIntervalInPoints = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
        lineRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        DrawTrajectory();
        if(Input.GetKeyDown(KeyCode.Space)){
            var _projectile = Instantiate(Projectile, launchPoint.position, launchPoint.rotation);
            _projectile.GetComponent<Rigidbody>().velocity = launchSpeed * launchPoint.up;
        }
    }

    void DrawTrajectory(){
        Vector3 origin = launchPoint.position;
        Vector3 StartVelocity = launchSpeed * launchPoint.up;
        lineRenderer.positionCount = linePoints;

        float time = 0;

        for (int i =0; i<linePoints; i++){
            var x = (StartVelocity.x * time) + (Physics.gravity.x/2*time*time);
            var y = (StartVelocity.y * time) + (Physics.gravity.y/2*time*time);
            Vector3 point = new Vector3(x,y,0);
            lineRenderer.SetPosition (i, origin+point);
            time += TimeIntervalInPoints;
        }

        //s = u*t + 1/2*g*t*t
    }
}
