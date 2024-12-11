using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bonbSE;
    AudioSource aud;

    private void Start()
    {
        Application.targetFrameRate = 60;
        this.aud = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            this.aud.PlayOneShot(this.appleSE);
        }
        else
        {
            this.aud.PlayOneShot(this.bonbSE);
        }
        Destroy(other.gameObject);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(00))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , Mathf.Infinity))
            {
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                transform.position = new Vector3(x, 0, z);
            }
        }
    }
}
