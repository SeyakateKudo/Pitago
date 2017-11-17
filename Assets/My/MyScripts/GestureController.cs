using HoloToolkit.Unity.InputModule;
using UnityEngine;
using UnityEngine.VR.WSA.Input;

public class GestureController : MonoBehaviour
{

    private Vector3 prevPos;
    private bool isHold;
    private GameObject focusObj;

    // Use this for initialization
    void Start()
    {
        InteractionManager.SourcePressed += InteractionManager_SourcePressed;
        InteractionManager.SourceReleased += InteractionManager_SourceReleased;
        InteractionManager.SourceLost += InteractionManager_SourceLost;
        InteractionManager.SourceUpdated += InteractionManager_SourceUpdated;
    }

    // Update is called once per frame
    void Update()
    {
        var obj = GazeManager.Instance.HitObject;

        // ホールドしている時は、オブジェクト入れ替えない
        if (obj != null && !isHold)
        {
            // TagがInteractionのものだけを対象とする
            if (obj.tag == "Untagged" || obj.tag == "Player")
            {
                focusObj = obj;
            }
        }
    }

    private void InteractionManager_SourcePressed(InteractionSourceState state)
    {
        if (focusObj == null) return;

        focusObj.GetComponent<Rigidbody>().useGravity = false;

        Vector3 handPosition;
        if (state.source.kind == InteractionSourceKind.Hand &&
            state.properties.location.TryGetPosition(out handPosition))
        {
            isHold = true;
            prevPos = handPosition;
        }
    }

    private void InteractionManager_SourceReleased(InteractionSourceState state)
    {
        if (focusObj == null) return;

        focusObj.GetComponent<Rigidbody>().useGravity = true;
        isHold = false;
        focusObj = null;
    }

    private void InteractionManager_SourceLost(InteractionSourceState state)
    {
        if (focusObj == null) return;

        focusObj.GetComponent<Rigidbody>().useGravity = true;
        isHold = false;
        focusObj = null;
    }

    private void InteractionManager_SourceUpdated(InteractionSourceState state)
    {
        if (!isHold || focusObj == null) return;

        Vector3 handPosition;
        state.properties.location.TryGetPosition(out handPosition);

        if (state.source.kind == InteractionSourceKind.Hand &&
            state.properties.location.TryGetPosition(out handPosition))
        {
            var moveVector = Vector3.zero;
            moveVector = handPosition - prevPos;

            prevPos = handPosition;

            var handDistance = Vector3.Distance(Camera.main.transform.position, handPosition);
            var objectDistance = Vector3.Distance(Camera.main.transform.position, focusObj.transform.position);

            focusObj.transform.position += (moveVector * (objectDistance / handDistance));
        }
    }
}