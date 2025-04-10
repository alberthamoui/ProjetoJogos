using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    AudioSource audioSource;
    public float speed;
    public GameUIManager uiManager;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        speed = 5;


        int totalColetaveis = GameObject.FindGameObjectsWithTag("Coletavel").Length;
        GameController.Init(totalColetaveis);


    }

    void FixedUpdate()
    {
        // To usando RAW pra andar e parar imediatamente
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical");


        Vector2 movement = new Vector2(moveX, moveY);
        rb.MovePosition(rb.position + movement.normalized * Time.fixedDeltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coletavel")
        {
            audioSource.Play();
            Destroy(other.gameObject);
            GameController.Collect();
            // FindFirstObjectByType<GameUIManager>().AddPoint();
            uiManager.AddPoint();

        }

    } 

}
