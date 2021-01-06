using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class ChesspieceEntity : MonoBehaviour
{
    [SerializeField]
    private AssetReference _chessPieceReference;

    private void Awake()
    {
        //_chessPieceReference.LoadAssetAsync<Sprite>().Completed += OnDataLoaded;
    }

    private void OnDataLoaded(AsyncOperationHandle<Sprite> piece)
    {
        //var spriteRenderer = GetComponent<SpriteRenderer>();
        //spriteRenderer.sprite = piece.Result;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
