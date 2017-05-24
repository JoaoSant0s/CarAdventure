
using UnityEngine;
using UnityEngine.UI;

namespace CarAdventure.Entity.Component {

    public class FollowCar : MonoBehaviour {

        [SerializeField]
        Transform targetedUnit;
        [SerializeField]
        Color colorPoint;

        RectTransform rectTransform;
        Image rawImage;
        Camera cam;

        void Start() {
            InitGlobalVariables();

            rawImage.color = new Color(colorPoint.r, colorPoint.g, colorPoint.b);
        }

        void InitGlobalVariables() {
            rectTransform = (RectTransform)transform;
            cam = GameObject.FindGameObjectWithTag("MiniMapCamera").GetComponent<Camera>();
            rawImage = GetComponent<Image>();
        }

        void Update() {
            Vector3 screenPos = cam.WorldToViewportPoint(targetedUnit.position);
            rectTransform.anchorMin = screenPos;
            rectTransform.anchorMax = screenPos;
        }

    }
}