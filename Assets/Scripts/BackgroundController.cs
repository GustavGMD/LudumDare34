using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

    public Sprite[] backgroundSprites;

	public void SetBackground(int index)
    {
        GetComponent<SpriteRenderer>().sprite = backgroundSprites[index];
    }
}
