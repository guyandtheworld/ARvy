using UnityEngine;
using Vuforia;
using System.Collections;

public class ModelSwapper : MonoBehaviour {

    public AnchorStageBehaviour theTrackable;
    
    private AssetBundle SceneAsset;
    //Models management.
    private Transform scene;

    // Use this for initialization
    void Start()
    {
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }
        SceneAsset = AssetBundle.LoadFromFile("C:\\Users\\RustBucket\\Downloads\\shapes.unity3d");
    }

    // Update is called once per frame
    void Update()
    {   

    }

    public void SwapModel(string ModelName)
    {
        GameObject scene = SceneAsset.LoadAsset<GameObject>(ModelName);
        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        GameObject model = GameObject.Instantiate(scene);
        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;
    }
}