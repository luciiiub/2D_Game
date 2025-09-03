using UnityEngine;

public class ItemScore : MonoBehaviour
{
    public GameManagerScene manager; // Referencia al GameManager (asignar manualmente o buscarlo en Start)

    public int itemScore = 5; // Puntos que otorga este objeto al jugador

    void Start()
    {
        // Buscar el objeto llamado "GameManagerScene" y obtener su componente GameManagerScene
        manager = GameObject.Find("GameManagerScene").GetComponent<GameManagerScene>();
    }

    // Se ejecuta cuando otro objeto con Collider2D entra en contacto con este trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que colisiono tiene la etiqueta "Player"
        if (collision.gameObject.tag == "Player")
        {
            // Agrega el puntaje al GameManager
            manager.AddScore(itemScore);

            // Destruye este objeto (el item)
            Destroy(gameObject);
        }
    }
}
