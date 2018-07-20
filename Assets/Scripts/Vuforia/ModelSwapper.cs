using UnityEngine;
using Vuforia;
using System.Collections;
public class ModelSwapper : MonoBehaviour
{
    public TrackableBehaviour theTrackable;

    private string currentSceneCounter = "-1";
    private int nextSceneCounter = -1;
    // Use this for initialization

    private string ModelName = null;

    private ViewManager DM;
    public GameObject viewManager;

    void Start()
    {
        DM = viewManager.GetComponent<ViewManager>();
        if (theTrackable == null)
        {
            Debug.Log("Warning: Trackable not set !!");
        }
    }

    void Update()
    {
        currentSceneCounter = DM.GetCurrentScene();
        if (currentSceneCounter != ModelName)
        {
            ModelName = currentSceneCounter;
            SwapModel();
        }
    }

    private void SwapModel()
    {
        GameObject trackableGameObject = theTrackable.gameObject;
        GameObject scene = Resources.Load("Prefabs\\" + ModelName) as GameObject;

        //disable any pre-existing augmentation
        for (int i = 0; i < trackableGameObject.transform.childCount;   i++)
        {
            Transform child = trackableGameObject.transform.GetChild(i);
            child.gameObject.SetActive(false);
        }

        GameObject model = GameObject.Instantiate(scene);

        // Re-parent the cube as child of the trackable gameObject
        model.transform.parent = theTrackable.transform;

        model.transform.localPosition = new Vector3(0f, 0f, 0f);
        model.transform.localRotation = Quaternion.identity;
        model.active = true;
    }
}