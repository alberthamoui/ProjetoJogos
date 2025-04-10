using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public Transform player;
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3f;
    public float chaseDistance = 3f;

    private Rigidbody2D rb;
    private Transform patrolTarget;
    private bool isChasing = false;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        patrolTarget = pointB;
    }

    void Update(){
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseDistance)
        {
            isChasing = true;
        }
        else if (isChasing && distanceToPlayer > chaseDistance + 1f)
        {
            // Se o jogador se afastar bastante, volta a patrulhar
            isChasing = false;
        }
    }

    void FixedUpdate(){
        if (isChasing)
        {
            MoveTo(player.position, chaseSpeed);
        }
        else
        {
            Patrol();
        }
    }

    void Patrol(){
        MoveTo(patrolTarget.position, patrolSpeed);

        float distance = Vector2.Distance(transform.position, patrolTarget.position);
        if (distance < 0.1f)
        {
            patrolTarget = (patrolTarget == pointA) ? pointB : pointA;
        }
    }

    void MoveTo(Vector2 target, float speed){
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }

    void OnCollisionEnter2D(Collision2D other){
        Debug.Log("Colisão detectada com: " + other.collider.name);

        if (other.collider.CompareTag("Player")){
            Debug.Log("Fim de jogo! O jogador foi pego.");
            GameController.EndGame();
        }
    }
}
