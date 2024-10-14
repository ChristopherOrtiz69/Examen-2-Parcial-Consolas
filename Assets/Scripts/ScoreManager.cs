using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public int[] lives = new int[4];
    public TextMeshProUGUI[] lifeTexts;
    public GameObject[] playerObjects; 
    public GameObject[] substituteObjects; 
    public TextMeshProUGUI winnerText;

    private int playersWithLives = 4;

    void Start()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            lives[i] = 15;
            UpdateLifeText(i);
        }
        winnerText.gameObject.SetActive(false);
    }

    public void DecreaseLife(int playerIndex)
    {
        if (playerIndex >= 0 && playerIndex < lives.Length)
        {
            lives[playerIndex]--;
            UpdateLifeText(playerIndex);

            if (lives[playerIndex] <= 0)
            {
                playersWithLives--;
                playerObjects[playerIndex].SetActive(false); 
                substituteObjects[playerIndex].SetActive(true); 

                if (playersWithLives <= 1)
                {
                    StopGame();
                }
            }
        }
    }

    private void UpdateLifeText(int playerIndex)
    {
        if (lifeTexts[playerIndex] != null)
        {
            lifeTexts[playerIndex].text = "Vidas: " + lives[playerIndex].ToString();
        }
    }

    private void StopGame()
    {
        winnerText.gameObject.SetActive(true); 
        int winnerIndex = FindWinner(); 
        if (winnerIndex >= 0)
        {
            winnerText.text = "Ganador: Jugador " + (winnerIndex + 1);
        }

        Debug.Log("El juego se detiene.");
        Time.timeScale = 0; 
    }

    private int FindWinner()
    {
        for (int i = 0; i < lives.Length; i++)
        {
            if (lives[i] > 0) return i; 
        }
        return -1;
    }
}

