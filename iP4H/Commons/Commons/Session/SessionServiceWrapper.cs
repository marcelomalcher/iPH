using System;
using System.Collections.Generic;
using System.Text;

namespace iPH.Commons.Session
{
    class SessionServiceWrapper
    {
        #region Members

        private string wsUrl = "http://localhost:8080/iPHSessionService/iPHSessionService?wsdl"; 

        private SessionService.CollaborativeSessionService sessionService;

        #endregion

        #region Ctors                 

        public SessionServiceWrapper(string sessionServiceURL)
        {
            try
            {
                this.wsUrl = sessionServiceURL;
                this.sessionService = new SessionService.CollaborativeSessionService();
                this.sessionService.Url = this.wsUrl;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }
       
        #endregion

        #region Ping Web Service

        public bool isConnected()
        {
            try
            {
                return sessionService.isConnected();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                return false;
            }        
        }

        #endregion

        #region Session methods

        public bool addSession(string region, string ip, int port, string password, string owner)
        {
            try
            {
                return sessionService.addCollaborativeSession(region, ip, port, password, owner);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }

        public bool removeSession(string region, string ip, int port)
        {
            try
            {
                return sessionService.removeCollaborativeSession(region, ip, port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }

        public SessionService.collaborativeSession[] GetSessions(string region)
        {
            try
            {
                return sessionService.getCollaborativeSessionsRegion(region);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }

        public void clearRegion(string region)
        {
            try
            {
                sessionService.clearRegion(region);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }

        public void clearAll()
        {
            try
            {
                sessionService.clearAll();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new Exception("An error has occurred while attempting to connect to the iPHSessionService: \n" + e.Message);
            }
        }

        #endregion

    }
}
