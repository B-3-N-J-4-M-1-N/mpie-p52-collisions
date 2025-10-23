using UnityEngine;

public class pickUpBuckshot : MonoBehaviour
{

    public int shellCount = 0;
    public GameObject ammoBox = GetComponent<AmmoBox>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider Other) {
        ammoBox.SetActive(false);
        shellCount += 20;
    }
}
