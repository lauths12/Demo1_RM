using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;
    private NavMeshAgent agent;
    private Animator animator;

    [Header("Patrullaje")]
    public float wanderRadius = 8f;
    public float minWaitTime = 2f;
    public float maxWaitTime = 4f;


    [Header("Detección")]
    public float visionRange = 10f;        // Distancia máxima para ver al jugador
    public float visionAngle = 120f;       // Ángulo de visión más realista
    public float detectionTime = 1.5f;     // Tiempo que debe verte para empezar persecución
    public float loseSightTime = 2f;       // Tiempo sin verlo para dejar de perseguir
    public float instantChaseDistance = 3f; // Si estás muy cerca, te persigue de inmediato


    [Header("Linterna Debug")]
    public Light eyeLight; // Asigna la luz en el inspector
    public bool onlyLightOnChase = false; // Si quieres que se encienda solo al perseguir



    private bool isWaiting = false;
    private bool isChasing = false;
    private float playerVisibleTimer = 0f;
    private float playerLostTimer = 0f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Configuración inicial del NavMeshAgent
        agent.autoBraking = false;
        agent.stoppingDistance = 0.2f;
        agent.acceleration = 12f;
        agent.angularSpeed = 300f;

        GotoRandomPoint();
    }

    void Update()
    {
        if (player == null) return;

        bool canSeePlayer = CanSeePlayer();

        // Si está persiguiendo al jugador
        if (isChasing)
        {
            if (canSeePlayer)
            {
                playerLostTimer = 0f;
                agent.destination = player.position;
            }
            else
            {
                playerLostTimer += Time.deltaTime;

                // Si lo pierde de vista, vuelve a patrullar
                if (playerLostTimer >= loseSightTime)
                {
                    isChasing = false;
                    GotoRandomPoint();
                }
            }
        }
        else
        {
            // Si el jugador está MUY cerca, empieza persecución inmediata
            if (Vector3.Distance(transform.position, player.position) <= instantChaseDistance)
            {
                isChasing = true;
                agent.destination = player.position;
            }
            else if (canSeePlayer)
            {
                playerVisibleTimer += Time.deltaTime;

                // Si lo ve X segundos, empieza persecución
                if (playerVisibleTimer >= detectionTime)
                {
                    isChasing = true;
                    agent.destination = player.position;
                }
            }
            else
            {
                playerVisibleTimer = 0f;

                // Si llegó a su destino y no persigue, espera y luego se mueve
                if (!isWaiting && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    StartCoroutine(WaitAndMove());
                }
            }
        }

        // ✅ Manejo de animaciones
        bool isWalking = agent.velocity.magnitude > 0.1f;
        animator.SetBool("Walking", isWalking);

        // Rotación suave hacia la dirección de movimiento
        if (agent.velocity.sqrMagnitude > 0.05f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }

        // ✅ Actualizamos la luz para que coincida con el rango y ángulo de visión
        if (eyeLight != null)
        {
            eyeLight.range = visionRange;
            eyeLight.spotAngle = visionAngle;

            // Si activamos "onlyLightOnChase", la luz solo se enciende cuando persigue
            if (onlyLightOnChase)
                eyeLight.enabled = isChasing;
            else
                eyeLight.enabled = true;
        }



    }

    private IEnumerator Investigate(Vector3 targetPos)
    {
        // Ir hacia la posición del objeto
        agent.isStopped = false;
        agent.destination = targetPos;

        // Activar animación de caminar
        animator.SetBool("Walking", true);

        // Esperar hasta que llegue cerca
        while (Vector3.Distance(transform.position, targetPos) > agent.stoppingDistance + 0.5f)
        {
            yield return null;
        }

        // Cuando llega al objeto, se detiene
        agent.isStopped = true;
        animator.SetBool("Walking", false);

        // Espera un momento, como si inspeccionara el objeto
        yield return new WaitForSeconds(2f);

        // Reanudar patrullaje normal
        GotoRandomPoint();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScreamManager scream = other.GetComponentInChildren<ScreamManager>();

            if (scream != null)
                scream.ShowScream();
        }
    }


    public void GoToObject(Vector3 objPos)
    {
        if (isChasing) return; // Si ya te está persiguiendo, ignora los objetos

        StopAllCoroutines(); // Detenemos cualquier espera de patrullaje
        StartCoroutine(Investigate(objPos));
    }

    bool CanSeePlayer()
    {
        // Dirección hacia el jugador
        Vector3 directionToPlayer = player.position - transform.position;
        float distance = directionToPlayer.magnitude;

        // Si el jugador está fuera del rango, no lo ve
        if (distance > visionRange)
            return false;

        // Si el jugador está fuera del ángulo de visión, no lo ve
        float angle = Vector3.Angle(transform.forward, directionToPlayer);
        if (angle > visionAngle / 2f)
            return false;

        // Comprobar si hay obstáculos con Raycast
        if (Physics.Raycast(transform.position + Vector3.up, directionToPlayer.normalized, out RaycastHit hit, visionRange))
        {
            return hit.transform.CompareTag("Player");
        }

        return false;
    }

    void GotoRandomPoint()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }
    }

    IEnumerator WaitAndMove()
    {
        isWaiting = true;
        agent.isStopped = true;
        animator.SetBool("Walking", false);

        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        agent.isStopped = false;
        GotoRandomPoint();
        isWaiting = false;
    }

    // ✅ Dibuja el rango y ángulo de visión en la Scene View
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRange);

        Vector3 leftBoundary = Quaternion.Euler(0, -visionAngle / 2, 0) * transform.forward * visionRange;
        Vector3 rightBoundary = Quaternion.Euler(0, visionAngle / 2, 0) * transform.forward * visionRange;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);
    }
}

