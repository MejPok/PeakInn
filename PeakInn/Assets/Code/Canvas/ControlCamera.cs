using UnityEngine;

public class ControlCamera : MonoBehaviour
{
    public GameObject camera;

    public Transform lobbyTransform;
    public Transform roomsTransform;

    public GameObject leftArrow;
    public GameObject rightArrow;
    public bool ShowingLobby = true;

    private void Update()
    {
        if (ShowingLobby)
        {
            rightArrow.SetActive(true);
            leftArrow.SetActive(false);
            camera.transform.position = new Vector2(lobbyTransform.position.x, lobbyTransform.position.y);
        }
        else
        {
            rightArrow.SetActive(false);
            leftArrow.SetActive(true);
            camera.transform.position = new Vector2(roomsTransform.position.x, camera.transform.position.y);

        }
    }

    public void ShowLobby(bool showingLobby)
    {
        ShowingLobby = showingLobby;
    }


}
