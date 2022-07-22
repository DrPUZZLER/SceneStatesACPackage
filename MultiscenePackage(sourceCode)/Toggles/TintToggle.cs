using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AC {
    [RequireComponent(typeof(SpriteRenderer))]
    public class TintToggle : MonoBehaviour {


        //the field for the manager object. This variable should not be manually
        //changed, the script will insert the object in when the scene loads
        [SerializeField] Manager toggleManager;

        //the states for the object to be in depending on what value the global variable is set to
        [Header("States to colour object")]

        [SerializeField] Color colourOnTrue = Color.white;
        [SerializeField] Color colourOnFalse = Color.white;


        //negate effect will ignore the current value of the global variable, and set it to whatever
        //state is defined below.
        [Header("Negate Effect")]

        [SerializeField] Color colourOnNegate = Color.white;
        [SerializeField] public bool negateEffect;

        //component variables below
        SpriteRenderer objectSprite;


        //initial setup
        void Start() {
            toggleManager = FindObjectOfType<Manager>();
            objectSprite = GetComponent<SpriteRenderer>();

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
                Debug.Log("TintToggle: toggleVar is TRUE");
                //sets object to the state defined by showOnTrue
                objectSprite.color = colourOnTrue;
                
            } else if (toggleManager.toggleVar == false) {
                Debug.Log("TintToggle: toggleVar is FALSE");
                //sets object to the state defined by showOnFalse
                objectSprite.color = colourOnFalse;
            }
        }


        //methods for the object:send message action to access to turn on/off negate effect.
        public void TurnOn() {
            negateEffect = true;
            //sets object to the state defined by showOnNegate
            objectSprite.color = colourOnNegate;

        }
        public void TurnOff() {
            negateEffect = false;
        }

        public void LoadSet(bool negate) {
            if (negate == true) {
                objectSprite.color = colourOnNegate;
            }

        }
    }
}


