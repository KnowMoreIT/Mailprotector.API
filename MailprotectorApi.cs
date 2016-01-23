using CloudPanel.Spam.Mailprotector.Models;
using CloudPanel.Spam.Mailprotector.Models.Users;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudPanel.Spam.Mailprotector
{
    public class MailprotectorApi : MailprotectorConnection
    {
        public enum SpamDirection { inbound, outbound }
        public enum QuarantineType { spam, virus, policy, released }

        public MailprotectorApi(string url, string token) : base(url, token)
        {

        }

        /// <summary>
        /// Return the specified user.
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public User GetUser(int userId)
        {
            RestRequest request = new RestRequest(string.Format("/users/{0}", userId), Method.GET);

            IRestResponse<User> response = client.Execute<User>(request);
            response.HandleErrors();

            return response.Data;
        }

        /// <summary>
        /// Return a collection of users that belong to the specified domain.
        /// </summary>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public List<User> GetUsersByDomain(int domainId)
        {
            RestRequest request = new RestRequest(string.Format("/domains/{0}/users.xml", domainId), Method.GET);

            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            response.HandleErrors();

            return response.Data;
        }

        /// <summary>
        /// Return a collection of users that belong to the specified user group.
        /// </summary>
        /// <param name="groupId"></param>
        /// <returns></returns>
        public List<User> GetUsersByGroup(int groupId)
        {
            RestRequest request = new RestRequest(string.Format("/user_groups/{0}/users.xml", groupId), Method.GET);

            IRestResponse<List<User>> response = client.Execute<List<User>>(request);
            response.HandleErrors();

            return response.Data;
        }

        /// <summary>
        /// Create a new user under the specified domain under the default user group.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public User CreateUserInDomain(User newUser)
        {
            RestRequest request = new RestRequest(string.Format("/domains/{0}/users.xml", newUser.domain_id), Method.POST);
            request.AddParameter("user[name]", newUser.name);

            if (!string.IsNullOrEmpty(newUser.user_type))
                request.AddParameter("user[user_type]", newUser.user_type);
           
            if (!string.IsNullOrEmpty(newUser.first_name))
                request.AddParameter("user[first_name]", newUser.first_name);

            if (!string.IsNullOrEmpty(newUser.last_name))
                request.AddParameter("user[last_name]", newUser.last_name);

            if (!string.IsNullOrEmpty(newUser.password))
                request.AddParameter("user[password]", newUser.password);

            if (newUser.parent_id > 0)
                request.AddParameter("user[parent_id]", newUser.parent_id);

            IRestResponse<User> response = client.Execute<User>(request);
            response.HandleErrors();

            return response.Data;
        }

        /// <summary>
        /// Create a new user under the specified user group.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
        public User CreateUserInGroup(User newUser)
        {
            RestRequest request = new RestRequest(string.Format("/user_groups/{0}/users.xml", newUser.user_group_id), Method.POST);
            request.AddParameter("name", newUser.name);
            request.AddParameter("user_type", newUser.user_type);

            if (!string.IsNullOrEmpty(newUser.first_name))
                request.AddParameter("first_name", newUser.first_name);

            if (!string.IsNullOrEmpty(newUser.last_name))
                request.AddParameter("last_name", newUser.last_name);

            if (!string.IsNullOrEmpty(newUser.password))
                request.AddParameter("password", newUser.password);

            if (newUser.parent_id > 0)
                request.AddParameter("parent_id", newUser.parent_id);

            IRestResponse<User> response = client.Execute<User>(request);
            response.HandleErrors();

            return response.Data;
        }

        /// <summary>
        /// Import users to the specified domain under the default user group.
        /// </summary>
        /// <param name="import"></param>
        /// <param name="domainId"></param>
        /// <returns></returns>
        public string ImportUsersInDomain(Import import, int domainId)
        {
            RestRequest request = new RestRequest(string.Format("/domains/{0}/import.xml", domainId), Method.POST);

            string content = request.XmlSerializer.Serialize(import);
            request.AddParameter("text/xml", content, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            response.HandleErrors();

            return response.Content;
        }

        /// <summary>
        /// Import users to the specified user group.
        /// </summary>
        /// <param name="import"></param>
        /// <param name="userGroupId"></param>
        /// <returns></returns>
        public string ImportUsersInUserGroup(Import import, int userGroupId)
        {
            RestRequest request = new RestRequest(string.Format("/user_groups/{0}/import.xml", userGroupId), Method.POST);

            string content = request.XmlSerializer.Serialize(import);
            request.AddParameter("text/xml", content, ParameterType.RequestBody);

            IRestResponse response = client.Execute(request);
            response.HandleErrors();

            return response.Content;
        }

        /// <summary>
        /// Deletes a specific user
        /// </summary>
        /// <param name="userId"></param>
        public void DeleteUser(int userId)
        {
            RestRequest request = new RestRequest(string.Format("/users/{0}.xml", userId), Method.DELETE);

            IRestResponse response = client.Execute(request);
            response.HandleErrors();
        }

        /// <summary>
        /// Bulk delete users from a specific domain
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="userIds"></param>
        public void DeleteUsers(int domainId, int[] userIds)
        {
            RestRequest request = new RestRequest(string.Format("/domains/{0}/users/destroy_users.xml", domainId), Method.POST);
            foreach (int userId in userIds)
                request.AddParameter("user_ids[]", userId);
            
            IRestResponse response = client.Execute(request);
            response.HandleErrors();
        }

        /// <summary>
        /// Returns a collection of user inbound and outbound message summaries for the specific domains' users
        /// </summary>
        /// <param name="domainId"></param>
        /// <param name="start">The beginning of the date range to pull statistics for</param>
        /// <param name="end">The end of the date range to pull statistics for.</param>
        /// <param name="direction">The type of traffic to pull statistics for. Possible values are inbound or outbound. This is optional and when it is not include, both directions are included in the response.</param>
        /// <returns></returns>
        public MessageSummaries GetDomainStats(int domainId, DateTime start, DateTime end, SpamDirection direction = SpamDirection.inbound)
        {
            RestRequest request = new RestRequest(string.Format("/domains/{0}/messages.xml", domainId), Method.GET);
            request.AddParameter("date_start", start);
            request.AddParameter("date_end", end);
            request.AddParameter("direction", direction.ToString());

            IRestResponse<MessageSummaries> response = client.Execute<MessageSummaries>(request);
            response.HandleErrors();

            return response.Data;            
        }

        /// <summary>
        /// Releases a message from the queue
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="messageId"></param>
        /// <param name="release_to_user"></param>
        /// <param name="release_to_me"></param>
        /// <param name="release_to_recipients"></param>
        /// <returns></returns>
        public string ReleaseMessage(int userId, int messageId, bool release_to_user = true, bool release_to_me = false, bool release_to_recipients = false)
        {
            RestRequest request = new RestRequest(string.Format("/users/{0}/messages/release_messages", userId), Method.POST);
            request.AddParameter("message_id", messageId);
            request.AddParameter("release_to_user", release_to_user);
            request.AddParameter("release_to_me", release_to_me);
            request.AddParameter("release_to_recipients", release_to_recipients);

            IRestResponse response = client.Execute(request);
            response.HandleErrors();

            return response.Content;
        }

        /// <summary>
        /// Retrieves spam
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="spamMode"></param>
        /// <param name="quarantineType"></param>
        /// <param name="tab"></param>
        /// <param name="filter_value"></param>
        /// <param name="sort_column"></param>
        /// <param name="sort_dir"></param>
        /// <param name="offset"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public List<Message> GetSpam(int userId, DateTime start, DateTime end, SpamDirection spamDirection = SpamDirection.inbound, QuarantineType quarantineType = QuarantineType.spam, string tab = "spam", string filter_value = "", string sort_column = "date", string sort_dir = "desc", int offset = 0, int limit = 50)
        {
            RestRequest request = new RestRequest(string.Format("/users/{0}/quarantine.xml", userId), Method.POST);
            request.AddParameter("mode", spamDirection.ToString());
            request.AddParameter("quarantine", quarantineType.ToString());
            request.AddParameter("tab", tab);
            request.AddParameter("filter_value", filter_value);
            request.AddParameter("sort_column", sort_column);
            request.AddParameter("sort_dir", sort_dir);
            request.AddParameter("offset", offset);
            request.AddParameter("limit", limit);
            request.AddParameter("date_start", start);
            request.AddParameter("date_end", end);

            IRestResponse<List<Message>> response = client.Execute<List<Message>>(request);
            response.HandleErrors();

            return response.Data;
        }
    }
}
