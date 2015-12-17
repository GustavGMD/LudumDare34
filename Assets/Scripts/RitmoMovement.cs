using UnityEngine;
using System.Collections;

public class RitmoMovement : MonoBehaviour {

    public bool continuo = false;
    //public LineRenderer lineRenderer;
    //public Vector3 lineEnd;

	public float step = 0.4f;
	// Use this for initialization
	void Awake () {
        //lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position -= new Vector3(0, step * Time.deltaTime,0);
	}

    /**
    public void SetContinuo(bool value, Vector3 endPosition)
    {
        continuo = value;        
        lineRenderer.SetPosition(1, endPosition);
        //lineRenderer.
        lineEnd = endPosition;
    }
    /**/
}