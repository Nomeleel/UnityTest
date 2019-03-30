using System;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{

    private Rigidbody rd;
    private const string scoreTextFormat = "Score: {0}";
    private int score;

    public Text scoreText;
    public GameObject winText;
    public int seed = 2;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        rd.AddForce(new Vector3(h, 0, v) * seed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name.StartsWith("cube", StringComparison.InvariantCultureIgnoreCase))
        {
            print(collision.collider.name);
            Destroy(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name.StartsWith("cube", StringComparison.InvariantCultureIgnoreCase))
        {
            scoreText.text = string.Format(scoreTextFormat, ++score);
            winText.SetActive(true);
            Destroy(other.gameObject);            
        }
    }

}
