using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;     // Puntaje actual del jugador
    public Text textoPuntuacion;   // Referencia al texto UI donde se muestra el puntaje

    // Update se ejecuta una vez por frame
    void Update()
    {
        // Actualiza el texto de la UI con el puntaje actual
        textoPuntuacion.text = "Score: " + score.ToString();
    }

    // Metodo para sumar puntos al puntaje
    public void AddScore(int i)
    {
        score += i;
    }

    // Metodo para restar puntos del puntaje
    public void RemoveScore(int i)
    {
        score -= i;
    }
}
