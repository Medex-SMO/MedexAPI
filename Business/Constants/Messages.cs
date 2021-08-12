using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "You are not authorized";
        public static string UserRegistered = "User registered";
        public static string UserNotFound = "User not found";
        public static string PasswordError = "Wrong password!";
        public static string SuccessfulLogin = "Signed in";
        public static string UserAlreadyExists = "User already exists";
        public static string AccessTokenCreated = "Access token created";

        public static string SponsorAdded = "The sponsor has been added to DB.";
        public static string SponsorDeleted = "The sponsor has been deleted to DB.";
        public static string SponsorListed = "Sponsor listed.";
        public static string SponsorUpdated = "The sponsor has been updated to DB.";
    }
}