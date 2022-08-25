/*
Author: Ryan Zollinger (Dr. Puzzler#1894)
Made for Ab.
Updated with 3D mesh support for Moosifer

This add-on for the Adventure Creator plugin allows for objects to easily be enabled/disabled depending on the value of a global variable. 

This package has a total of 13 scripts. One manager, 6 toggle components, and 6 remember components for each toggle.

How to use:
If you don't want to read the text description as much as I don't want to write it, you can find a YouTube tutorial below:
https://www.youtube.com/watch?v=WxuvFQW94E4

The Manager gameObject:
The first thing you'll need to do is set up the Manager gameObject. In order for these scripts to work, you'll need a manager gameObject in each scene you want to be affected.
To get started, create a Boolean AC Global Variable, and name it whatever you want. You can also set the value to whatever you want.
Once you've done that, create a new empty gameObject, and name it Manager (the name doesn't really matter, but you'll want to name it something relevant). Once you've done that, add the Manager component to the gameObject. Once done, you will see 3 variables. The top variable is all you'll need to worry about. The bottom two are there for debugging purposes, you won't need to worry about editing them at all. The top variable should be labeled Variable Name. In that field, you'll need to type in the name of the Global Variable you created. Once you've done that, you've set up your manager, and the rest of the scripts will be ready to go for that scene!

The Toggle components:
These next sections will be an overview of the purpose of each toggle. All of these components are very similar in layout. There is a value for when the Global Variable is set to true, and a value for when it is false. There is also a 'negate effect' state on most components that allow for more flexibility if objects need to be changed independently from the Global Variable value. For each toggle, you can enable/disable Negate Effect by using the Object:Send Message action. Just use the Turn On/Turn Off messages to enable/disable Negate Effect.

VisibilityToggle:
The VisibilityToggle is pretty straightforward, it will make a spriteRenderer visible/invisible depending on the Global Variable value. It will also have a default state for when Negate Effect is enabled. This DOES NOT work on 3D meshes.

VisibilityToggle3D:
The VisibilityToggle3D works exactly the same as VisibilityToggle, but instead of affecting 2D sprites it will affect 3D meshes. This DOES NOT work on 2D sprites.

HotspotToggle:
This is also pretty straightforward, it will enable/disable a hotspot depending on the Global Variable value. It will also have a default state for when Negate Effect is enabled.

TintToggle:
The TintToggle is slightly different from the last two. Instead of setting a boolean value to enable disable, you can set a colour for the object to tint too. Like the others, there is a value for when the Global Variable is true, and when it is false. And there is also a default colour for when NegateEffect is enabled.

TransformToggle:
This is a lot like the TintToggle in that there is not a boolean enable/disable value, but instead there is a transform for both the true and false value of the Global Variable. For both, there is a Position, Rotation, and Scale. Unlike the others though, this DOES NOT have a default value for Negate Effect, instead it will just retain the current value when Negate Effect is Enabled.

PostProcessingToggle:
This is a lot like visibility and hotspot toggles, it has a boolean enable/disable value for when the Global Variable is true/false. And similarly, there is also a default value for Negate Effect.
 
Remember components:
For each toggle component is a remember component. These remember components are optional. The only data they save is the current value of Negate Effect, and when a scene/save is loaded, it will set the object to correctly reflect its value.
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AC
{
    public class Manager : MonoBehaviour
    {

        //various variables and setup
        [Header("Global Variable Name")]
        [SerializeField] string variableName;
        [Header("Variables below shown for debugging, do not edit")]
        [SerializeField] GVar toggleGVar;
        public bool toggleVar;



        void Update()
        {
            if (variableName == "")
            {
                Debug.LogError("Variable name is not set. Please input a variable name into this field");
            }
            else
            {
                //set the toggleVar to the string given in the inspector
                toggleGVar = GlobalVariables.GetVariable(variableName);
                toggleVar = toggleGVar.BooleanValue;
                Debug.Log(toggleVar);
            }

        }

    }


}

