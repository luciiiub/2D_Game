using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject panelToShow;   // Panel de UI que se mostrara al ganar (asignar en el Inspector)

    // Se ejecuta cuando otro objeto entra en el trigger 2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el objeto que entra es el jugador
        if (collision.gameObject.tag == "Player")
        {
            UnityEngine.Time.timeScale = 0; // Pausa el juego (detiene el tiempo)
            panelToShow.SetActive(true);  // Muestra el panel de victoria
        }
    }
}
