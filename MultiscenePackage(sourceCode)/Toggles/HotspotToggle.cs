using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC {
    [RequireComponent(typeof(Hotspot))]
    public class HotspotToggle : MonoBehaviour {


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
        Hotspot objectHotspot;


        //initial setup
        void Start() {
            toggleManager = FindObjectOfType<Manager>();
            objectHotspot = GetComponent<Hotspot>();

            //if negate effect is on by default
            if (negateEffect) {
                TurnOn();
            }
        }

        
        void Update() {
            if (!negateEffect) {
                UpdateHotspot();
            }
        }

        //handles the code for updating the sprite based on the variable
        void UpdateHotspot() {
            //checks if the global variable is true
            if (toggleManager.toggleVar == true) {
                Debug.Log("HotspotToggle: toggleVar is TRUE");
                //sets object to the state defined by showOnTrue
                objectHotspot.enabled = enableOnTrue;
                
            } else if (toggleManager.toggleVar == false) {
                Debug.Log("HotspotToggle: toggleVar is FALSE");
                //sets object to the state defined by showOnFalse
                objectHotspot.enabled = enableOnFalse;
            }
        }


        //methods for the object:send message action to access to turn on/off negate effect.
        public void TurnOn() {
            negateEffect = true;
            //sets object to the state defined by showOnNegate
            objectHotspot.enabled = enableOnNegate;

        }
        public void TurnOff() {
            negateEffect = false;
        }

        public void LoadSet(bool negate) {
            if (negate == true) {
                objectHotspot.enabled = enableOnNegate;
            }

        }
    }
}


