using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace Academy.Security
{
    public class SecurityCreateUserException : Exception
    {
        private const string UnknownCreateUserError =
            "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

        private static readonly IDictionary<MembershipCreateStatus, string> errors;

        static SecurityCreateUserException()
        {
            errors = new Dictionary<MembershipCreateStatus, string>();
            errors.Add(
                MembershipCreateStatus.DuplicateUserName,
                "User name already exists. Please enter a different user name.");
            errors.Add(
                MembershipCreateStatus.DuplicateEmail,
                "A user name for that e-mail address already exists. Please enter a different e-mail address.");
            errors.Add(
                MembershipCreateStatus.InvalidPassword,
                "The password provided is invalid. Please enter a valid password value.");
            errors.Add(
                MembershipCreateStatus.InvalidEmail,
                "The e-mail address provided is invalid. Please check the value and try again.");
            errors.Add(
                MembershipCreateStatus.InvalidAnswer,
                "The password retrieval answer provided is invalid. Please check the value and try again.");
            errors.Add(
                MembershipCreateStatus.InvalidQuestion,
                "The password retrieval question provided is invalid. Please check the value and try again.");
            errors.Add(
                MembershipCreateStatus.InvalidUserName,
                "The user name provided is invalid. Please check the value and try again.");
            errors.Add(
                MembershipCreateStatus.ProviderError,
                "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.");
            errors.Add(
                MembershipCreateStatus.UserRejected,
                "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.");
        }

        public SecurityCreateUserException(MembershipCreateUserException exception)
            :base(errors.ContainsKey(exception.StatusCode)
                ? errors[exception.StatusCode]
                : UnknownCreateUserError,
                exception)
        {
        }
    }
}
