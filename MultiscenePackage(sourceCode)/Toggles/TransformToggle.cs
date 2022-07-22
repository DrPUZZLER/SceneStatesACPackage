using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC {
    [RequireComponent(typeof(Transform))]
    public class TransformToggle : MonoBehaviour {


        //the field for the manager object. This variable should not be manually
        //changed, the script will insert the object in when the scene loads
        [SerializeField] Manager toggleManager;

        //the states for the object to be in depending on what value the global variable is set to
        [Header("Transform on True")]

        [SerializeField] Vector3 translationOnTrue;
        [SerializeField] Quaternion rotationOnTrue;
        [SerializeField] Vector3 scaleOnTrue = new Vector3(1, 1, 1);


        [Header("Transform on False")]

        [SerializeField] Vector3 translationOnFalse;
        [SerializeField] Quaternion rotationOnFalse;
        [SerializeField] Vector3 scaleOnFalse = new Vector3(1, 1, 1);


        //negate effect will ignore the current value of the global variable
        [Header("Negate Effect")]

        [SerializeField] public bool negateEffect;

        //component variables below
        Transform objectTransform;


        //initial setup
        void Start() {
            toggleManager = FindObjectOfType<Manager>();
            objectTransform = GetComponent<Transform>();

            //if negate effect is on by default
            if (negateEffect) {
                TurnOn();
            } 
        }

        
        void Update() {
            if (!negateEffect) {
                UpdateSprite();
            }
        }

        //handles the code for updating the sprite based on the variable
        void UpdateSprite() {
            //checks if the global variable is true
            if (toggleManager.toggleVar == true) {
                Debug.Log("TransformToggle: toggleVar is TRUE");
                //sets object to the state defined by showOnTrue
                objectTransform.position = translationOnTrue;
                objectTransform.rotation = rotationOnTrue;
                objectTransform.localScale = scaleOnTrue;

            } else if (toggleManager.toggleVar == false) {
                Debug.Log("TransformToggle: toggleVar is FALSE");
                //sets object to the state defined by showOnFalse
                objectTransform.position = translationOnFalse;
                objectTransform.rotation = rotationOnFalse;
                objectTransform.localScale = scaleOnFalse;
            }
        }


        //methods for the object:send message action to access to turn on/off negate effect.
        public void TurnOn() {
            negateEffect = true;

        }
        public void TurnOff() {
            negateEffect = false;
        }
    }
}


