using UnityEngine;

namespace SPACE.OCP
{
    public class OpenClosed : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Open Closed Principle example started.");
            
            MailManager googleMailManager = new MailManager(new GoogleMailValidator());
            googleMailManager.SendMail("Title", "Message", "sample@gmail.com");
            
            MailManager microsoftMailManager = new MailManager(new MicrosoftMailValidator());
            microsoftMailManager.SendMail("Title", "Message", "sample@outlook.com");
            
            Debug.Log("Please review 'OpenClosed.cs' for more information.");
        }
    }
    
    public class MailManager
    {
        #region Private Fields

        private IMailValidator _mailValidator;

        #endregion
        
        public MailManager(IMailValidator mailValidator)
        {
            _mailValidator = mailValidator;
        }

        public void SendMail(string title, string message, string targetMail)
        {
            if(!_mailValidator.IsValid(targetMail))
                return;
            
            //Send progress.
        }
    }

    public interface IMailValidator
    {
        bool IsValid(string mail);
    }
    
    public class MicrosoftMailValidator : IMailValidator
    {
        public bool IsValid(string mail)
        {
            if (!mail.Contains("@outlook.com"))
                return false;
            
            Debug.Log("Micorosft mail is valid.");
            
            return true;
        }
    }
    
    public class GoogleMailValidator : IMailValidator
    {
        public bool IsValid(string mail)
        {
            if (!mail.Contains("@gmail.com"))
                return false;
            
            Debug.Log("Google mail is valid.");

            return true;
        }
    }
}