namespace PlayTime.Security
{
    using System;
    using System.Security.Principal;

    public sealed class ActiveDirectory
    {
        public bool Authenticate(string domain, string userName, string password, out ActiveDirectoryUser adResult)
        {
            adResult = null;

            string domainAndUsername = domain + @"\" + userName;

            System.DirectoryServices.DirectoryEntry entry = new System.DirectoryServices.DirectoryEntry("LDAP://dis.dk", domainAndUsername, password);

            try
            {	// Bind to the native AdsObject to force authentication.
                object obj = entry.NativeObject;

                System.DirectoryServices.DirectorySearcher search = new System.DirectoryServices.DirectorySearcher(entry);

                search.Filter = "(SAMAccountName=" + userName + ")";
                search.PropertiesToLoad.Add("DisplayName");
                search.PropertiesToLoad.Add("ObjectSID");
                System.DirectoryServices.SearchResult result = search.FindOne();

                if (null == result)
                {
                    return false;
                }

                string sid = new SecurityIdentifier((byte[])result.Properties["objectSid"][0], 0).ToString();

                adResult = new ActiveDirectoryUser();
                adResult.DisplayName = (string)result.Properties["DisplayName"][0];
                adResult.UserSID = sid;
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

    }
}
