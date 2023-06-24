using UnityEngine;

namespace WiseMonkeES.Mover
{
    public class Mover: MonoBehaviour
    {
        //Singleton
        private static Mover _instance;
        protected static Mover Instance
        {
            get
            {
                if (_instance == null)
                {
                    var mover = FindObjectOfType<Mover>();
                    if (mover)
                    {
                        _instance = mover;
                    }
                    GameObject moverGo = new GameObject("Mover");
                    moverGo.AddComponent<Mover>();
                    Instantiate(moverGo);
                    _instance = moverGo.GetComponent<Mover>();
                    DontDestroyOnLoad(moverGo);
                }
                return _instance;
            }
        }
        
        public static bool InAction { get; protected set; } = false;
        protected static void StartAction()
        {
            InAction = true;
        }
        
        protected static void EndAction()
        {
            InAction = false;
        }

    }
}