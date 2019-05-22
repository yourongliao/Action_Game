using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {

    private Transform playerIcon;

    void Start()
    {
        playerIcon = Minimap._instance.GetPlayerIcon();
    }

    void Update()
    {
        float y = transform.localEulerAngles.y;

        playerIcon.localEulerAngles = new Vector3(0, 0, -y);
    }
}
