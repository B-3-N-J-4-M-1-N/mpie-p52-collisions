using UnityEngine;

public class pickUpBuckshot : MonoBehaviour
{

    public int shellCount = 0;
    public AudioClip reload;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (shellCount <= 0) {
                AudioSource chamberEmpty = GetComponent<AudioSource>();
                chamberEmpty.Play();
            }
            if (shellCount > 0) {
                RaycastHit result; 
                Physics.Raycast(ray, out result);
                if (result.collider.gameObject.name == "Target") {
                    GameObject g = result.collider.gameObject;
                    Animation a = g.transform.parent.GetComponent<Animation>();
                    a.Play("LowerBridge");
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "AmmoBox") {
            AudioSource reload = GetComponent<AudioSource>();
            reload.Play();
            other.gameObject.SetActive(false);
            shellCount += 20;
        }
    }
}
