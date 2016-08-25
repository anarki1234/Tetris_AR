using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Block_Spawner : MonoBehaviour
{

	public GameObject startPoint;
    public GameObject[] block;
    public Sprite[] icon;
    private GameObject nextBlock;
    private Image nextImage;
    private Score_Tracker score;

    // Use this for initialization
    void Start()
    {
        nextImage = GameObject.Find("Canvas/Image").GetComponent<Image>();
        score = GetComponent<Score_Tracker>();
        NextBlock();
        CreateBlock();
    }

    // Determines which type of block will drop next and displays the appropriate sprite
    public void NextBlock()
    {
        int x = Random.Range(0, 7);
        nextBlock = block[x];
        nextImage.sprite = icon[x];
    }

    // Creates the new block
    public void CreateBlock()
    {
        if (nextBlock != null)
        {
			GameObject go=
				Instantiate(nextBlock, startPoint.transform.position, startPoint.transform.localRotation) as GameObject;
			go.transform.parent = this.transform;
			NextBlock();
        }
        else
        {
            NextBlock();
			GameObject go=
				Instantiate(nextBlock, startPoint.transform.position, startPoint.transform.localRotation) as GameObject;
			go.transform.parent = this.transform;
		}
        score.NewBlock();
    }
}
