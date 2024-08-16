using UnityEngine;

namespace SPACE.ISP
{
    public class InterfaceSegregation : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Interface Segregation Principle example started.");
            Debug.Log("Please review 'InterfaceSegregation.cs' for more information.");
        }
    }

    /*
     * If we consolidate all inputs into one interface, we would violate the principle we are using.
     * For example, if we implement this interface in a class where we only need the click method,
     * we would still be forced to inherit the drag method.
     * Therefore, breaking down these interfaces into 'IMouseClick' and 'IMouseDrag' will allow us to adhere to this principle.
     */
    public interface IMouseInput
    {
        void Click();
        void Drag();
    }

    public interface IMouseClick
    {
        void Click();
    }

    public interface IMouseDrag
    {
        void Drag();
    }
}