using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Patrol : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    [Header("Movimiento libre")]
    public float wanderRadius = 10f;         // Radio máximo donde puede moverse
    public float minWaitTime = 2f;           // Tiempo mínimo de espera
    public float maxWaitTime = 5f;           // Tiempo máximo de espera
    public float stoppingThreshold = 0.3f;   // Umbral para considerar que llegó

    private bool isWaiting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        // Configurar agente para movimientos más naturales
        agent.autoBraking = false;
        agent.stoppingDistance = stoppingThreshold;
        agent.acceleration = 12f;
        agent.angularSpeed = 300f;
        agent.updateRotation = true;

        // Iniciar primer destino
        GotoRandomPoint();
    }

    void Update()
    {
        // Si está esperando, no hacemos nada
        if (isWaiting)
            return;

        // Actualizar animación según velocidad
        bool isWalking = agent.velocity.magnitude > 0.2f;
        animator.SetBool("Walking", isWalking);

        // Rotación suave hacia la dirección del movimiento
        if (agent.velocity.sqrMagnitude > 0.05f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(agent.velocity.normalized);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
        }

        // Si llegó al destino, esperar y luego buscar otro punto
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance + 0.05f)
        {
            StartCoroutine(WaitAndMove());
        }
    }

    void GotoRandomPoint()
    {
        // Buscar un punto aleatorio dentro de un radio usando NavMesh
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, NavMesh.AllAreas))
        {
            agent.destination = hit.position;
        }
    }

    IEnumerator WaitAndMove()
    {
        isWaiting = true;

        // Detenerse y poner animación Idle
        agent.isStopped = true;
        animator.SetBool("Walking", false);

        // Esperar un tiempo aleatorio para mayor naturalidad
        float waitTime = Random.Range(minWaitTime, maxWaitTime);
        yield return new WaitForSeconds(waitTime);

        // Reanudar movimiento
        agent.isStopped = false;
        GotoRandomPoint();

        isWaiting = false;
    }
}