using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * verticalInput * horizontalInput);

        if (transform.position.y < -5)
        {
            loseScreen.SetActive(true);
        }
        else if (transform.position.z > 78)
        {
            winScreen.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        //Sets the position to zero
        transform.position = Vector3.zero;
        //Sets the rotation to zero
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        
        //Hides winScreen and loseScreen *- at least one of them showed up at the end game -*
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
    }
}
