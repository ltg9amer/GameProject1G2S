using TMPro;
using UnityEngine;

public class GameOverSceneCOD : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI codText;

    private void Start()
    {
        codText.text = GameEndProcess.death.deathName;
    }
}
