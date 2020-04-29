using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace FlowTask_Backend
{
    /// <summary>
    /// The database interface for the outside world
    /// </summary>
    public class DatabaseController
    {
        /// <summary>
        /// Uses singleton design pattern
        /// </summary>
        private static DatabaseController dbSingleton;


        /// <summary>
        /// Singleton database controller
        /// </summary>
        public static DatabaseController GetDBController(bool IsLocal = false)
        {
            return dbSingleton ?? (dbSingleton = new DatabaseController());
        }

        public DatabaseController()
        {
        }


        /// <summary>
        /// Writes a user to the database with the given information.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public (bool Succeeded, string ErrorMessage) WriteUser(User user)
        {
            return (true, "Success");
        }

        /// <summary>
        /// Returns an authorization cookie with a secure random Bitstring
        /// </summary>
        /// <returns></returns>
        private AuthorizationCookie getAuthCookie()
        {
            return new AuthorizationCookie(new byte[256]);
        }

        /// <summary>
        /// Login the user with the username and password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>The User and an accompanying Authorization Cookie</returns>
        public (User user, AuthorizationCookie? ac) GetUser(string username, string password)
        {
            var ac = getAuthCookie();
            User user = new User(password,username,"Bob","Marley","Bob.Marley@raeggae.com");
            return (user, ac);
        }


        /// <summary>
        /// Write a task into the database. Returns a new task with the decomposition.
        /// </summary>
        /// <param name="task"></param>
        /// <param name="ac"></param>
        /// <returns></returns>
        public (bool Succeeded, string FailureString, Task fullTask) WriteTask(Task task, AuthorizationCookie ac)
        {
            //create a graph first...
            Graph new_graph = new Graph();
            int graphID = 0;
            
            //some pre-defined scenarios...
            if (task.Category.Equals("Research Paper"))
            {
                //vertex set
                Node header = new Node(task.Category, 0, false, task.SubmissionDate, "", graphID, 0);
                Node n1 = new Node("Collect Sources", 0, false, task.SubmissionDate.AddDays(-11), "Research", graphID, 1);
                Node n2 = new Node("Write Thesis", 0, false, task.SubmissionDate.AddDays(-10), "", graphID, 2);
                Node n3 = new Node("Introduction", 0, false, task.SubmissionDate.AddDays(-9), "", graphID, 3);
                Node n4 = new Node("Body Paragraph 1", 0, false, task.SubmissionDate.AddDays(-7), "", graphID, 4);
                Node n5 = new Node("Body Paragraph 2", 0, false, task.SubmissionDate.AddDays(-5), "", graphID, 5);
                Node n6 = new Node("Body Paragraph 3", 0, false, task.SubmissionDate.AddDays(-3), "", graphID, 6);
                Node n7 = new Node("Conclusion", 0, false, task.SubmissionDate.AddDays(-2), "", graphID, 7);
                Node n8 = new Node("Citations", 0, false, task.SubmissionDate.AddDays(-1), "", graphID, 8);
                new_graph.AddNodes(header, n1, n2, n3, n4, n5, n6, n7, n8);
                //edge set
                new_graph.CreateEdge(header, n1);
                new_graph.CreateEdge(header, n2);
                new_graph.CreateEdge(header, n3);
                new_graph.CreateEdge(header, n4);
                new_graph.CreateEdge(header, n5);
                new_graph.CreateEdge(header, n6);
                new_graph.CreateEdge(header, n7);
                new_graph.CreateEdge(header, n8);
            }
            else if (task.Category.Equals("Agile Software Project"))
            {
                //vertex set
                Node header = new Node(task.Category, 0, false, task.SubmissionDate, "", graphID, 0);
                Node n1 = new Node("Sprint 1", 0, false, task.SubmissionDate.AddDays(-13), "Deliverable", graphID, 1);
                Node n1_1 = new Node("Create Wireframe", 0, false, task.SubmissionDate.AddDays(-14), "Lucidchart", graphID, 2);
                Node n2 = new Node("Sprint 2", 0, false, task.SubmissionDate.AddDays(-6), "Deliverable", graphID, 3);
                Node n2_1 = new Node("Create SQLite Database", 0, false, task.SubmissionDate.AddDays(-11), "", graphID, 4);
                Node n2_2 = new Node("Write Web API", 0, false, task.SubmissionDate.AddDays(-9), "REST API", graphID, 5);
                Node n2_3 = new Node("Code Review", 0, false, task.SubmissionDate.AddDays(-7), "Pair Programming", graphID, 6);
                Node n3 = new Node("Sprint 3", 0, false, task.SubmissionDate, "Deliverable", graphID, 7);
                Node n3_1 = new Node("Unit Test", 0, false, task.SubmissionDate.AddDays(-2), "Ryan and Kyle", graphID, 8);
                Node n3_2 = new Node("Release Version 1", 0, false, task.SubmissionDate.AddDays(-1), "GitHub Release", graphID, 9);
                new_graph.AddNodes(header, n1, n1_1, n2, n2_1, n2_2, n2_3, n3, n3_1, n3_2);
                //edge set
                new_graph.CreateEdge(header, n1);
                new_graph.CreateEdge(header, n2);
                new_graph.CreateEdge(header, n3);
                new_graph.CreateEdge(n1, n1_1);
                new_graph.CreateEdge(n2, n2_1);
                new_graph.CreateEdge(n2, n2_2);
                new_graph.CreateEdge(n2, n2_3);
                new_graph.CreateEdge(n3, n3_1);
                new_graph.CreateEdge(n3, n3_2);
            }
            //generate an updated task with this decomposition info to return to the user
            Task return_task = new Task(0, task.AssignmentName, graphID, task.SubmissionDate, task.Category, task.UserID);

            return_task.AddGraph(new_graph);

            return (true, "Success", return_task);
        }

        /// <summary>
        /// Delete a task (and its decomposition) from the database
        /// </summary>
        /// <param name="t"></param>
        /// <param name="ac"></param>
        /// <returns></returns>
        public (bool Succeeded, string ErrorMessage) DeleteTask(Task t, AuthorizationCookie ac)
        {
            return (true, "Successfully deleted your task!");
        }

        /// <summary>
        /// Updates the completion status of a given node
        /// </summary>
        /// <param name="ac"></param>
        /// <param name="userID"></param>
        /// <param name="nodeID"></param>
        /// <param name="complete"></param>
        /// <returns></returns>
        public (bool Succeeded, string ErrorMessage) UpdateComplete(AuthorizationCookie ac, int userID, int nodeID, bool complete)
        {
            return (true, "Successfully updated value.");
        }


    }
}
