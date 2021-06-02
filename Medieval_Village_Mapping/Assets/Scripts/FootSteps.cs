using UnityEngine;

public class FootSteps : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] roadClips;
    [SerializeField]
    private AudioClip[] mudClips;
    [SerializeField]
    private AudioClip[] grassClips;
    [SerializeField]
    private AudioClip[] drinkingClips;

    private AudioSource audioSource;
    private TerrainDetector terrainDetector;

    public GameObject InHandObject;


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
		//create a new TerrainDetector 
        terrainDetector = new TerrainDetector();
    }

    private void Step()
    {
		//method GetRandomClip is called
        AudioClip clip = GetRandomClip();
		//play audio
        audioSource.PlayOneShot(clip);
    }

    private AudioClip GetRandomClip()
    {
		//get the index of current terrain
        int terrainTextureIndex = terrainDetector.GetActiveTerrainTextureIdx(transform.position);

        //switch case for terrainTextureIndex
		//each case returns a random clip
		switch (terrainTextureIndex)
        {
            case 0:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
            case 1:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
            case 8:
                return grassClips[UnityEngine.Random.Range(0, grassClips.Length)];
            case 2:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 3:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            case 4:
                return mudClips[UnityEngine.Random.Range(0, mudClips.Length)];
            default:
                return roadClips[UnityEngine.Random.Range(0, roadClips.Length)];
        }
    }
    private void EndDrinking()
    {
		//audio clip for EndDrinking potion
        AudioClip clip = drinkingClips[1];
        audioSource.PlayOneShot(clip);
        Destroy(InHandObject);
    }

    private void Drinking()
    {
		//audio clip for Drinking potion
        AudioClip clip = drinkingClips[0];
        audioSource.PlayOneShot(clip);
    }
}
