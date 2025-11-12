using UnityEngine;

public class pickUpBuckshot : MonoBehaviour
{

    public int shellCount = 0;
    public AudioClip chamberEmpty;
    public AudioClip reload;
    public AudioClip gunshot;
    AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
        if (Input.GetKeyDown(KeyCode.Mouse0)) {
            if (shellCount <= 0) {
                audio.clip = chamberEmpty;
                audio.Play();
            }
            if (shellCount > 0) {
                audio.clip = gunshot;
                audio.Play();
                RaycastHit result; 
                Physics.Raycast(ray, out result);
                if (result.collider.gameObject.name == "Target") {
                    GameObject target = result.collider.gameObject;
                    Animation lowerBridge = target.transform.parent.GetComponent<Animation>();
                    lowerBridge.Play("LowerBridge");
                    AudioSource creak = target.GetComponent<AudioSource>();
                    creak.Play();
                }
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "AmmoBox") {
            other.gameObject.SetActive(false);
            audio.clip = reload;
            audio.Play();
            shellCount += 20;
        }
    }
}
