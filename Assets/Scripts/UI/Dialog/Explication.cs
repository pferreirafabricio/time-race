using System.Collections;
using TMPro;
using UnityEngine;
using TimeRace.Resources;
using UnityEngine.UI;

namespace TimeRace.UI.Dialog
{
    public class Explication : BaseDialogController
    {
        void Awake()
        {
            ResourceBase = Resource.Language["pt-BR"].Explication;
        }
    }
}