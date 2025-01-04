using System;
using System.Reflection;
using UnityEngine;
using UnityEngine.Audio;
using MelonLoader;
using Il2CppInterop.Runtime;
using Il2Cpp;

namespace MiSideMenuChanger
{
    public class MyMod : MelonMod
    {
        public override void OnSceneWasInitialized(int buildIndex, string sceneName)
        {
            if (sceneName == "SceneMenu")
            {
                //find menu gameobject
                GameObject menuObj = GameObject.Find("MenuGame");
                if (menuObj == null)
                {
                    LoggerInstance.Warning("Could not find 'MenuGame' GameObject!");
                    return;
                }
                //find menu component
                var altMenu = menuObj.GetComponent<Menu>();
                if (altMenu == null)
                {
                    LoggerInstance.Warning("Could not find 'il2cpp.Menu' on 'MenuGame'!");
                    return;
                }
                altMenu.Alternative();

                //find the music gameobject
                GameObject musicObj = GameObject.Find("MenuGame/Sounds/Music");
                if (musicObj == null)
                {
                    LoggerInstance.Warning("Could not find 'Music' under 'MenuGame/Sounds/'. No tunes for you, player~");
                    return;
                }

                // find audiosource component and play the alt music
                var audioSource = musicObj.GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    LoggerInstance.Warning("No AudioSource found on 'Music' GameObject. Sorry, player >~<");
                    return;
                }

                audioSource.Play();
                LoggerInstance.Msg("Hi darling! You are that determined to see \"that\" side of me? I won't stop you, as I guess I can't. Hehe <3");
            }
        }
    }
}
