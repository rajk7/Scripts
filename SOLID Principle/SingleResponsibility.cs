using UnityEngine;

namespace SPACE.SRP
{
    public class SingleResponsibility : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Single Responsibility Principle example started.");
            
            MailManager mailManager = new MailManager();
            mailManager.SendMail("Title", "Message", "TargetMail");

            Debug.Log("Please review 'SingleResponsibility.cs' for more information.");
        }
    }

    public class MailManager
    {
        #region Private Fields

        private MailValidator _mailValidator;

        #endregion

        public MailManager()
        {
            _mailValidator = new MailValidator();
        }

        public void SendMail(string title, string message, string targetMail)
        {
            if(!_mailValidator.IsValid(targetMail))
                return;
            
            //Send operation.
        }
        
        /*
         * If this method were in this class, it would be against the SRP we used.
         *
        public bool IsValid(string mail)
        {
            return true;
        }
        */
    }

    public class MailValidator
    {
        public bool IsValid(string mail)
        {
            return true;
        }
    }
}