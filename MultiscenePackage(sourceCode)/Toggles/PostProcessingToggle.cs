using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace AC {
    [RequireComponent(typeof(Volume))]
    public class PostProcessingToggle : MonoBehaviour {


        //the field for the manager object. This variable should not be manually
        //changed, the script will insert the object in when the scene loads
        [SerializeField] Manager toggleManager;

        //the states for the object to be in depending on what value the global variable is set to
        [Header("States to enable object")]
    
        [SerializeField] bool enableOnTrue = true;
        [SerializeField] bool enableOnFalse = false;


        //negate effect will ignore the current value of the global variable, and set it to whatever
        //state is defined below.
        [Header("Negate Effect")]

        [SerializeField] bool enableOnNegate = true;
        [SerializeField] public bool negateEffect = false;

        //component variables below
        Volume objectVolume;


        //initial setup
        void Start() {
            toggleManager = FindObjectOfType<Manager>();
            objectVolume = GetComponent<Volume>();

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
                Debug.Log("PostProcessingToggle: toggleVar is TRUE");
                //sets object to the state defined by showOnTrue
                objectVolume.enabled = enableOnTrue;
                
            } else if (toggleManager.toggleVar == false) {
                Debug.Log("PostProcessingToggle: toggleVar is FALSE");
                //sets object to the state defined by showOnFalse
                objectVolume.enabled = enableOnFalse;
            }
        }


        //methods for the object:send message action to access to turn on/off negate effect.
        public void TurnOn() {
            negateEffect = true;
            //sets object to the state defined by showOnNegate
            objectVolume.enabled = enableOnNegate;

        }
        public void TurnOff() {
            negateEffect = false;
        }

        public void LoadSet(bool negate) {
            if (negate == true) {
                objectVolume.enabled = enableOnNegate;
            }

        }
    }
}


