using UnityEngine;
using Vuforia;
using System.Collections;
public class ModelSwapper : MonoBehaviour {

    public AnchorStageBehaviour theTrackable;

    //Models management.
    private Transform scene;

    // For swapping models.
    public GameObject checkSwap;
    Selecter skeletor;

    // Use this for initialization
    void Start()
    {
        skeletor = checkSwap.GetComponent<Selecter>();
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }

    }

    // Update is called once per frame
    void Update()
    {   

    }

    public void SwapModel(string ModelName)
    {
        //Loading sphere and cube from resource folder.
        // You have to convert this to using AssetBundles.
        scene = (Transform)Resources.Load("prefabs/" + ModelName, typeof(Transform));

        GameObject trackableGameObject = theTrackable.gameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount; i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        Transform model = GameObject.Instantiate(scene) as Transform;
        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;
        skeletor.resetSwapModel();
    }
}