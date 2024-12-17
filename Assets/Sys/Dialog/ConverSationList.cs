using System.Collections.Generic;
using UnityEngine;

namespace system
{
    public class DialogLocation
    {
        public DialogNode dialogNode;
        public int idx;
        public int eventIdx;
    }
    public static class ConversationList
    {
        public static Dictionary<string, DialogLocation> Dialogs= new();
    }
}
