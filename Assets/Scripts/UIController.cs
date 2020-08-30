using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Button changeLevelButton;
    private GameObject currentRoom;
    private GameObject nextRoom;
    [SerializeField] private PlayerController playerPosition;
    [SerializeField] private Text keys;
    [SerializeField] private Text health;

    private void Awake()
    {
        instance = this;
        changeLevelButton.onClick.AddListener(ChangeRoom);

    }
    private static UIController instance;
    public static UIController Instance
    {
        get { return instance; }
    }
    public void EnableButtom(GameObject currentRoom, GameObject nextRoom)
    {
        changeLevelButton.gameObject.SetActive(true);
        this.currentRoom = currentRoom;
        this.nextRoom = nextRoom;
    }
    public void SetKeys(int keysCount)
    {
        keys.text = keysCount.ToString();
    }
    public void SetHealth(int healthCount)
    {
        health.text = healthCount.ToString();
    }
    public void DisableButtom()
    {
        changeLevelButton.gameObject.SetActive(false);
    }
    public void GameOver()
    {

    }
    private void ChangeRoom()
    {
        playerPosition.MoveOnNextRoom(currentRoom, nextRoom);
        changeLevelButton.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        changeLevelButton.onClick.RemoveListener(ChangeRoom);
    }


}
