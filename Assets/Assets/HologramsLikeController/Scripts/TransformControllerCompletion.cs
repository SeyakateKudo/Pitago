using HoloToolkit.Unity.InputModule;
using UnityEngine;

namespace HologramsLikeController {
    public class TransformControllerCompletion : MonoBehaviour, IInputClickHandler {

        public bool setActive;
        public bool setDisActive;

        public void OnInputClicked(InputClickedEventData eventData) {
            /* if (setDisActive == true)
             {
                 Transform transformController = transform.parent;
                 GameObject target = transformController.parent.gameObject;
                 // Cubeのレンダラーとコライダーを有効か
                 target.GetComponent<Collider>().enabled = false;
                 // 親オブジェクトを無効化
                 transformController.gameObject.SetActive(true);
                 // debug
                 Debug.Log("TransformController abled.");
             }
             else if (setActive == true) {
                 Transform transformController = transform.parent;
                 GameObject target = transformController.parent.gameObject;
                 // Cubeのレンダラーとコライダーを有効か
                 target.GetComponent<Collider>().enabled = true;
                 // 親オブジェクトを無効化
                 transformController.gameObject.SetActive(false);
                 // debug
                 Debug.Log("TransformController disabled.");
             }*/


            Transform transformController = transform.parent;
            GameObject target = transformController.parent.gameObject;
            // Cubeのレンダラーとコライダーを有効か
            target.GetComponent<Collider>().enabled = true;
            // 親オブジェクトを無効化
            transformController.gameObject.SetActive(false);
            // debug
            Debug.Log("TransformController disabled.");

        }
        private void Start() {
            TransformController tc = transform.GetComponentInParent<TransformController>();

            float posY = tc.PositionControlerScale.y;

            transform.localPosition = new Vector3(0, posY + TransformControlManager.Instance.completePanelPositionY, 0);
        }

        private void Update() {
            transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward);
        }


       /* public void ActiveButton()
        {
            TransformControllerCompletion tras = new TransformControllerCompletion();
            tras.setActive = true;
            tras.setDisActive = false;
        }
        public void DisActiveButton()
        {
            TransformControllerCompletion tras = new TransformControllerCompletion();
            tras.setActive = false;
            tras.setDisActive = true;
        }*/
    }
}